using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHP : MonoBehaviour
{
    private Vector3 m_php;
    public Player player;

    private void Start()
    {
        m_php = transform.position;
    }
    void Update()
    {
        var current = Keyboard.current;  //現在のキーボード情報
        if (current == null) return;     //キーボード接続チェック
        var fKey = current.fKey; //Wキーの入力状態取得
        if (fKey.isPressed) player.hp = -10;

        //HP
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(player.hp, rt.sizeDelta.y);


    }
}
