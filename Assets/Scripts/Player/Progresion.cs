using System;
using UnityEngine;

public class Progresion : MonoBehaviour
{
    
    private PlayerProgressionData PerfilJugador;

    private void Awake()
    {
        PerfilJugador = GameManager.Instance.GetPerfilJugador;
    }

    public void GanarExperiencia(int InExperiencia)
    {
        PerfilJugador.MExperiencia += InExperiencia;
        if (PerfilJugador.MExperiencia >= PerfilJugador.MExperienciaProximoNivel)
        {
            SubirNivel();
        }
    }

    private void SubirNivel()
    {
        PerfilJugador.MNivel++;
        PerfilJugador.MExperiencia = 0;
        PerfilJugador.MExperienciaProximoNivel *= PerfilJugador.MEscalarExperiencia;
    }
}
