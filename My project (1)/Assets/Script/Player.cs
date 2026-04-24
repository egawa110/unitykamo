using UnityEngine;
public class Player : MonoBehaviour
{
    public Vector3 m_Player;
    public float x, y, z;

    //プレイヤーの動く速度
    const float m_LightSpeed = -3f;  //弱攻撃のスピード
    const float m_StrongSpeed = -7f;  //強攻撃のスピード
    public GameObject LightEffect;
    public GameObject StrongEffect;

    public Enemy enemy;

    enum PStatus
    {
        HP = 50,
        LightPower = 10,
        StrongPower = 20,
        Defense = 30,
    }

    void Start()
    {
        x = 0; y = 2; z = 0;
        m_Player = new Vector3(x, y, z);
        transform.position = m_Player;

    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy")) //EnemyTagに衝突時
        {
            Debug.Log("敵に衝突した");
            float impactPower = collision.relativeVelocity.magnitude;
            Debug.Log("衝突: " + impactPower);

            //Enemyに強攻撃
            if (collision.relativeVelocity.z < m_StrongSpeed ||
                collision.relativeVelocity.x < m_StrongSpeed) 
            {
                Debug.Log("敵に強攻撃");
                enemy.HP -= (int)PStatus.StrongPower;

            }
            //Enemyに弱攻撃
            else if (collision.relativeVelocity.z < m_LightSpeed ||
    　　　　　　     collision.relativeVelocity.x < m_LightSpeed)
            {
                Debug.Log("敵に弱攻撃");
                enemy.HP -= (int)PStatus.LightPower;

            }


        }
    }

    void Update()
    {
        //プレイヤーの動くスピード
        Vector3 velocity = GetComponent<Rigidbody>().linearVelocity;

        //弱エフェクト表示
        if (velocity.x > -m_LightSpeed ||velocity.x < m_LightSpeed ||
            velocity.z > -m_LightSpeed || velocity.z < m_LightSpeed)
        {
            LightEffect.SetActive(true);
        }
        else
        {
            LightEffect.SetActive(false);
        }
        //強エフェクト表示
        if (velocity.x > -m_StrongSpeed ||velocity.x < m_StrongSpeed ||
            velocity.z > -m_StrongSpeed || velocity.z < m_StrongSpeed)
        {
            StrongEffect.SetActive(true);
        }
        else
        {
            StrongEffect.SetActive(false);
        }


        m_Player = transform.position; //Playerの位置
    }
}
