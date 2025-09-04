using UnityEngine;

public class Puntaje : MonoBehaviour
{
    private int Score = 0;
    
    public int GetScore()
    {
        return Score;
    }
    
    public void AddScore(int InScore)
    {
        Score += InScore;
    }
}
