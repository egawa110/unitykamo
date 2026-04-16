using UnityEngine;

public class ResetManager : MonoBehaviour
{
    public bool Reset;
    private const float ResetTime = 2;
    private float second;

    void Start()
    {
        Reset = false;
        second = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {  
            Reset = true;

        }

        if (Reset)
        {
            second++;
            if(second == ResetTime)
            {
                second = 0;
                Reset = false;

            }
        }
    }
}
