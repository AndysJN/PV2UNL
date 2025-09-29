using System;
using UnityEngine;
using UnityEngine.Events;

public class CharacterBase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Propiedades Refactoreadas en ScriptableObject
    [Header("Basics")]
    [SerializeField] protected int HitPoints = 100;
    [SerializeField] protected int MaxHitPoints = 100;
    protected bool Alive = true;
    
    /*
     * Eventos del jugador
     */

    [SerializeField]
    private UnityEvent<string> OnHitPointsChanged;
    
    [SerializeField]
    private UnityEvent<bool, int> OnCharacterDied;

    private void Start()
    {
        OnHitPointsChanged.Invoke(HitPoints.ToString());
    }

    public void TakeDamage(int InDamage)
    {
        HitPoints = Mathf.Clamp(HitPoints - InDamage, 0, MaxHitPoints);
        if (HitPoints <= 0)
        {
            Alive = false;
            OnCharacterDied.Invoke(Alive, GetComponent<Puntaje>().GetScore());
        }
        OnHitPointsChanged.Invoke(HitPoints.ToString());
    }

    public void RecibirCuracion(int InHealing)
    {
        HitPoints = Mathf.Clamp(HitPoints + InHealing, 0, MaxHitPoints);
    }

    public bool IsAlive()
    {
        return Alive;
    }

    public int GetHitPoints()
    {
        return HitPoints;
    }
}
