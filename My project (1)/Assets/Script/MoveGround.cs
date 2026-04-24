using UnityEngine;
using UnityEngine.InputSystem;
public class MoveGround : MonoBehaviour
{
    public Vector3 m_GRotation;
    private float x, y, z;

    const float Speed = 0.05f; //地面の傾くスピード
    const float MaxTilt = 20;  //最大傾き
    const float MinTilt = -20; //最小傾き

    void Start()
    {
        x = 0; y = 0; z = 0;
        m_GRotation = new Vector3(x, y, z);
        transform.eulerAngles = m_GRotation;
    }

    void Update()
    {
        var current = Keyboard.current;  //現在のキーボード情報
        if (current == null) return;     //キーボード接続チェック

        var wKey = current.wKey; //Wキーの入力状態取得
        var aKey = current.aKey; //Aキーの入力状態取得
        var sKey = current.sKey; //Sキーの入力状態取得
        var dKey = current.dKey; //Dキーの入力状態取得

        //キーが押されているかどうか
        if (wKey.isPressed && x < MaxTilt) x += Speed;
        if (sKey.isPressed && x > MinTilt) x -= Speed;
        if (aKey.isPressed && z < MaxTilt) z += Speed;
        if (dKey.isPressed && z > MinTilt) z -= Speed;
        
            
        

        m_GRotation = new Vector3(x, y, z);
        transform.eulerAngles = m_GRotation;

    }
}
