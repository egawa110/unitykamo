using UnityEngine;

public class WarpSwitch : MonoBehaviour
{
    Vector3 WarpPos;
    Vector3 WarpRotation;
    public GameObject WarpPosition;
    public bool WarpFlag;
    private float CoolTime;
    private float Count;

    public Player player;
    void Start()
    {
        WarpPos = Vector3.zero; WarpRotation = Vector3.zero;
        WarpFlag = false;
        CoolTime = 60f;
        Count = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            WarpFlag = true;
        }
    }

    private void Update()
    {
        WarpPos = WarpPosition.transform.position;  //ワープ先の位置を取得
        WarpRotation = WarpPosition.transform.eulerAngles;

        if (WarpFlag == true)
        {
            Count++;
            Debug.Log("ワープスイッチを押した");
            player.transform.eulerAngles = WarpRotation;
            player.transform.position = WarpPos;  //プレイヤーをワープ

            if (Count == CoolTime)
            {
                Count = 0f;
                WarpFlag = false;
            }
        }
    }
}
