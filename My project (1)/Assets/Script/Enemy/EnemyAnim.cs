using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAnim : MonoBehaviour
{
    //アニメーション
    private Animator anim = null;

    public ThrustEnemy[] thrust_enemy;
    public TacklEnemy[] tackl_enemy;
    public BulletEnemy[] bullet_enemy;
    public BossEnemy[] boss_enemy;
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
        //弾発射後アニメーション
        foreach (var en_bu in bullet_enemy)
        {
            if (en_bu.attack)
            {
                anim.SetBool("BulletAttack", true);
            }
            else
            {
                anim.SetBool("BulletAttack", false);
            }
        }
        //ボスアニメーション
        foreach (var boss in boss_enemy)
        {
            //突き攻撃
            if (boss.thrust_attack)
            {
                anim.SetBool("thrust_attack", true);
            }
            else
            {
                anim.SetBool("thrust_attack", false);
            }
            //周囲攻撃
            if (boss.around_anim)
            {
                anim.SetBool("around_attack", true);
            }
            else
            {
                anim.SetBool("around_attack", false);
            }

        }


    }
}

