using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class DamageCalculator : MonoBehaviour
{
    //プレイヤーのスピード
    const float m_lightspeed = 3f;
    const float m_strongspeed = 7f;
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

public class Effect
{
    //ダメージ受けた時
    private int oldhp = 0;
    private int second;
    private int count;
    private const int maxcount = 2;
    private const int time = 60;
    private const int cooltime = 120;

    public bool DamageEffect(bool isvisible, int hp)
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
            if (count == maxcount)  //２回カウントすると解除
            {
                isvisible = true;
                oldhp = hp;
                count = 0;
                second = 0;
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

        return isvisible;
    }

}