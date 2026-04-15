using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    private int SwitchCount; //スイッチを踏んでいる数を確かめるため

    public GameObject SwitchWall; //消える壁
    void Start()
    {
        SwitchCount = 0;
    }
    void OnTriggerEnter(Collider other) //Triggerがonになっている物に触れた時
    {
        if (other.CompareTag("Ball"))
        {
            SwitchWall.SetActive(false);

        }
    }
    void OnTriggerExit(Collider other) //Triggerがonになっている物から離れた時
    {
        if (other.CompareTag("Ball"))
        {
            SwitchWall.SetActive(true);

        }
    }


}
