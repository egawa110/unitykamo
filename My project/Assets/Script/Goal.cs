using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public bool isGoal = false;
    public int GoalCount;


    void Start()
    {
        GoalCount = 0;
    }

    void Update()
    {
        //デバッグ用
        if (Input.GetKeyDown(KeyCode.G))
        {
            isGoal = true;
        }
    }
}
