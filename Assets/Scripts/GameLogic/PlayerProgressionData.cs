using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgressionData", menuName = "ScriptableObjects/PlayerProgressionData")]
public class PlayerProgressionData : ScriptableObject
{
    private int Nivel;

    public int MNivel
    {
        get => Nivel; 
        set => Nivel = value;
    }
    
    private int Experiencia;

    public int MExperiencia
    {
        get => Experiencia; 
        set => Experiencia = value;
    }
    
    [SerializeField]
    [Header("Configuracion de Experciencia")]
    [Range(0,100)]
    [Tooltip("Cantidad de Experiencia necesaria para el proximo nivel")]
    private int ExperienciaProximoNivel;

    public int MExperienciaProximoNivel
    {
        get => ExperienciaProximoNivel; 
        set => ExperienciaProximoNivel = value;
    }
    
    [SerializeField]
    [Range(0,500)]
    [Tooltip("Numero en el cual escala la experiencia requerida nivel a nivel")]
    private int EscalarExperiencia;

    public int MEscalarExperiencia
    {
        get => EscalarExperiencia;
        set => EscalarExperiencia = value;
    }
    
    [Header("Configuracion de Atributos del  Personaje")]
    [SerializeField] private int HitPoints = 100;

    public int MHitPoints
    {
        get => HitPoints;
        set => HitPoints = value;
    }
        
    [SerializeField] private int MaxHitPoints = 100;
    public int MMaxHitPoints
    {
        get => MaxHitPoints;
        set => MaxHitPoints = value;
    }
    
}
