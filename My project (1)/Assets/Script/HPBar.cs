using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    private const int maxhp = 100;

    public Slider hpSlider; //UIスライダー

    private void Start()
    {
        hpSlider.maxValue = maxhp;
        hpSlider.value = maxhp;
    }

    public int HPbar(int hp, int damage) //HPバー
    {
        hp -= damage;

        hpSlider.value = hp; //スライダーに今のHPを反映

        if (hp < 0) hp = 0;

        return hp;
    }
}
