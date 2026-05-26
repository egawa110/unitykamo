using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class Enemy : MonoBehaviour
{
    private Vector3 Direction;
    private Vector3 m_StartPos;
    //Yの位置初期化用
    private const float posy = 1;
    //攻撃用
    private bool Encounter = false;
    private bool ap = false;
    public bool attack = false;
    public GameObject ThrustAttack; //攻撃オブジェクト
    //クールタイム
    public int Count; //攻撃までのカウントダウン
    //ステータス
    public int enemyhp;
    public const int power = 10;
    //点滅用
    private bool isvisible = true;
    public bool invincible = false;
    //他のスクリプト呼び出し
    public GameObject EnemyObj;
    public Player player;
    public WarpSwitch wp;
    Effect ef = new Effect(); //ダメージを受けた時に点滅する
    EnemyAttack eattack = new EnemyAttack();

    enum EStatus //初期ステータス
    {
        HP = 150,
        Power = 10,
    }

    void Start()
    {
        m_StartPos = transform.position; //最初の位置
        enemyhp = (int)EStatus.HP; //ステータスの初期化
        Direction = Vector3.zero; //回転の初期化
        transform.eulerAngles = Direction;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Encounter = true;
            Debug.Log("プレイヤーが近くにいる");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("プレイヤーが離れた");
        }

    }

    void Update()
    {
        if(player.PlayerDeth == false)
        {
            if (Encounter && Count == 0)//プレイヤーに向く
            {
                //プレイヤーの位置を取得
                Direction = player.transform.position - transform.position;
                transform.forward = Direction; //プレイヤーの方を向く
                ap = true;
            }
            if(ap)//プレイヤーのいる方向に攻撃する
            {
                (ap, Encounter, attack,Count) = eattack.ThrustAttack(ap, Encounter);
            }
            ThrustAttack.SetActive(attack);
        }

        //ダメージ受けた時に点滅エフェクト
        (isvisible, invincible) = ef.DamageEffect(isvisible, enemyhp);
        EnemyObj.SetActive(isvisible);

        //HPが0になると消える
        if (enemyhp <= 0)
        {
            Destroy(gameObject);
        }
        //ワープ
        if (wp.WarpFlag == true || player.abyssflag == true)
        {
            Debug.Log("敵の位置を初期化した");
            transform.eulerAngles = Vector3.zero;
            transform.position = new Vector3(m_StartPos.x, posy, m_StartPos.z);
        }
    }
}
