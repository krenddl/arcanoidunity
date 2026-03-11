using UnityEngine;

public class Level1Script : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;
    [SerializeField] private GameObject panel;
    public void OpenLevel1()
    {
        panel.SetActive(true);
        uiPanel.SetActive(true);
    }
}
