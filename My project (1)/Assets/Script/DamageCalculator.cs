using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.InputSystem.LowLevel.InputStateHistory;

public class DamageCalculator : MonoBehaviour
{
    //プレイヤーのスピード
    const float m_lightspeed = 3f;
    const float m_strongspeed = 7f;
    //攻撃エフェクト用
    public static bool sflag = false; 
    public static bool lflag = false;
    //攻撃力
    public static int AttackDamage;
    //ダメージ受けた時
    public static int oldhp;
    public static int second;     
    public static int count;
    private const int maxcount = 2;
    private const int time = 60;
    private const int cooltime = 120;
    public static bool isvisible;
    enum pstatus
    {
        lightpower  = 10, //弱攻撃
        strongpower = 20, //強攻撃
    }

    private void Start()
    {
        AttackDamage = 0;
        isvisible = true;
    }

    public static void Attack(Vector3 velocity) //攻撃
    {
        //強攻撃
        if (Mathf.Abs(velocity.x) > m_strongspeed ||
            Mathf.Abs(velocity.z) > m_strongspeed)
        {
            sflag = true;
            lflag = false;
            AttackDamage = (int)pstatus.strongpower;
        }
        //弱攻撃
        else if (Mathf.Abs(velocity.x) > m_lightspeed ||
                 Mathf.Abs(velocity.z) > m_lightspeed)
        {
            sflag = false;
            lflag = true;
            AttackDamage = (int)pstatus.lightpower;
        }
        else
        {
            sflag = false;
            lflag = false;
            AttackDamage = 0;
        }
    }

    public static void DamageEffect(int hp)
    {
        //ダメージ受けた時のエフェクト
        if (oldhp != hp)
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
        else
        {
            oldhp = hp;
        }
    }
}
