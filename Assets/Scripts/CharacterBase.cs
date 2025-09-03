using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Propiedades compartidas por los personajes
    [Header("Personaje Base")]
    [SerializeField] protected int PuntosDeVidaActuales = 100;
    [SerializeField] protected int PuntosDeVidaMaximos = 100;

    protected bool Vivo = true;

    public void RecibirDanio(int InDanio)
    {
        PuntosDeVidaActuales = Mathf.Clamp(PuntosDeVidaActuales - InDanio, 0, PuntosDeVidaMaximos);
        if (PuntosDeVidaActuales <= 0)
        {
            Vivo = false;
            //Implementar evento de muerte.
        }
    }

    public void RecibirCuracion(int InCuracion)
    {
        PuntosDeVidaActuales = Mathf.Clamp(PuntosDeVidaActuales + InCuracion, 0, PuntosDeVidaMaximos);
    }

    public bool EstasVivo()
    {
        return Vivo;
    }

    public int GetPuntosDeVidaActuales()
    {
        return PuntosDeVidaActuales;
    }
}
