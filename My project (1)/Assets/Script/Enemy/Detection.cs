using System.Linq;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public TacklEnemy[] tackl_enemy;

    private void OnTriggerEnter(Collider other) //突進中の障害物判定
    {
        //突進敵
        foreach (var tackl in tackl_enemy)
        {
            if (tackl.Count != 0)//突進中のみ
            {
                if (other.CompareTag("Player"))
                {
                    tackl.player_flag = true;
                    Debug.Log("プレイヤーが近くにいる");
                }
                if (other.CompareTag("Wall"))
                {
                    tackl.wall_flag = true;
                }
                if (other.CompareTag("Enemy"))
                {
                    tackl.wall_flag = true;
                }
            }

        }

    }
    private void OnTriggerExit(Collider other)
    {
        //突進敵
        foreach (var tackl in tackl_enemy)
        {
            if (other.CompareTag("Player"))
            {
                tackl.player_flag = false;
            }
            if (other.CompareTag("Wall"))
            {
                tackl.wall_flag = false;
            }
            if (other.CompareTag("Enemy"))
            {
                tackl.wall_flag = false;
            }

        }

    }
}
