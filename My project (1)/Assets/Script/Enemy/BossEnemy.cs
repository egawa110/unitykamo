using UnityEngine;
using UnityEngine.UI;
public class BossEnemy : MonoBehaviour
{
    //攻撃用
    private bool Encounter = false;
    private bool ap = false;
    public bool thrust_attack = false;
    public bool around_attack = false;
    public bool tackl_attack = false;
    public bool around_anim = false;
    public bool apeffect = false;
    public GameObject thrustAttack;  //突き攻撃
    public GameObject aroundAttack;  //周囲攻撃
    public GameObject apeffectObj;   //攻撃前エフェクト
    public GameObject target;        //ターゲット
    //ステータス
    public const int hp = 1000;
    public const int boss_money = 1000;
    public GameObject money;
    public Slider hpSlider; //UIスライダー
    int maxhp;

    //public const int thrust_power = 10; 

    //クールタイム
    public int Count; //攻撃までのカウントダウン
    //判定フラグ
    public float distance;

    //他のスクリプト呼び出し
    public Player player;
    public Enemy enemy;
    EnemyAttack EAttack = new EnemyAttack();

    void Start()
    {
        target = GameObject.Find("Player"); //プレイヤーオブジェクトを取得
        thrust_attack = false;
        enemy.enemyhp = hp;
        //HPバー
        maxhp = hp;
        hpSlider.maxValue = maxhp;
        hpSlider.value = maxhp;

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
            //if (Encounter && Count == 0)//プレイヤーに向く
            if (Encounter && ap == false)//プレイヤーに向く
            {
                transform.LookAt(target.transform);
            }
            if (Encounter)//プレイヤーのいる方向に攻撃する
            {
                //1攻撃
                (ap, Encounter, thrust_attack, around_attack, around_anim, apeffect, Count) = EAttack.Boss_Attack(ap, Encounter);

            }
            thrustAttack.SetActive(thrust_attack); //突き攻撃
            aroundAttack.SetActive(around_attack); //周囲攻撃
            apeffectObj.SetActive(apeffect);       //攻撃前エフェクト
            //プレイヤーとの距離
            distance = Vector3.Distance(player.transform.position, transform.position);
            //Debug.Log(distance);
        }

        hpSlider.value = enemy.enemyhp; //スライダーに今のHPを反映

        //死亡
        if (enemy.enemyDeth)
        {
            Encounter = false;
            thrust_attack = false;
            enemy.money = boss_money;
            money.SetActive(true);
            Destroy(hpSlider.gameObject);
        }
    }
}
