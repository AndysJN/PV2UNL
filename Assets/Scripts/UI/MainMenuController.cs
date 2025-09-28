using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void LoadNextScene()
    {
        GameManager.Instance.GotoNextScene();
    }
    
    public void QuitGame()
    {
       GameManager.Instance.QuitGame();
    }
}
