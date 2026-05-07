using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //ポーズ画面
    public GameObject Pause;
    private bool isVisible = false;
    //タイマー
    public GameObject TimePanel;
    public Text TimeText;
    private float TimeCount;
    //ゴール時
    public GameObject GoalPanel;
    public Text GoalTime;
    public GoalManager goal;

    void Start()
    {
        TimeCount = 0f;

    }

    void Update()
    {
        var current = Keyboard.current;  //現在のキーボード情報
        if (current == null) return;     //キーボード接続チェック
        var escKey = current.escapeKey; //Wキーの入力状態取得

        //タイマー
        if (!goal.isGoal)
        {
            TimeCount += Time.deltaTime;
            TimeText.text = "Time : " + TimeCount. ToString ("F1");

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

    }
}
