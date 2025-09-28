using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TextMeshProUGUI GameOverText;
    [SerializeField] private TextMeshProUGUI PointsText;
    [SerializeField] private Button RetryButton;
    [SerializeField] private Button MainMenuButton;
    private bool HasPlayerWon;
    
    private void Awake()
    {
        /* Ocultar panel en el inicio */
        GameOverPanel.SetActive(false);
        
        // Agregar callbacks a los delegates
        RetryButton.onClick.AddListener(RetryGame);
        MainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }
    
    public void ShowGameOver(bool IsCharacterAlive, int InTotalPoints)
    {
        if (IsCharacterAlive)
        {
            GameOverText.text = "GANASTE!";
            HasPlayerWon = true;
        }
        else
        {
            GameOverText.text = "PERDISTE!";
            HasPlayerWon = false;
        }
        PointsText.text = InTotalPoints.ToString();
        Time.timeScale = 0f;
        GameOverPanel.SetActive(true);
    }
    
    private void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    private void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        GameManager.Instance.GotoPortadaScene();
    }
}