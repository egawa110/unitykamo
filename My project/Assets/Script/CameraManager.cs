using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //カメラ回転
    private Vector3 m_Rotation;
    const float Speed = 0.05f;  //回転スピード
    private float x = 0, y = 0, z = 0;

    //カメラズーム
    public Camera cam;
    private float scroll;
    const float StartPos  = 60f;
    const float ZoomSpeed = 10f;
    const float MinZoom   = 5f;
    const float MaxZoom   = 100f;

    //リセット
    public ResetManager reset;
    enum CameraControll  //Cameraの最初の初期位置
    {
        Cx = 0,
        Cy = 0,
        Cz = 0
    }

    void Start()
    {
        scroll = 0;

        //Cameraの位置初期化
        x = (float)CameraControll.Cx;
        y = (float)CameraControll.Cy;
        z = (float)CameraControll.Cz;

        m_Rotation = new Vector3(x, y, z); 
        transform.eulerAngles = m_Rotation;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))  //左移動
        {
            y += Speed;
        }
        if (Input.GetKey(KeyCode.E))  //右移動
        {
            y -= Speed;
        }

        //カメラズーム
        scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0f)
        {
            cam.fieldOfView -= scroll * ZoomSpeed;
            cam.fieldOfView = Mathf.Clamp(cam.fieldOfView, MinZoom, MaxZoom);
        }
        //傾き＆ズームをリセット
        if (reset.Reset){  
            x = (float)CameraControll.Cx;
            y = (float)CameraControll.Cy;
            z = (float)CameraControll.Cz;

            cam.fieldOfView = StartPos;
        }

        m_Rotation = new Vector3(x, y, z);
        transform.eulerAngles = m_Rotation;

    }
}
