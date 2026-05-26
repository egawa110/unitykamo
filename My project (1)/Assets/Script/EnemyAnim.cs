using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAnim : MonoBehaviour
{
    //アニメーション
    private Animator anim = null;

    public Enemy enemy;
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        var current = Keyboard.current;  //現在のキーボード情報
        if (current == null) return;     //キーボード接続チェック

        var fKey = current.fKey; //Wキーの入力状態取得

        if (enemy.attack)
        {
            anim.SetBool("isAttack", true);

        }
        else
        {
            anim.SetBool("isAttack", false);

        }

    }
}

