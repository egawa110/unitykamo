using UnityEngine;

public class MoneyObject : MonoBehaviour
{
    private Vector3 pos;
    public int money;

    public Enemy enemy;
    public MoveGround mg;

    void Start()
    {
        money = enemy.money;
        pos = enemy.transform.position;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHP"))
        {
            Money_text.money += money;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (enemy == null) return;
        else if (enemy.enemyDeth)
        {
            pos = enemy.transform.position;
            pos.y = mg.transform.position.y + 2;

            transform.position = pos;

        }
        else if(Player.pos_reset_flag == true)
        {
            Debug.Log("‚¨‹à‚ªŒ³‚É–ß‚é");
            transform.position = new Vector3(pos.x, 1, pos.z);

        }


    }
}
