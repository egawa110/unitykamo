using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 Direction;
    private bool Encounter = false;
    private bool Attack    = false;

    public int HP, Power; //ステータス
    public GameObject ThrustAttack; //攻撃オブジェクト
    public GameObject ThrustEffect; 

    //クールタイム
    const float Cooldown = 3000f;
    private float CoolTime;
    private float Count;

    enum EStatus //初期ステータス
    {
        HP = 20000000,
        Power = 10,
    }

    public Player player;

    void Start()
    {
        HP = (int)EStatus.HP; Power = (int)EStatus.Power;

        Direction = Vector3.zero;
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
            Encounter = false;
            Debug.Log("プレイヤーが離れた");
        }

    }

    void Update()
    {
        if (Encounter && !Attack)
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
            if(CoolTime == Cooldown)
            {
                CoolTime = 0;
                Count++;
                ThrustEffect.SetActive(false);
                ThrustAttack.SetActive(true);
            }
            if(Count == 2)
            {
                Count = 0;
                ThrustAttack.SetActive(false);
                Attack = false;
            }
        }

        //HPが0になると消える
        if (HP <= 0)
        {
            Destroy(gameObject);
        }

    }
}
