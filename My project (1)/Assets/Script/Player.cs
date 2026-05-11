using UnityEngine;
public class Player : MonoBehaviour
{
    public Vector3 PlayerPos;
    private Vector3 m_StartPos;

    //プレイヤーの動く速度
    const float m_LightSpeed = -3f;  //弱攻撃のスピード
    const float m_StrongSpeed = -7f;  //強攻撃のスピード

    public GameObject LightEffect;
    public GameObject StrongEffect;
    public GameObject StartPosition;  //スタート位置

    private int Php;
    public int PAttack;
    public bool PlayerDeth;

    public Enemy enemy;
    public GoalManager goal;

    enum m_PStatus
    {
        HP = 50,
        LightPower = 10,
        StrongPower = 20,
        Defense = 30,
    }

    void Start()
    {
        m_StartPos = StartPosition.transform.position; //スタート地点の位置を取得
        PlayerPos = m_StartPos;                         //プレイヤーの出発地点を設定
        transform.position = PlayerPos;
        Php = (int)m_PStatus.HP;
        PAttack = 0;
        PlayerDeth = false;
    }
    //void OnCollisionEnter(Collision collision)
    //{

    //    if (collision.gameObject.CompareTag("Enemy")) //EnemyTagに衝突時
    //    {
    //        Debug.Log("敵に衝突した");
    //        float impactPower = collision.relativeVelocity.magnitude;
    //        Debug.Log("衝突: " + impactPower);

    //        //Enemyに強攻撃
    //        if (collision.relativeVelocity.z < m_StrongSpeed ||
    //            collision.relativeVelocity.x < m_StrongSpeed) 
    //        {
    //            Debug.Log("敵に強攻撃");
    //            enemy.HP -= (int)PStatus.StrongPower;

    //        }
    //        //Enemyに弱攻撃
    //        else if (collision.relativeVelocity.z < m_LightSpeed ||
    //　　　　　　     collision.relativeVelocity.x < m_LightSpeed)
    //        {
    //            Debug.Log("敵に弱攻撃");
    //            enemy.HP -= (int)PStatus.LightPower;

    //        }


    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ThrustAttack")) //ThrustAttackTagに衝突時
        {
            Debug.Log("１０ダメージ受けた");
            Php -= enemy.Power;
        }
        if (other.CompareTag("Goal")) //Goalタグに触れた時
        {
            goal.isGoal = true;
        }
        if (other.CompareTag("HalfGoal")) //HalfGoalタグに触れた時
        {
            goal.GoalCount++;
        }

    }
    void Update()
    {
        //プレイヤーの動くスピード
        Vector3 velocity = GetComponent<Rigidbody>().linearVelocity;

                //強エフェクト表示
        if (velocity.x > -m_StrongSpeed || velocity.x < m_StrongSpeed ||
            velocity.z > -m_StrongSpeed || velocity.z < m_StrongSpeed)
        {
            StrongEffect.SetActive(true);
            LightEffect.SetActive(false);
            PAttack = (int)m_PStatus.StrongPower;

        }
        //弱エフェクト表示
        else if (velocity.x > -m_LightSpeed ||velocity.x < m_LightSpeed ||
            velocity.z > -m_LightSpeed || velocity.z < m_LightSpeed)
        {
            LightEffect.SetActive(true);
            StrongEffect.SetActive(false);
            PAttack = (int)m_PStatus.LightPower;
        }
        else
        {
            StrongEffect.SetActive(false);
            LightEffect.SetActive(false);
            PAttack = 0;
        }


        PlayerPos = transform.position; //Playerの位置

        //HPが0になると消える
        if (Php <= 0)
        {
            Destroy(gameObject);
            PlayerDeth = true;
        }

    }
}
