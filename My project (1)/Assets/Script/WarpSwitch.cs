using UnityEngine;

public class WarpSwitch : MonoBehaviour
{
    Vector3 WarpPos;
    public GameObject WarpPosition;

    public Player player;
    void Start()
    {
        WarpPos = WarpPosition.transform.position;  //ワープ先の位置を取得
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("ワープスイッチを押した");
            player.transform.position = WarpPos;  //プレイヤーをワープ
        }
    }
}
