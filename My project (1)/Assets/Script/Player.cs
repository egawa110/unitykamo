using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
public class Player : MonoBehaviour
{
    public Vector3 PlayerPos;       //プレイヤーの位置
    public Vector3 pRotate;    //プレイヤーの向き
    private Vector3 dir;
    Quaternion yaw;

    public GameObject LightEffect;    //弱攻撃
    public GameObject StrongEffect;   //強攻撃
    public GameObject StartPosition;  //スタート位置
    public GameObject PlayerObj;      //プレイヤー

    //攻撃エフェクト
    private bool sflag;
    private bool lflag;
    //点滅
    private bool isvisible;
    private bool invincible;

    public int hp;          //HP
    public int coin;        //コイン
    public bool PlayerDeth; //死亡フラグ
    private const int abyssdamage = 10;  //奈落に落ちた時のダメージ
    public bool abyssflag = false;

    private Rigidbody rb;
    //public Enemy enemy;
    public GoalManager goal;
    public WarpSwitch wp;
    public HPBar hpb;
    Effect ef = new Effect(); //ダメージを受けた時に点滅する

    enum m_PStatus
    {
        HP = 100,         //HP
        Defense = 30,     //防御力
    }

    void Start()
    {
        PlayerPos = StartPosition.transform.position; //スタート地点の位置を取得
        transform.position = PlayerPos;               //プレイヤーの位置
        transform.eulerAngles = Vector3.zero;         //プレイヤーの向き
        pRotate = transform.eulerAngles;
        hp = (int)m_PStatus.HP;                       //プレイヤーのHP
        coin = 0;                                     //コイン初期化
        PlayerDeth = false;                           //死亡フラグ
        rb = GetComponent<Rigidbody>();               //PlayerのRigidbodyを獲得
        sflag = false; lflag = false;　　　　　　　　 //攻撃エフェクト
        //攻撃を受けた時
        isvisible = true;
        invincible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!invincible)
        {
            if (other.CompareTag("ThrustAttack")) //ThrustAttackTagに衝突時
            {
                Debug.Log("１０ダメージ受けた");
                hp = hpb.HPbar(hp, Enemy.power);
            }
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
                hp = hpb.HPbar(hp, abyssdamage);//HPバーにダメージを反映

            }
        }
        else if (!other.CompareTag("Abyss") && abyssflag)
        {
            Debug.Log("ステージの上");
            abyssflag = false;
        }

    }

    void Update()
    {
        //プレイヤーの動くスピード
        Vector3 velocity = GetComponent<Rigidbody>().linearVelocity;
        //プレイヤーの向き変更
        float h = Input.GetAxisRaw("Horizontal"); // A/D
        float v = Input.GetAxisRaw("Vertical");   // W/S
        dir = new Vector3(h, 0, v).normalized; //プレイヤーの向きを動かす用


        if (dir.magnitude > 0)
        {
            yaw = Quaternion.LookRotation(dir);
        }
        //攻撃
        sflag = DamageCalculator.StrongAttack(velocity, sflag);
        lflag = DamageCalculator.LightAttack(velocity, lflag);
        StrongEffect.SetActive(sflag);
        LightEffect.SetActive(lflag);

        //ダメージ受けた時に点滅エフェクト
        (isvisible,invincible) = ef.DamageEffect(isvisible, hp);
        PlayerObj.SetActive(isvisible);

        //HPが0になると消える
        if (hp <= 0)
        {
            Destroy(gameObject);
            PlayerDeth = true;
        }
        //ワープ
        if(wp.WarpFlag || abyssflag)
        {
            rb.linearVelocity = Vector3.zero;  //直線の慣性をリセット
            rb.angularVelocity = Vector3.zero;  //回転の慣性をリセット
        }
        PlayerPos = transform.position; //Enemyに渡すPlayerの位置
        pRotate.x = transform.eulerAngles.x;
        pRotate.y = yaw.eulerAngles.y;
        pRotate.z = transform.eulerAngles.z;

        transform.eulerAngles = pRotate; //プレイヤーが浮かないように
    }
}
