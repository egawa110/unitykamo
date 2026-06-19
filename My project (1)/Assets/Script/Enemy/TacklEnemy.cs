using UnityEngine;

public class TacklEnemy : MonoBehaviour
{
    //攻撃用
    private const float speed = 10.0f;
    private bool Encounter = false;   //敵が索敵範囲に入かどうか
    private bool ap = false;          //攻撃準備

    public const int hp = 50;
    public const int tackl_money = 100;
    public GameObject money;

    public bool  attack    = false;   //攻撃のアニメーションとオブジェクト用]
    public bool apeffect   = false;   //攻撃前のエフェクト
    public GameObject tacklAttack;    //攻撃オブジェクト
    public GameObject apeffectObj;    //攻撃前のエフェクト
    public GameObject target;         //ターゲット

    //判定フラグ
    public bool player_flag = false;
    public bool wall_flag = false;

    //クールタイム
    public int Count; //攻撃までのカウントダウン

    //他のスクリプト呼び出し
    public Player player;
    public Enemy enemy;
    EnemyAttack EAttack = new EnemyAttack();

    private void Start()
    {
        target = GameObject.Find("Player"); //プレイヤーオブジェクトを取得
        attack = false;
        enemy.enemyhp = hp;
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
        if (player.PlayerDeth == false)
        {
            if (Encounter && Count == 0)//プレイヤーの方を向く
            {
                transform.LookAt(target.transform);
                ap = true;
            }
            if (ap && !player_flag && !wall_flag)//突進
            {
                (ap, Encounter, attack, apeffect, Count, transform.position) = EAttack.TacklAttack(ap, Encounter, Count, transform.position, transform.forward, speed);
            }
            if (ap && player_flag || wall_flag) //障害物に当たると止まる
            {
                Encounter = false;
                attack = false;
                Count = 0;
                ap = false;
                EAttack.ResetAttack();
            }
            tacklAttack.SetActive(attack);
            apeffectObj.SetActive(apeffect);
        }
        //死亡
        if (enemy.enemyDeth)
        {
            Encounter = false;
            attack = false;
            enemy.money = tackl_money;
            money.SetActive(true);

        }


    }
}
