using UnityEngine;
public class Player : MonoBehaviour
{
    public Vector3  PlayerPos;      //プレイヤーの位置
    public Vector3 PlayerRotate;    //プレイヤーの向き

    //プレイヤーの動く速度
    const float m_LightSpeed  = -3f;  //弱攻撃のスピード
    const float m_StrongSpeed = -7f;  //強攻撃のスピード

    public GameObject LightEffect;    //弱攻撃
    public GameObject StrongEffect;   //強攻撃
    public GameObject StartPosition;  //スタート位置
    public GameObject PlayerObj;      //プレイヤー

    public int hp;          //HP
    public int PAttack;     //攻撃力
    public bool PlayerDeth; //死亡フラグ
    private int oldhp;      //元々のHP
    private int second;     //ダメージ受けた時の点滅
    private int count;
    private const int time = 60;
    private const int cooltime = 120;
    private const int maxcount = 2;
    private const int abyssdamage = 10;  //奈落に落ちた時のダメージ
    public bool abyssflag = false;

    private Rigidbody rb;
    public Enemy enemy;
    public GoalManager goal;
    public WarpSwitch wp;
    public HPBar hpb;
    enum m_PStatus
    {
        HP = 100,          //HP
        LightPower = 10,  //弱攻撃
        StrongPower = 20, //強攻撃
        Defense = 30,     //防御力
    }

    void Start()
    {
        PlayerPos = StartPosition.transform.position; //スタート地点の位置を取得
        transform.position = PlayerPos;               //プレイヤーの位置
        transform.eulerAngles = Vector3.zero;         //プレイヤーの向き
        hp = (int)m_PStatus.HP;                       //プレイヤーのHP
        oldhp = hp;                                   //元々のHPを保存
        PAttack = 0;                                  //プレイヤーの攻撃
        PlayerDeth = false;                           //死亡フラグ
        rb = GetComponent<Rigidbody>();               //PlayerのRigidbodyを獲得
        second = 0;
        count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ThrustAttack")) //ThrustAttackTagに衝突時
        {
            Debug.Log("１０ダメージ受けた");
            hp -= enemy.Power;
            hpb.HPbar(hp, enemy.Power);
        }
        if (other.CompareTag("Goal")) //Goalタグに触れた時
        {
            goal.isGoal = true;
        }
        if (other.CompareTag("HalfGoal")) //HalfGoalタグに触れた時
        {
            goal.GoalCount++;
        }
        if (other.CompareTag("Abyss"))
        {
            abyssflag = true;
            if (hp != 0) //HPが０じゃない場合はスタート地点に戻す
            {
                transform.position = StartPosition.transform.position;
                transform.eulerAngles = Vector3.zero;
                rb.linearVelocity = Vector3.zero;  //直線の慣性をリセット
                rb.angularVelocity = Vector3.zero;  //回転の慣性をリセット

                hp -= abyssdamage;
                hpb.HPbar(hp, abyssdamage);

            }
            else if(hp == 0)
                PlayerDeth = true;
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
        
        //ダメージエフェクト
        if(oldhp != hp)
        {
            second++;
            PlayerObj.SetActive(false);
            if (count == maxcount)  //２回カウントすると解除
            {
                PlayerObj.SetActive(true);
                oldhp = hp;
                count = 0;
                second = 0;
            }
            else if (second >= time) //２回点滅する
            {
                PlayerObj.SetActive(true);
                if(second >= cooltime)
                {
                    count++;
                    second = 0;
                }
            }
        }

        //HPが0になると消える
        if (hp <= 0)
        {
            Destroy(gameObject);
            PlayerDeth = true;
        }

        //ワープ
        if(wp.WarpFlag == true)
        {
            rb.linearVelocity = Vector3.zero;  //直線の慣性をリセット
            rb.angularVelocity = Vector3.zero;  //回転の慣性をリセット
        }

        PlayerPos = transform.position; //Enemyに渡すPlayerの位置
        //m_PlayerRotate = transform.eulerAngles;
        //transform.eulerAngles = PlayerRotate; //プレイヤーの向き
    }
}
