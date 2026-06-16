using UnityEngine;
using UnityEngine.UI;

public class StatusButton : MonoBehaviour
{
    public static int shop_hp;
    public static int shop_strongPower;
    public static int shop_lightPower;

    public Text[] hpText;
    public Text[] strongPowerText;
    public Text[] lightPowerText;


    public void Status_hp()
    {
        shop_hp += 10;
    }

    public void Status_strongpower()
    {
        shop_strongPower += 10;

    }

    public void Status_lightpower()
    {
        shop_lightPower += 10;
    }

    private void Update()
    {
        foreach (var hp in hpText)
        {
            hp.text = "ëÃóÕÅ@ +" + shop_hp;

        }
        foreach (var sp in strongPowerText)
        {
            sp.text = "ã≠çUåÇ +" + shop_strongPower;

        }
        foreach (var lp in lightPowerText)
        {
            lp.text = "é„çUåÇ +" + shop_lightPower;

        }

    }

}
