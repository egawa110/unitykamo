using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
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
    //突き攻撃用
    const float th_Cooldown = 2500f;
    const float th_Cooldown2 = 625f;
    //突進攻撃用
    const float ta_Cooldown = 2500f;
    const float ta_Cooldown2 = 400f;

    private float second = 0;
    public int Count; //攻撃までのカウントダウン

    bool attack = false;
    bool apeffect = false;

    public (bool, bool, bool, bool, int) ThrustAttack(bool ap, bool Encounter)
    {
        if (Encounter)
        {
            second++;
            if (second == th_Cooldown) //時間が来たらカウントを進める
            {
                second = 0;
                Count++;
            }
            if(second == 2000)
            {
                apeffect = true;
            }
            if (Count == 1)
            {
                attack = true;
                apeffect = false;
            }
            if (Count != 0 && second == th_Cooldown2)
            {
                Count = 0;
                attack = false;
                ap = false;
                Encounter = false;
            }
        }
        return (ap, Encounter, attack, apeffect, Count);
    }

    public (bool, bool,bool, bool, int, Vector3) TacklAttack(bool ap, bool Encounter, int count, Vector3 pos, Vector3 forward, float speed)
    {
        second++;
        if(second == 1000)
        {
            count += 1;
            second = 0;
        }
        if (second >= 500)
        {
            apeffect = true;
        }
        if (count == 1)
        {
            attack = true;
            apeffect = false;
            pos += forward * speed * Time.deltaTime;

        }
        if(count == 2)
        {
            count = 0;
            attack = false;
            Encounter = false;
            ap = false;
            ResetAttack();

        }
        return (ap, Encounter, attack, apeffect, count, pos);

    }

    public void ResetAttack() //secondを初期化
    {
        second = 0;
        attack = false;
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

