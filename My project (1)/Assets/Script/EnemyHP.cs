using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class EnemyHP : MonoBehaviour
{
    public Enemy enemy;
    public Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LightAttack"))
        {
            enemy.hp -= DamageCalculator.AttackDamage;
            Debug.Log("ìGÇ…ÇPÇOÉ_ÉÅÅ[ÉWó^Ç¶ÇΩ");

        }
        else if (other.CompareTag("StrongAttack"))
        {
            enemy.hp -= DamageCalculator.AttackDamage;
            Debug.Log("ìGÇ…ÇQÇOÉ_ÉÅÅ[ÉWó^Ç¶ÇΩ");

        }
    }
}
