using System;
using UnityEngine;
using UnityEngine.Events;

public class CharacterBase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Propiedades Refactoreadas en ScriptableObject
    [Header("Perfil Del Jugador")]
    [SerializeField]
    private PlayerProgressionData PerfilJugador = GameManager.Instance.GetPerfilJugador;
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
        Respawn();
        OnHitPointsChanged.Invoke(PerfilJugador.MHitPoints.ToString());
    }

    public void TakeDamage(int InDamage)
    {
        PerfilJugador.MHitPoints = Mathf.Clamp(PerfilJugador.MHitPoints - InDamage, 0, PerfilJugador.MMaxHitPoints);
        if (PerfilJugador.MHitPoints <= 0)
        {
            Alive = false;
            OnCharacterDied.Invoke(Alive, GetComponent<Puntaje>().GetScore());
        }
        OnHitPointsChanged.Invoke(PerfilJugador.MHitPoints.ToString());
    }

    public void RecibirCuracion(int InHealing)
    {
        PerfilJugador.MHitPoints = Mathf.Clamp(PerfilJugador.MHitPoints + InHealing, 0, PerfilJugador.MMaxHitPoints);
    }

    public bool IsAlive()
    {
        return Alive;
    }

    public int GetHitPoints()
    {
        return PerfilJugador.MHitPoints;
    }
    
    public PlayerProgressionData GetPerfilJugador()
    {
        return PerfilJugador;
    }
    
    private void Respawn()
    {
        Alive = true;
        PerfilJugador.MHitPoints = PerfilJugador.MMaxHitPoints;
        OnHitPointsChanged.Invoke(PerfilJugador.MHitPoints.ToString());
    }
}
