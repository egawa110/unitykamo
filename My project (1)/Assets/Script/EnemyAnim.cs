using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAnim : MonoBehaviour
{
    //アニメーション
    private Animator anim = null;

    public ThrustEnemy enemy_thrust;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    void Update()
    {
        var current = Keyboard.current;  //現在のキーボード情報
        if (current == null) return;     //キーボード接続チェック

        var fKey = current.fKey; //Wキーの入力状態取得

        if (enemy_thrust.attack)
        {
            anim.SetBool("isAttack", true);

        }
        else
        {
            anim.SetBool("isAttack", false);

        }

    }
}

