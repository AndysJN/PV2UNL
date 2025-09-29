using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TextMeshProUGUI GameOverText;
    [SerializeField] private TextMeshProUGUI PointsText;
    [SerializeField] private Button RetryButton;
    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button AbandonButton;
    [SerializeField] private Button AldeaButton;
    [SerializeField] private GameObject PausePopUp;
    private bool HasPlayerWon;
    
    private void Awake()
    {
        /* Ocultar panel en el inicio */
        GameOverPanel.SetActive(false);
        PausePopUp.SetActive(false);
        
        // Agregar callbacks a los delegates
        RetryButton.onClick.AddListener(RetryGame);
        MainMenuButton.onClick.AddListener(ReturnToMainMenu);
        AbandonButton.onClick.AddListener(ReturnToMainMenuAndReset);
        if (AldeaButton != null)
        {
            AldeaButton.onClick.AddListener(ReturnToAldeaAndReset);
        }
    }

    private void OnEnable()
    {
        GameEvents.OnPause += PauseGame;
        GameEvents.OnResume += ResumeGame;
    }

    private void OnDisable()
    {
        GameEvents.OnPause -= PauseGame;
        GameEvents.OnResume -= ResumeGame;
    }

    private void PauseGame()
    {
        PausePopUp.SetActive(true);
    }

    private void ResumeGame()
    {
        PausePopUp.SetActive(false);
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
        PointsText.text = GameManager.Instance.GetScore().ToString();
        Time.timeScale = 0f;
        GameOverPanel.SetActive(true);
    }
    
    private void RetryGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance.RetryLevel();
    }
    
    private void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        GameManager.Instance.GotoPortadaScene();
    }

    private void ReturnToMainMenuAndReset()
    {
        GameManager.Instance.ResetProgress();
        ReturnToMainMenu();
    }

    private void ReturnToAldeaAndReset()
    {
        Time.timeScale = 1f;
        GameManager.Instance.ResetProgress();
        GameManager.Instance.GotoScene(1);
    }
}