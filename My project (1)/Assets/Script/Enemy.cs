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
    private float posy;

    public int hp, Power;           //ステータス
    public GameObject ThrustAttack; //攻撃オブジェクト
    public GameObject ThrustEffect;

    //クールタイム
    const float Cooldown = 2500f;
    private float CoolTime;
    private float Count;

    //ダメージエフェクト用
    public int oldhp;
    private int blinkcount;
    private int blinksecond;
    private const int time = 60;
    private const int cooltime = 120;
    private const int maxcount = 2;

    public GameObject EnemyObj;
    public Player player;
    public WarpSwitch wp;

    enum EStatus //初期ステータス
    {
        HP = 50,
        Power = 10,
    }

    void Start()
    {
        m_StartPos = transform.position; //最初の位置
        posy = transform.position.y; 
        hp = (int)EStatus.HP; Power = (int)EStatus.Power;

        Direction = Vector3.zero; //回転の初期化
        transform.eulerAngles = Direction;

        oldhp = hp; //初期HPを保存
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
        //ダメージエフェクト
        if (oldhp != hp)
        {
            blinksecond++;
            EnemyObj.SetActive(false);
            if (blinkcount == maxcount) //２回カウントすると解除
            {
                EnemyObj.SetActive(true);
                oldhp = hp;
                blinkcount = 0;
                blinksecond = 0;
            }
            else if (blinksecond >= time) //２回点滅する
            {
                EnemyObj.SetActive(true);
                if (blinksecond >= cooltime)
                {
                    blinkcount++;
                    blinksecond = 0;
                }
            }
        }

        //HPが0になると消える
        if (hp <= 0)
        {
            Destroy(gameObject);
        }

        //ワープ
        if(wp.WarpFlag == true || player.abyssflag == true)
        {
            transform.position = new Vector3(m_StartPos.x, posy, m_StartPos.z);
        }
    }
}
