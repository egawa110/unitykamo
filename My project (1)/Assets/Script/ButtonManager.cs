using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public string SceneName; //移動したいシーン名

    public void ChengeScene()
    {
        SceneManager.LoadScene(SceneName); //シーン移動
    }
}
