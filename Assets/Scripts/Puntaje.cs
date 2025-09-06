using UnityEngine;
using UnityEngine.Events;

public class Puntaje : MonoBehaviour
{
    /* Eventos de puntaje*/
    [SerializeField] private UnityEvent<int> OnPointsChanged;
    
    private int Score = 0;
    
    public int GetScore()
    {
        return Score;
    }
    
    public void AddScore(int InScore)
    {
        Score += InScore;
        OnPointsChanged.Invoke(Score);
    }
}
