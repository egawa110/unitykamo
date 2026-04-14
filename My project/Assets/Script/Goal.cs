using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public bool isGoal = false;
    //public GameObject GoalPanel;


    void Start()
    {
        
    }

    void Update()
    {
        //if (isGoal)
        //{
        //    GoalPanel.SetActive(true);

        //}

        //デバッグ用
        if (Input.GetKeyDown(KeyCode.G))
        {
            isGoal = true;
        }
    }
}
