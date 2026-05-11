using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public Enemy enemy;
    public Player player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LightAttack"))
        {
            enemy.HP -= player.PAttack;
            Debug.Log("“G‚É‚P‚Oƒ_ƒ[ƒW—^‚¦‚½");

        }
        else if (other.CompareTag("StrongAttack"))
        {
            enemy.HP -= player.PAttack;
            Debug.Log("“G‚É‚Q‚Oƒ_ƒ[ƒW—^‚¦‚½");

        }

    }
}
