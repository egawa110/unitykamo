using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 Direction;
    private float posy;
    private bool Encounter = false;
    private bool Attack    = false;

    public int HP, Power; //ステータス
    public GameObject ThrustAttack; //攻撃オブジェクト
    public GameObject ThrustEffect; 

    //クールタイム
    const float Cooldown = 2500f;
    private float CoolTime;
    private float Count;

    public Player player;

    enum EStatus //初期ステータス
    {
        HP = 20000000,
        Power = 10,
    }

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
            Debug.Log("プレイヤーが離れた");
        }

    }

    void Update()
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
            if(CoolTime == Cooldown)
            {
                CoolTime = 0;
                Count++;
                ThrustEffect.SetActive(false);
            }
            if (Count == 1)
            {
                ThrustAttack.SetActive(true);
            }
            if(Count == 2)
            {
                ThrustAttack.SetActive(false);
                Count = 0;
                Attack = false;
                Encounter = false;
            }
        }

        //HPが0になると消える
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
