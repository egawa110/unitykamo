using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 StartPos;
    private Rigidbody rb;
    public float Bx = 0, By = 0, Bz = 0; //各ステージで設定出来るようにpbulicにしている
    
    public Goal goal;
    public ResetManager reset;
    void Start()
    {
        StartPos = new Vector3(Bx, By, Bz);
        transform.position = StartPos;  //Ballの位置を設定

        rb = GetComponent<Rigidbody>(); //BallのRigidbodyを獲得
    }

    void OnTriggerEnter(Collider other) //Triggerがonになっている物に触れた時
    {
        if (other.CompareTag("Goal")) //Goalタグに触れた時
        {
            goal.isGoal = true;
        }
        if (other.CompareTag("HalfGoal")) //HalfGoalタグに触れた時
        {
            goal.GoalCount++;
        }
    }

    void OnTriggerExit(Collider other)　//Triggerがonになっている物から離れた時
    {
        if (other.CompareTag("HalfGoal")) //HalfGoalタグを離れた時
        {
            goal.GoalCount--;
        }

    }

    void Update()
    {
        if (reset.Reset){  //リセット
            transform.position = StartPos;      //位置をリセット
            rb.velocity        = Vector3.zero;  //直線の慣性をリセット
            rb.angularVelocity = Vector3.zero;  //回転の慣性をリセット

        }
        if (goal.GoalCount == 2)//HalfGoalタグに２個触れた時
        {
            goal.isGoal = true;
        }
    }
}
