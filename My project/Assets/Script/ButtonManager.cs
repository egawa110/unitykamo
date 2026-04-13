using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public string SceneName;
    public void ChengeScene() 
    {
        SceneManager.LoadScene(SceneName); //ƒV[ƒ“ˆÚ“®
    }
}
