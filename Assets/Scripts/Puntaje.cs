using UnityEngine;
using UnityEngine.Events;

public class Puntaje : MonoBehaviour
{
    /* Eventos de puntaje*/
    [SerializeField] private UnityEvent<int> OnPointsChanged;
    
    public int GetScore()
    {
        return GameManager.Instance.GetScore();
    }
    
    public void AddScore(int InScore)
    {
        GameManager.Instance.AddScore(InScore);
        OnPointsChanged.Invoke(GameManager.Instance.GetScore());
    }
}
