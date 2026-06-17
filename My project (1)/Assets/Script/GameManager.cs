using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //ポーズ画面
    public GameObject Pause;
    private bool isVisible = false;
    //タイマーとかHPとか
    public GameObject TimePanel;
    public Text TimeText;
    public Text Money;
    private float TimeCount;
    //ゴール時
    public GameObject GoalPanel;
    public Text GoalTime;
    //プレイヤー死亡時
    public GameObject DethPanel;

    public GoalManager goal;
    public Player player;
    void Start()
    {
        TimeCount = 0f;

    }

    void Update()
    {
        var current = Keyboard.current;  //現在のキーボード情報
        if (current == null) return;     //キーボード接続チェック
        var escKey = current.escapeKey; //Wキーの入力状態取得

        //UIパネル
        if (!goal.isGoal)
        {
            //タイマー
            TimeCount += Time.deltaTime;
            TimeText.text = "Time : " + TimeCount. ToString ("F1");
            //所持金
            Money.text = "G:" + StatusButton.money;
        }

        //ポーズ画面
        if (escKey.wasPressedThisFrame)
        {
            isVisible = !isVisible;
            Pause.SetActive(isVisible);
            Time.timeScale = 0; //ポーズ画面中は時間停止
        }
        if (!isVisible)
        {
            Time.timeScale = 1;
        }

        //ゴール
        if (goal.isGoal)
        {
            GoalPanel.SetActive(true);
            TimePanel.SetActive(false);
            GoalTime.text = "クリアタイム:" + TimeCount.ToString("F1") + " 秒";
        }

        //死亡時
        if(player.PlayerDeth == true)
        {
            DethPanel.SetActive(true);
        }
    }
}
