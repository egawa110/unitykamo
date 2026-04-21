using UnityEngine;
using UnityEngine.InputSystem;

public class Camera : MonoBehaviour
{
    //カメラをプレイヤーに追尾
    public Player player; //Playerオブジェクト
    private Vector3 mCamera;
    private float x, y, z;

    //カメラ回転
    private Vector3 m_Rotation;
    const float Speed = 0.05f;  //回転スピード
    private float rx, ry, rz;

    void Start()
    {
        //カメラをプレイヤーに追尾
        x = 0; y = 0; z = 0;
        mCamera = new Vector3(x, y, z);
        //カメラ回転
        m_Rotation = new Vector3(rx, ry, rz);
        transform.eulerAngles = m_Rotation;

    }

    void Update()
    {
        //カメラをプレイヤーに追尾
        player.mPlayer.y  = mCamera.y; //カメラのY軸を固定
        player.mPlayer.z += mCamera.z; //カメラZ軸を引き気味に設定

        transform.position = player.mPlayer;

        //カメラの回転
        var current = Keyboard.current;  //現在のキーボード情報
        if (current == null) return;     //キーボード接続チェック
        var qKey = current.qKey; //Qキーの入力状態取得
        var eKey = current.eKey; //Eキーの入力状態取得

        if (qKey.isPressed) ry += Speed;
        if (eKey.isPressed) ry -= Speed;

        m_Rotation = new Vector3(rx, ry, rz);  //カメラ回転
        transform.eulerAngles = m_Rotation;

    }
}
