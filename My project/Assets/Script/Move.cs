using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    private Vector3 m_Rotation;

    const float Speed = 0.05f;  //‰ñ“]ƒXƒs[ƒh
    private float x = 0, y = 0, z = 0;

    public ResetManager reset;

    enum Ground  //Ground‚ÌÅ‰‚Ì‰ŠúˆÊ’u
    {
        Gx = 0,
        Gy = 0,
        Gz = 0
    }
    void Start()
    {
        x = (float)Ground.Gx;
        y = (float)Ground.Gy;
        z = (float)Ground.Gz;

        m_Rotation = new Vector3(x, y, z); //Ground‚ÌŒX‚«‚ğİ’è
        transform.eulerAngles = m_Rotation;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)){  //‰œ‚ÉŒX‚¯‚é
            x += Speed;
        }
        if (Input.GetKey(KeyCode.S))  //‘O‚ÉŒX‚¯‚é
        {
            x -= Speed;
        }
        if (Input.GetKey(KeyCode.A))  //¶‚ÉŒX‚¯‚é
        {
            z += Speed;
        }
        if (Input.GetKey(KeyCode.D))  //‰E‚ÉŒX‚¯‚é
        {
            z -= Speed;
        }
        if (reset.Reset){  //ŒX‚«‚ğƒŠƒZƒbƒg
            x = (float)Ground.Gx;
            y = (float)Ground.Gy;
            z = (float)Ground.Gz;
        }

        m_Rotation = new Vector3(x, y, z);
        transform.eulerAngles = m_Rotation;

    }
}
