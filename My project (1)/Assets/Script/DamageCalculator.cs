using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class DamageCalculator : MonoBehaviour
{
    //プレイヤーのスピード
    const float m_lightspeed = 7f;
    const float m_strongspeed = 10f;
    //攻撃力
    public static int AttackDamage;
    enum pstatus
    {
        lightpower  = 10, //弱攻撃
        strongpower = 20, //強攻撃
    }

    private void Start()
    {
        AttackDamage = 0;
    }

    public static bool StrongAttack(Vector3 velocity, bool strongflag) //強攻撃
    {
        //強攻撃
        if (Mathf.Abs(velocity.x) > m_strongspeed ||
            Mathf.Abs(velocity.z) > m_strongspeed)
        {
            strongflag = true;
            AttackDamage = (int)pstatus.strongpower;
        }
        else if (Mathf.Abs(velocity.x) > m_lightspeed ||
                 Mathf.Abs(velocity.z) > m_lightspeed)
        {
            strongflag = false;
        }
        else
        {
            strongflag = false;
            AttackDamage = 0;
        }
        return strongflag;
    }
    public static bool LightAttack(Vector3 velocity, bool lightflag) //弱攻撃
    {
        //強攻撃
        if (Mathf.Abs(velocity.x) > m_strongspeed ||
            Mathf.Abs(velocity.z) > m_strongspeed){
            lightflag = false;
        }
        else if (Mathf.Abs(velocity.x) > m_lightspeed ||
            Mathf.Abs(velocity.z) > m_lightspeed)
        {
            lightflag = true;
            AttackDamage = (int)pstatus.strongpower;
        }
        else
        {
            lightflag = false;
            AttackDamage = 0;
        }
        return lightflag;
    }


}

public class EnemyAttack
{
    //クールタイム
    const float Cooldown = 2500f;
    const float Cooldown2 = 625f;
    private float second = 0;
    public int Count; //攻撃までのカウントダウン

    bool attack = false;

    public (bool, bool, bool, int) ThrustAttack(bool ap, bool Encounter)
    {
        if (Encounter)
        {
            second++;
            if (second == Cooldown) //時間が来たらカウントを進める
            {
                second = 0;
                Count++;
            }
            if (Count == 1)
            {
                attack = true;
            }
            if (Count != 0 && second == Cooldown2)
            {
                Count = 0;
                attack = false;
                ap = false;
                Encounter = false;
            }
        }
        return (ap, Encounter, attack, Count);
    }

    public int TacklAttack()
    {

        return 0;
    }

}

public class Effect
{
    //ダメージ受けた時
    private int oldhp = 0;
    private int second;
    private int count;
    private const int maxcount = 2;
    private const int time = 60;
    private const int cooltime = 120;
    private bool Invincible = false; //無敵時間

    public (bool, bool) DamageEffect(bool isvisible, int hp)
    {
        if (oldhp == 0)
        {
            oldhp = hp;
        }
        //ダメージ受けた時のエフェクト
        else if (oldhp != hp)
        {
            second++;
            isvisible = false;
            Invincible = true;
            if (count == maxcount)  //２回カウントすると解除
            {
                isvisible = true;
                Invincible = false;
                oldhp = hp;
                count = 0;
                second = 0;
                Debug.Log("無敵が解除された");
            }
            else if (second >= time) //２回点滅する
            {
                isvisible = true;
                if (second >= cooltime)
                {
                    count++;
                    second = 0;
                }
            }
        }

        return (isvisible, Invincible);
    }

}