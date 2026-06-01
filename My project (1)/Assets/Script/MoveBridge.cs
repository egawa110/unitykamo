using UnityEngine;

public class MoveBridge : MonoBehaviour
{
    const float speed = 0.01f;
    const float posx = 0.3f;
    private Vector3 pos;
    private Vector3 nextpos;

    public MoveGround mg;
    void Start()
    {
        pos = transform.position;
        nextpos.x = pos.x + posx;
    }

    void Update()
    {
        if(nextpos.x <= pos.x)
        {
            pos.x += speed;

        }

        transform.position = pos;
    }
}
