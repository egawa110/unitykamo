using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class MoneyObject : MonoBehaviour
{
    private Vector3 pos;
    public int money;

    public Enemy enemy;
    public MoveGround mg;
    void Start()
    {
        money = enemy.money;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StatusButton.money = money;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        pos = enemy.transform.position;
        pos.y = mg.transform.position.y + 2;

        transform.position = pos;

    }
}
