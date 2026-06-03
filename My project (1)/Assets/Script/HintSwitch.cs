using UnityEngine;

public class HintSwitch : MonoBehaviour
{
    public GameObject hintPanel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintPanel.SetActive(true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hintPanel.SetActive(false);
        }

    }

}
