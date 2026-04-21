using UnityEngine;
public class Player : MonoBehaviour
{
    enum PStatus
    {
        HP = 50,
        Power = 10,
        Power2 = 20,
        Defense = 30,
    }
    public Vector3 mPlayer;
    public float x, y, z;
    const float AttackSpeed = -3f;
    //プレイヤーの動く速度
    const float MoveSpeed = -3f;
    public GameObject Affects;

    public Enemy enemy;
    void Start()
    {
        x = 0; y = 2; z = 0;
        mPlayer = new Vector3(x, y, z);
        transform.position = mPlayer;

    }
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy")) //EnemyTagに衝突時
        {
            Debug.Log("敵に衝突した");
            float impactPower = collision.relativeVelocity.magnitude;
            Debug.Log("衝突: " + impactPower);
            //Enemyに強攻撃
            if (collision.relativeVelocity.z < -7f||
                collision.relativeVelocity.x < -7f) 
            {
                Debug.Log("敵に強攻撃");
                enemy.HP -= (int)PStatus.Power2;

            }
            //Enemyに弱攻撃
            else if (collision.relativeVelocity.z < AttackSpeed ||
    　　　　　　     collision.relativeVelocity.x < AttackSpeed)
            {
                Debug.Log("敵に弱攻撃");
                enemy.HP -= (int)PStatus.Power;

            }


        }
    }

    void Update()
    {

        Vector3 velocity = GetComponent<Rigidbody>().linearVelocity;
        if(velocity.x > -MoveSpeed ||
           velocity.x < MoveSpeed)
        {
            Affects.SetActive(true);
        }
        else
        {
            Affects.SetActive(false);
        }
        mPlayer = transform.position; //Playerの位置
    }
}
