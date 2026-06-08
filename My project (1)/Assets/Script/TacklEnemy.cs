using UnityEngine;

public class TacklEnemy : MonoBehaviour
{
    //攻撃用
    private const float speed = 10.0f;
    private bool Encounter = false;   //敵が索敵範囲に入かどうか
    public bool  attack    = false;   //攻撃時のアニメーションとオブジェクト用
    public GameObject tacklAttack;    //攻撃オブジェクト
    public GameObject target;         //ターゲット

    //クールタイム
    public int Count; //攻撃までのカウントダウン

    //他のスクリプト呼び出し
    public Player player;
    public Enemy enemy;
    EnemyAttack EAttack = new EnemyAttack();

    private void Start()
    {
        target = GameObject.Find("Player"); //プレイヤーオブジェクトを取得
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
            }
            if (Encounter)//プレイヤーのいる方向に攻撃する
            {
                (Encounter, attack, Count, transform.position) = EAttack.TacklAttack(Encounter, transform.position, transform.forward, speed);
            }
            tacklAttack.SetActive(attack);

        }
    }
}
