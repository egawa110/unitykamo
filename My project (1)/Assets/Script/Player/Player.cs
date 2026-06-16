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
    public GameObject DamageEffect;
    private bool isvisible;
    private bool invincible;
    //ステータス------------
    public int hp;   //HP
    public int strongPower; //強攻撃
    public int lightPower;  //弱攻撃
    public int defense;     //防御
    //-----------------------
    public int coin;        //コイン
    public bool PlayerDeth; //死亡フラグ
    public bool abyssflag;

    private Rigidbody rb;
    public GoalManager goal;
    Effect ef = new Effect(); //ダメージを受けた時に点滅する
    public WarpSwitch[] wp;
    enum m_PStatus
    {
        HP = 100,         //HP
        lightpower = 10, //弱攻撃
        strongpower = 20, //強攻撃
        Defense = 0,

    }
    void Awake() //Startより早く呼ばれる
    {
        hp = (int)m_PStatus.HP + StatusButton.shop_hp;                               //hp

    }
    void Start()
    {
        PlayerPos = StartPosition.transform.position; //スタート地点の位置を取得
        transform.position = PlayerPos;               //プレイヤーの位置
        transform.eulerAngles = Vector3.zero;         //プレイヤーの向き
        pRotate = transform.eulerAngles;
        //プレイヤーステータス----------------------
        strongPower = (int)m_PStatus.strongpower + StatusButton.shop_strongPower;    //強攻撃
        lightPower = (int)m_PStatus.lightpower + StatusButton.shop_lightPower;       //弱攻撃
        //------------------------------------------
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
        if (other.CompareTag("Goal")) //Goalタグに触れた時
        {
            goal.isGoal = true;
        }
        if (other.CompareTag("HalfGoal")) //HalfGoalタグに触れた時
        {
            goal.GoalCount++;
        }
        if (other.CompareTag("Startpos"))
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
        sflag = DamageCalculator.StrongAttack(velocity, sflag, strongPower);
        lflag = DamageCalculator.LightAttack(velocity, lflag, lightPower);
        StrongEffect.SetActive(sflag);
        LightEffect.SetActive(lflag);

        //ダメージ受けた時に点滅エフェクト
        (isvisible,invincible) = ef.DamageEffect(isvisible, hp);
        PlayerObj.SetActive(isvisible);
        DamageEffect.SetActive(!isvisible);

        //HPが0になると消える
        if (hp <= 0)
        {
            Destroy(gameObject);
            PlayerDeth = true;
        }
        //ワープ
        foreach (var ws in wp)
        {
            if (ws.WarpFlag == true)
            {
                rb.linearVelocity = Vector3.zero;  //直線の慣性をリセット
                rb.angularVelocity = Vector3.zero;  //回転の慣性をリセット
            }
        }
        if (abyssflag)
        {
            //スタート地点 ＆ 復帰地点
            PlayerPos = StartPosition.transform.position; //スタート地点の位置を取得
            transform.position = PlayerPos;               //プレイヤーの位置

            //transform.position = startpos;
            transform.eulerAngles = Vector3.zero;
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
