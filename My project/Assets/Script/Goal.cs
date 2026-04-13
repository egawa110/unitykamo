using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public bool isGoal = false;
    public RawImage GoalImage;
    public GameObject NextButton;
    public GameObject MenuButton;
    public GameObject RestartButton;



    void Start()
    {
        
    }

    void Update()
    {
        if (isGoal)
        {
            GoalImage.gameObject.SetActive(true);
            NextButton.SetActive(true);
            MenuButton.SetActive(true);
            RestartButton.SetActive(true);

        }
    }
}
