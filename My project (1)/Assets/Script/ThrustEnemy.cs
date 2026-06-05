using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ThrustEnemy : MonoBehaviour
{
    //攻撃用
    private bool Encounter = false;
    private bool ap = false;
    public bool attack = false;
    public GameObject thrustAttack;  //攻撃オブジェクト
    public GameObject target;        //ターゲット

    //クールタイム
    public int Count; //攻撃までのカウントダウン

    //アニメーション
    private Animator anim = null;

    //他のスクリプト呼び出し
    public Player player;
    public Enemy enemy;
    EnemyAttack EAttack = new EnemyAttack();
    private void Start()
    {
        target = GameObject.Find("Player"); //プレイヤーオブジェクトを取得
        anim = GetComponent<Animator>();

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
            }
            if (Encounter)//プレイヤーのいる方向に攻撃する
            {
                (ap, Encounter, attack, Count) = EAttack.ThrustAttack(ap, Encounter);

            }
            thrustAttack.SetActive(attack);
            anim.SetBool("isAttack", attack);

        }
    }
}
