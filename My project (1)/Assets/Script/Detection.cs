using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Detection : MonoBehaviour
{
    public TacklEnemy enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //enemy.player_flag = true;
            //enemy.not_tackl = true;
            Debug.Log("ÉvÉåÉCÉÑÅ[Ç™ãﬂÇ≠Ç…Ç¢ÇÈ");
        }
        if (other.CompareTag("Wall"))
        {
            enemy.wall_flag = true;
            enemy.not_tackl = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.player_flag = false;
            enemy.not_tackl = false;

        }
        if (other.CompareTag("Wall"))
        {
            enemy.wall_flag = false;
            enemy.not_tackl = false;
        }

    }

}
