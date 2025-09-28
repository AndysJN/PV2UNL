using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int EscenaDePortada = 0; 
    public static GameManager Instance { get; private set; }

    private int Score = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddScore(int InScore)
    {
        Score += InScore;
    }

    public void ResetScore()
    {
        Score = 0;
    }

    public int GetScore()
    {
        return Score;
    }

    public void GotoNextScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int NextSceneIndex = CurrentSceneIndex + 1;

        if (NextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(NextSceneIndex);
        }
        else
        {
            //Todo: Cambiar comportamiento para este caso.
            SceneManager.LoadScene(EscenaDePortada);
            Debug.LogWarning("No hay mas escenas despues de la actual, llevando a la escena de portada");
        }
    }
    
    public void GotoPreviousScene()
    {
        int CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int PreviousSceneIndex = CurrentSceneIndex - 1;

        if (PreviousSceneIndex >= 0)
        {
            SceneManager.LoadScene(PreviousSceneIndex);
        }
        else
        {
            //Todo: Cambiar comportamiento para este caso.
            SceneManager.LoadScene(EscenaDePortada);
            Debug.LogWarning("No hay mas escenas antes de la actual, llevando a la escena de portada");
        }
    }

    public void GotoPortadaScene()
    {
        SceneManager.LoadScene(EscenaDePortada);
    }

    public void RetryLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }
    
};
