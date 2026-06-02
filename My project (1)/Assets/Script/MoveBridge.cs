using UnityEngine;

public class MoveBridge : MonoBehaviour
{
    const float speed = 0.01f;
    public float move = 0;
    private float posx;
    private int count;
    const int maxcount = 2; //カウントの上限
    private Vector3 pos;
    private Vector3 nextpos;

    void Start()
    {
        pos = transform.position;
        posx = pos.x; //最初の位置を保存
        nextpos.x = pos.x + move;
        count = 0; //posが指定の場所に到着したら+する
    }

    void Update()
    {
        if(nextpos.x >= pos.x && count == 0)// 指定の位置に向かう
        {
            pos.x += speed;
            if(nextpos.x <= pos.x)
            count = 1;
        }
        else if (count != maxcount) //指定の位置まで行けたら折り返し
        {
            pos.x -= speed;
            if (pos.x <= posx)
                count = 2;
        }
        if (count >= maxcount) //カウントが上限まで行ったら初期化
        {
            count = 0;
        }

        transform.position = pos;
    }
}
