using UnityEngine;
using UnityEngine.InputSystem;
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
                PlayerFunction.PlayerAngle(player.PlayerRotate, (int)angle.w);
                player.PlayerRotate = PlayerFunction.PlayerAngle(player.PlayerRotate, (int)angle.w);
            }
            if (sKey.isPressed && x > MinTilt)
            {
                x -= Speed;
                PlayerFunction.PlayerAngle(player.PlayerRotate, (int)angle.s);
                player.PlayerRotate = PlayerFunction.PlayerAngle(player.PlayerRotate, (int)angle.s);

            }
            if (aKey.isPressed && z < MaxTilt)
            {
                z += Speed;
                PlayerFunction.PlayerAngle(player.PlayerRotate, (int)angle.a);
                player.PlayerRotate = PlayerFunction.PlayerAngle(player.PlayerRotate, (int)angle.a);

            }
            if (dKey.isPressed && z > MinTilt)
            {
                z -= Speed;
                PlayerFunction.PlayerAngle(player.PlayerRotate, (int)angle.d);
                player.PlayerRotate = PlayerFunction.PlayerAngle(player.PlayerRotate, (int)angle.d);

            }

        }

        if (warpswitch.WarpFlag == true || player.abyssflag == true) //プレイヤーがワープ時地面の傾き初期化
        {
            x = 0; y = 0; z = 0;
            GRotation = Vector3.zero;
            transform.eulerAngles = Vector3.zero;
            player.abyssflag = false;
        }
        else
        {
            GRotation = new Vector3(x, y, z);
            transform.eulerAngles = GRotation;
        }
    }
}
