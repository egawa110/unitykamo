using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHP : MonoBehaviour
{
    private Vector3 m_php;                //HPバーの位置
    private int m_hpber;                  //HP残量
    private const float m_damage = 10.5f; //HPバーをずらすため

    public Player player;
    private void Start()
    {
        m_php = transform.position;
        m_hpber = player.hp;
    }
    void Update()
    {
        var current = Keyboard.current;  //現在のキーボード情報
        if (current == null) return;     //キーボード接続チェック
        var fKey = current.fKey; //Wキーの入力状態取得
        if (fKey.wasPressedThisFrame) player.hp -= 10;
        //HPが減ったか確認
        if (player.hp != m_hpber) 
        {
            m_php.x -= m_damage; //HPバーの位置をずらす
            m_hpber = player.hp; //HP残量を合わせる
        }
        //HP
        RectTransform rt = GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(player.hp, rt.sizeDelta.y);
        transform.position = m_php;
    }
}
