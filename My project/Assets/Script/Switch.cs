using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private int SwitchCount; //スイッチを踏んでいる数を確かめるため

    public GameObject[] DisappearWalls; //消える壁の配列
    public GameObject[] AppearingWalls; //出現する壁の配列
    void Start()
    {
        SwitchCount = 0;
    }
    void OnTriggerEnter(Collider other) //Triggerがonになっている物に触れた時
    {
        if (other.CompareTag("Ball"))
        {
            foreach (GameObject DWall in DisappearWalls) //スイッチを踏んでいる間消える壁
            {
                DWall.SetActive(false);
            }
            foreach (GameObject AWall in AppearingWalls) //スイッチを踏んでいる間出現する壁
            {
                AWall.SetActive(true);
            }

        }
    }
    void OnTriggerExit(Collider other) //Triggerがonになっている物から離れた時
    {
        if (other.CompareTag("Ball"))
        {
            foreach (GameObject DWall in DisappearWalls) //スイッチを踏んでいる間消える壁
            {
                DWall.SetActive(true);
            }
            foreach (GameObject AWall in AppearingWalls) //スイッチを踏んでいる間出現する壁
            {
                AWall.SetActive(false);
            }

        }
    }
}
