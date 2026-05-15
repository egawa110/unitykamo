using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class HPBar : MonoBehaviour
{
    private int currenthp; //現在のHP  
    private const int maxhp = 100;

    public Slider hpSlider; //UIスライダー

    private void Start()
    {
        currenthp = maxhp;
        hpSlider.maxValue = maxhp;
        hpSlider.value = currenthp;
    }
    public void HPbar(int hp, int damage) //HPバー
    {
        currenthp = maxhp;
        currenthp -= damage;

        hpSlider.value = currenthp;

        if (currenthp < 0) currenthp = 0;

        if(hp <= 0) hp = 0;
    }
}
