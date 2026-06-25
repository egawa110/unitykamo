using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class Money_text : MonoBehaviour
{
    public Text MoneyText;
    public static int money;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var current = Keyboard.current;  //現在のキーボード情報
        if (current == null) return;     //キーボード接続チェック

        var mKey = current.mKey; //Wキーの入力状態取得
        if (mKey.isPressed)
        {
            money += 100000;
        }
        //所持金
        MoneyText.text = "G:" + money;

    }
}
