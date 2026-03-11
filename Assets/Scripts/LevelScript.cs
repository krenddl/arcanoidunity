using Unity.VisualScripting;
using UnityEngine;

public class LevelScript : MonoBehaviour
{
    [SerializeField]private Animator mainMenuAnimator;
    [SerializeField]private Animator levelMenuAnimator;
    

    public void ClickBtn()
    {
        mainMenuAnimator.SetBool("IsOpen", true);
        levelMenuAnimator.SetBool("IsOpen", true);
    }

    public void ExitClickBtn()
    {
        mainMenuAnimator.SetBool("IsOpen", false);
        levelMenuAnimator.SetBool("IsOpen", false);
    }

    public void Level1Btn()
    {
        mainMenuAnimator.SetBool("IsOpenLevel1", true);
        levelMenuAnimator.SetBool("IsOpenLevel1", true);
    }
}
