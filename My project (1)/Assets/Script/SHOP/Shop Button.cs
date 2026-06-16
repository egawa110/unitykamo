using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Threading;

public class ShopButton : MonoBehaviour
{
    public GameObject[] HealPanel;
    public GameObject[] GearPanel;
    public GameObject[] StatusPanel;

    public static bool heal_flag;
    public static bool gear_flag;
    public static bool status_flag;


    private void Start()
    {
        heal_flag = true;
        gear_flag = false;
        status_flag = false;
    }

    public void OpenHealPanel() //ヒールパネル
    {
        heal_flag = true;

        gear_flag = false;
        status_flag = false;
    }

    public void OpenGearPanel() //装備パネル
    {
        gear_flag = true;

        heal_flag = false;
        status_flag = false;
    }

    public void OpenStatusPanel() //ステータスパネル
    {
        status_flag = true;

        heal_flag = false;
        gear_flag = false;
    }

    private void Update()
    {
        foreach (var hp in HealPanel)
            hp.gameObject.SetActive(heal_flag);

        foreach (var gp in GearPanel)
            gp.gameObject.SetActive(gear_flag);

        foreach (var sp in StatusPanel)
            sp.gameObject.SetActive(status_flag);

    }
}
