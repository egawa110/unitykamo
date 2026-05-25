using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class Enemy : MonoBehaviour
{
    private Vector3 Direction;
    private Vector3 m_StartPos;
    private bool Encounter = false;
    private bool Attack    = false;
    private const float posy = 1;

    public int enemyhp, Power;           //ステータス
    public GameObject ThrustAttack; //攻撃オブジェクト
    public GameObject ThrustEffect;
    //クールタイム
    const float Cooldown = 2500f;
    private float CoolTime;
    private float Count;
    //点滅用
    private bool isvisible = true;

    public GameObject EnemyObj;
    public Player player;
    public WarpSwitch wp;
    Effect ef = new Effect(); //ダメージを受けた時に点滅する

    enum EStatus //初期ステータス
    {
        HP = 50,
        Power = 10,
    }

    void Start()
    {
        m_StartPos = transform.position; //最初の位置
        enemyhp = (int)EStatus.HP; Power = (int)EStatus.Power;

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
            if (Encounter && Count == 0)
            {
                //プレイヤーの位置を取得
                Direction = player.transform.position - transform.position;
                transform.forward = Direction; //プレイヤーの方を向く
                ThrustEffect.SetActive(true);
                Attack = true;
            }

            if (Attack)
            {
                CoolTime++;
                if (CoolTime == Cooldown)
                {
                    CoolTime = 0;
                    Count++;
                    ThrustEffect.SetActive(false);
                }
                if (Count == 1)
                {
                    ThrustAttack.SetActive(true);
                }
                if (Count == 2)
                {
                    ThrustAttack.SetActive(false);
                    Count = 0;
                    Attack = false;
                    Encounter = false;
                }
            }
        }

        //ダメージ受けた時に点滅エフェクト
        isvisible = ef.DamageEffect(isvisible, enemyhp);
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
