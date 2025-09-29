using UnityEngine;

[CreateAssetMenu(fileName = "PlayerProgressionData", menuName = "ScriptableObjects/PlayerProgressionData")]
public class PlayerProgressionData : ScriptableObject
{
    [Header("Configuracion de Experciencia")]
    [SerializeField]
    private int Nivel;

    public int MNivel
    {
        get => Nivel; 
        set => Nivel = value;
    }
    
    private int Score = 0;
    
    public int MScore
    {
        get => Score; 
        set => Score = value;
    }
    
    [SerializeField]
    private int Experiencia;

    public int MExperiencia
    {
        get => Experiencia; 
        set => Experiencia = value;
    }
    
    [SerializeField]
    [Range(0,100)]
    [Tooltip("Cantidad de Experiencia necesaria para el proximo nivel")]
    private int ExperienciaProximoNivel;

    public int MExperienciaProximoNivel
    {
        get => ExperienciaProximoNivel; 
        set => ExperienciaProximoNivel = value;
    }
    
    [SerializeField]
    [Range(0,1)]
    [Tooltip("Multiplicador de experiencia para los niveles siguientes")]
    private int EscalarExperiencia = 2;

    public int MEscalarExperiencia
    {
        get => EscalarExperiencia;
        set => EscalarExperiencia = value;
    }
    
    [Header("Atributos del Personaje")]
    [System.NonSerialized] private int HitPoints = 100;

    public int MHitPoints
    {
        get => HitPoints;
        set => HitPoints = value;
    }
        
    [SerializeField] private int MaxHitPoints = 100;
    public int MMaxHitPoints
    {
        get => MaxHitPoints;
    }
    
}
