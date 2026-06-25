using UnityEngine;
using UnityEngine.UI;

public class HealButton : MonoBehaviour
{
    public static int potion1;
    public static int potion2;
    public static int potion3;

    public static int potion1_price = 100;
    public static int potion2_price = 500;
    public static int potion3_price = 1000;

    public Text[] have_potion1_Text;
    public Text[] have_potion2_Text;
    public Text[] have_potion3_Text;

    public Text[] potion1_priceText;
    public Text[] potion2_priceText;
    public Text[] potion3_priceText;


    void Start()
    {
        
    }

    public void potion1_button()
    {
        if (Money_text.money >= potion1_price)
        {
            potion1 += 1;
            Money_text.money -= potion1_price;

        }
    }
    public void potion2_button()
    {
        if (Money_text.money >= potion2_price)
        {
            potion2 += 1;
            Money_text.money -= potion2_price;

        }
    }

    public void potion3_button()
    {
        if (Money_text.money >= potion3_price)
        {
            potion3 += 1;
            Money_text.money -= potion3_price;

        }
    }


    void Update()
    {
        //èäéùêî
        foreach (var p1 in have_potion1_Text)
        {
            p1.text = "Å~" + potion1;

        }
        foreach (var p2 in have_potion2_Text)
        {
            p2.text = "Å~" + potion2;

        }
        foreach (var p3 in have_potion3_Text)
        {
            p3.text = "Å~" + potion3;

        }

        //ílíi
        foreach (var pp1 in potion1_priceText)
        {
            pp1.text = "GÅF" + potion1_price;

        }
        foreach (var pp2 in potion2_priceText)
        {
            pp2.text = "GÅF" + potion2_price;

        }
        foreach (var pp3 in potion3_priceText)
        {
            pp3.text = "GÅF" + potion3_price;

        }

    }
}
