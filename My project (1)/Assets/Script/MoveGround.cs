using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class MoveGround : MonoBehaviour
{
    public Vector3 GRotation;
    private float x, y, z;

    const float Speed = 0.03f; //地面の傾くスピード
    const float MaxTilt = 20;  //最大傾き
    const float MinTilt = -20; //最小傾き
    enum angle //playerの向き
    {
        w = 0,
        a = -90,
        s = 180,
        d = 90,
    }

    public WarpSwitch warpswitch;
    public Player player;
    void Start()
    {
        x = 0; y = 0; z = 0;
        GRotation = new Vector3(x, y, z);
        transform.eulerAngles = GRotation;
    }

    void Update()
    {
        var current = Keyboard.current;  //現在のキーボード情報
        if (current == null) return;     //キーボード接続チェック

        var wKey = current.wKey; //Wキーの入力状態取得
        var aKey = current.aKey; //Aキーの入力状態取得
        var sKey = current.sKey; //Sキーの入力状態取得
        var dKey = current.dKey; //Dキーの入力状態取得

        if(Time.timeScale != 0)//ポーズ中は動かない
        {
            //キーが押されているかどうか
            if (wKey.isPressed && x < MaxTilt)
            {
                x += Speed;
                //プレイヤーの向き
            }
            if (sKey.isPressed && x > MinTilt)
            {
                x -= Speed;

            }
            if (aKey.isPressed && z < MaxTilt)
            {
                z += Speed;

            }
            if (dKey.isPressed && z > MinTilt)
            {
                z -= Speed;

            }

        }

        if (warpswitch.WarpFlag || player.abyssflag) //プレイヤーがワープ時地面の傾き初期化
        {
            x = 0; y = 0; z = 0;
            GRotation = Vector3.zero;
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            GRotation = new Vector3(x, y, z);
            transform.eulerAngles = GRotation;
        }
        transform.eulerAngles = GRotation;

    }
}
