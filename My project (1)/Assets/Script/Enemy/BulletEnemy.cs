using UnityEngine;
using UnityEngine.InputSystem;

public class BulletEnemy : MonoBehaviour
{
    //攻撃用
    private bool Encounter = false;
    private bool ap = false;
    public bool attack = false;      //攻撃
    private bool attacknow;          //弾を一発だけにする用
    public bool apeffect = false;    //攻撃前エフェクトフラグ
    public GameObject BulletPrefab;  //弾のプレハブ
    public GameObject muzzle;        //銃口
    private GameObject bullet;       //弾のオブジェクト
    public GameObject apeffectObj;   //攻撃前のエフェクト
    public GameObject target;        //ターゲット
    public const int power = 10;
    public float bulletSpeed;

    public const int hp = 10;
    public const int bullet_money = 50;
    public GameObject money;

    //クールタイム
    public int Count; //攻撃までのカウントダウン

    Rigidbody rb; //リジッドボディ

    //他のスクリプト呼び出し
    public Player player;
    public Enemy enemy;
    EnemyAttack EAttack = new EnemyAttack();
    private void Start()
    {
        target = GameObject.Find("Player"); //プレイヤーオブジェクトを取得
        attack = false;
        enemy.enemyhp = hp;
        bulletSpeed = 10f;

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
            if (Encounter && Count == 0)//プレイヤーに向く
            {
                transform.LookAt(target.transform);
                ap = true;
                attacknow = false;

            }
            if (Encounter)//プレイヤーのいる方向に攻撃する
            {
                (ap, Encounter, attack, apeffect, Count) = EAttack.ThrustAttack(ap, Encounter);

            }
            if (attack && !attacknow)
            {
                //bulletオブジェクトをインスタンス化
                bullet = Instantiate(BulletPrefab, muzzle.transform.position, Quaternion.identity);
                rb = bullet.GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
                attacknow = true;
                Destroy(bullet, 3f);
            }
            apeffectObj.SetActive(apeffect); //攻撃前のエフェクト

        }
        //死亡
        if (enemy.enemyDeth)
        {
            Encounter = false;
            attack = false;
            enemy.money = bullet_money;
            money.SetActive(true);
        }
    }
}
