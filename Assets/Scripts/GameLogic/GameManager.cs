using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    
    public void 
}
