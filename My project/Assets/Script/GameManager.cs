using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
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
    public Goal goal;
    //ステージの傾き表示
    public GameObject TiltPanel;
    public Text TiltTextX;
    public Text TiltTextY;
    public Move move;
    void Start()
    {
        TimeCount = 0f;
    }

    void Update()
    {
        //タイマー
        if (!goal.isGoal)
        {
            TimeCount += Time.deltaTime;
            TimeText.text = TimeCount.ToString("F1") + " 秒";

        }

        //ポーズ画面
        if (Input.GetKeyDown(KeyCode.Escape)){
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

        //ステージの傾き表示
        TiltTextX.text = "X:" + move.x.ToString("F1");
        TiltTextY.text = "Z:" + move.z.ToString("F1");

    }
}
