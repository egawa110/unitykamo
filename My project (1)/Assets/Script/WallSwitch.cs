using UnityEngine;

public class WallSwitch : MonoBehaviour
{
    public GameObject[] DisappearWalls; //消える壁の配列

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject DWall in DisappearWalls) //スイッチを踏んでいる間消える壁
            {
                DWall.SetActive(false);
            }

        }
    }
}
