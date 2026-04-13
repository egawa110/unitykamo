using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //ポーズ画面
    public GameObject Pause;
    private bool isVisible = false;
    //タイマー
    public Text TimeText;
    private float TimeCount;
    void Start()
    {
        TimeCount = 0f;
    }

    void Update()
    {
        //タイマー
        TimeCount += Time.deltaTime;
        TimeText.text = TimeCount.ToString("F1");

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

    }
}
