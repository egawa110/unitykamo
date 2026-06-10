using UnityEngine;
using System.Collections;
public class WarpSwitch : MonoBehaviour
{
    Vector3 WarpPos;
    Vector3 WarpRotation; //ワープした時のオブジェクトの傾き
    public GameObject WarpPosition; //ワープ先のポジション
    public GameObject warpEffect;
    public bool WarpFlag;
    private bool effectflag;
    private float CoolTime;
    private float Count;

    public Player player;
    IEnumerator WarpCoroutine()
    {
        effectflag = true;
        yield return new WaitForSeconds(2); //　１０秒まつ
        effectflag = false;
    }

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
        warpEffect.SetActive(effectflag);

        if (WarpFlag == true)
        {
            Count++;
            Debug.Log("ワープスイッチを押した");
            player.transform.eulerAngles = WarpRotation;
            player.transform.position = WarpPos;  //プレイヤーをワープ
            StartCoroutine(WarpCoroutine());
            if (Count == CoolTime)
            {
                Count = 0f;
                WarpFlag = false;
            }
        }
    }
}
