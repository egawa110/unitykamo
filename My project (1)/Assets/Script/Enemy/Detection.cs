using UnityEngine;

public class Detection : MonoBehaviour
{
    public TacklEnemy enemy;

    private void OnTriggerEnter(Collider other) //突進中の障害物判定
    {
        if(enemy.Count != 0)//突進中のみ
        {
            if (other.CompareTag("Player"))
            {
                enemy.player_flag = true;
                Debug.Log("プレイヤーが近くにいる");
            }
            if (other.CompareTag("Wall"))
            {
                enemy.wall_flag = true;
            }
            if (other.CompareTag("Enemy"))
            {
                enemy.wall_flag = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.player_flag = false;

        }
        if (other.CompareTag("Wall"))
        {
            enemy.wall_flag = false;
        }
        if (other.CompareTag("Enemy"))
        {
            enemy.wall_flag = false;
        }

    }
}
