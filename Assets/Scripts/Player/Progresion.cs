using System;
using UnityEngine;
using UnityEngine.Events;

public class Progresion : MonoBehaviour
{
    [SerializeField] private UnityEvent<int> OnLevelChanged;
    [SerializeField] private UnityEvent<int> OnMaxExpChanged;
    [SerializeField] private UnityEvent<int> OnExperienciaChanged;
    
    private PlayerProgressionData PerfilJugador;

    private void Awake()
    {
        PerfilJugador = GameManager.Instance.GetPerfilJugador;
        OnLevelChanged.Invoke(PerfilJugador.MNivel);
        OnMaxExpChanged.Invoke(PerfilJugador.MExperienciaProximoNivel);
        OnExperienciaChanged.Invoke(PerfilJugador.MExperiencia);
    }

    public void GanarExperiencia(int InExperiencia)
    {
        PerfilJugador.MExperiencia += InExperiencia;
        OnExperienciaChanged.Invoke(PerfilJugador.MExperiencia);
        if (PerfilJugador.MExperiencia >= PerfilJugador.MExperienciaProximoNivel)
        {
            SubirNivel();
        }
    }

    private void SubirNivel()
    {
        PerfilJugador.MNivel++;
        OnLevelChanged.Invoke(PerfilJugador.MNivel);
        PerfilJugador.MExperiencia = 0;
        OnExperienciaChanged.Invoke(PerfilJugador.MExperiencia);
        PerfilJugador.MExperienciaProximoNivel *= PerfilJugador.MEscalarExperiencia;
        OnMaxExpChanged.Invoke(PerfilJugador.MExperienciaProximoNivel);
        PerfilJugador.MVelocity *= PerfilJugador.MPorcAumVel;
    }
}
