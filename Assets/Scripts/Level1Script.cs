using UnityEngine;

public class Level1Script : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;
    public void OpenLevel1()
    {
        uiPanel.SetActive(true);
    }
}
