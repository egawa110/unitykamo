using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    int maxhp;

    public Slider hpSlider; //UIスライダー
    public Player player;

    private void Start()
    {
        maxhp = player.hp;
        hpSlider.maxValue = maxhp;
        hpSlider.value = maxhp;
        Debug.Log(maxhp);

    }

    public void HPbar(int hp) //HPバー
    {
        hpSlider.value = hp; //スライダーに今のHPを反映

        if (hp < 0) hp = 0;
    }
}
