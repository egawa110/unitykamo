using UnityEngine;

public class BreakWall : MonoBehaviour
{
    const int m_WallHP = 20;
    private int m_HP;

    public Player player;
    void Start()
    {
        m_HP = m_WallHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("LightAttack"))
        {
            m_HP -= DamageCalculator.AttackDamage;
            Debug.Log("ï«Ç…ÇPÇOÉ_ÉÅÅ[ÉWó^Ç¶ÇΩ");

        }
        if (other.CompareTag("StrongAttack"))
        {
            m_HP -= DamageCalculator.AttackDamage;
            Debug.Log("ï«Ç…ÇQÇOÉ_ÉÅÅ[ÉWó^Ç¶ÇΩ");
        }
    }

    void Update()
    {
        if (m_HP <= 0) Destroy(gameObject); 
    }
}
