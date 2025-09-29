using UnityEngine;

public class Progresion : MonoBehaviour
{
    [SerializeField]
    private PlayerProgressionData PerfilJugador;

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
        PerfilJugador.MExperiencia -= PerfilJugador.MExperienciaProximoNivel;
        PerfilJugador.MExperienciaProximoNivel += PerfilJugador.MEscalarExperiencia;
    }
}
