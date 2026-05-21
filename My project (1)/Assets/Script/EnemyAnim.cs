using UnityEngine;
using UnityEngine.InputSystem;

public class EnemyAnim : MonoBehaviour
{
    //アニメーション
    private Animator anim = null;
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
        var aKey = current.aKey; //Aキーの入力状態取得
        var sKey = current.sKey; //Sキーの入力状態取得
        var dKey = current.dKey; //Dキーの入力状態取得

        if (fKey.isPressed)
        {
            anim.SetBool("isAttack", true);

        }
        else
        {
            anim.SetBool("isAttack", false);

        }

    }
}
