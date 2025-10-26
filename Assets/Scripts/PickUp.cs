using UnityEngine;
using System.Collections.Generic;

public class PickUp : MonoBehaviour
{
    [Header("Basics")]
    [SerializeField] private int Points = 10;
    [SerializeField] private int Experiencia = 100;
    
    [Header("Sprite → Valores (tipo TMap)")]
    [SerializeField] private SpriteEntry[] SpriteTable; //La idea era implementar algo similar al TMap de UnrealEngine.
    
    [Header("Selección de Sprite")]
    [SerializeField] private bool RandomizeSprite = false;

    private SpriteRenderer SpriteRenderer;
    private Dictionary<Sprite, SpriteEntry> Lookup;

    [System.Serializable]
    public class SpriteEntry
    {
        public Sprite Sprite;
        public int Points = 10;
        public int Experiencia = 100;
    }
    
    private void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

        var col = GetComponent<Collider2D>();
        col.isTrigger = true;
        
        Lookup = new Dictionary<Sprite, SpriteEntry>();
        if (SpriteTable != null)
        {
            foreach (var e in SpriteTable)
            {
                if (e == null || e.Sprite == null) continue;
                Lookup[e.Sprite] = e; // último gana si hay duplicados
            }
        }
    }
    
    private void OnEnable()
    {
        if (RandomizeSprite && SpriteTable != null && SpriteTable.Length > 0)
        {
            var chosen = SpriteTable[Random.Range(0, SpriteTable.Length)];
            if (chosen != null && chosen.Sprite != null)
                SpriteRenderer.sprite = chosen.Sprite;
        }
        
        var sprite = SpriteRenderer.sprite;
        if (sprite != null && Lookup != null && Lookup.TryGetValue(sprite, out var entry))
        {
            Points = entry.Points;
            Experiencia = entry.Experiencia;
        }
    }
    
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Puntaje>().AddScore(Points);
            Debug.Log("El objeto Jugador: " + other.gameObject.name + " interactuo con el PICKUP: " 
                      + gameObject.name + " y recibio " + Points + " puntos." + " El jugador tiene un total de: "
                      + other.gameObject.GetComponent<Puntaje>().GetScore() + " puntos.");
            other.gameObject.GetComponent<Progresion>().GanarExperiencia(Experiencia);
            Debug.Log("El objeto Jugador: " + other.gameObject.name + " interactuo con el PICKUP: " 
                      + gameObject.name + " y recibio " + Experiencia + " puntos de experiencia." + " El jugador tiene un total de: "
                      + other.gameObject.GetComponent<CharacterBase>().GetPerfilJugador().MExperiencia + " puntos de experiencia.");
            Destroy(gameObject);
        }
    }
}