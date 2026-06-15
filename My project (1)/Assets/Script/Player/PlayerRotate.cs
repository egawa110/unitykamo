using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerRotate : MonoBehaviour
{
    public Player player;
    public bool rotate_flag;

    private void Start()
    {
        rotate_flag = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground")) //Groundタグに触れた時
        {
            rotate_flag = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground")) //Groundタグに触れた時
        {
            rotate_flag = false;
        }
    }


    void Update()
    {
        var current = Keyboard.current;  //現在のキーボード情報
        if (current == null) return;     //キーボード接続チェック

        var rKey = current.rKey; //Wキーの入力状態取得
        if (rKey.isPressed && rotate_flag)
        {
            player.transform.eulerAngles = Vector3.zero;
        }
    }
}
