using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    // Propiedades compartidas por los personajes
    [Header("Personaje Base")]
    [SerializeField] protected int HitPoints;
    [SerializeField] protected int MaxHitPoints;
}
