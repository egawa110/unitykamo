using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAnim : MonoBehaviour
{
    //アニメーション
    private Animator anim = null;

    public ThrustEnemy[] thrust_enemy;
    public TacklEnemy[] tackl_enemy;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        //突き攻撃アニメーション
        foreach (var en_th in thrust_enemy)
        {
            if (en_th.attack)
            {
                anim.SetBool("thrustAttack", true);
            }
            else
            {
                anim.SetBool("thrustAttack", false);
            }
        }
        //タックル攻撃アニメーション
        foreach (var en_ta in tackl_enemy)
        {
            if (en_ta.attack)
            {
                anim.SetBool("TacklAttack", true);
            }
            else
            {
                anim.SetBool("TacklAttack", false);
            }
        }


    }
}

