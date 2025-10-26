using System;
using UnityEngine;
using System.Collections.Generic;

public class Herir : MonoBehaviour
{
    // Variables expuestas en el editor
    [Header("Basics")]
    [SerializeField] int Damage = 10;
    
    [Header("Relacion Sprite Daño")]
    [SerializeField] SpriteEntry[] SpriteTable;

    [Header("Selección de Sprite")]
    [SerializeField] bool RandomizeSprite = false;
    
    SpriteRenderer SpriteRendererRef;
    Dictionary<Sprite, SpriteEntry> Lookup;

    [System.Serializable]
    public class SpriteEntry
    {
        public Sprite Sprite;
        public int Damage = 10;
    }

    void Awake()
    {
        SpriteRendererRef = GetComponent<SpriteRenderer>();
        
        Lookup = new Dictionary<Sprite, SpriteEntry>();
        if (SpriteTable != null)
        {
            foreach (SpriteEntry Row in SpriteTable)
            {
                if (Row == null || Row.Sprite == null) continue;
            }
        }
    }

    void OnEnable()
    {
        if (RandomizeSprite && SpriteTable != null && SpriteTable.Length > 0)
        {
            SpriteEntry ChosenEnemy = SpriteTable[UnityEngine.Random.Range(0, SpriteTable.Length)];
            if (ChosenEnemy != null && ChosenEnemy.Sprite != null)
                SpriteRendererRef.sprite = ChosenEnemy.Sprite;
        }
        
        Sprite sprite = SpriteRendererRef.sprite;
        if (sprite != null && Lookup != null && Lookup.TryGetValue(sprite, out SpriteEntry entry))
        {
            Damage = entry.Damage;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharacterBase Jugador = other.gameObject.GetComponent<CharacterBase>();
            Jugador.TakeDamage(Damage);
            Debug.Log("El objeto Jugador: " + Jugador.gameObject.name + " ha sido herido por el objeto: " 
                      + gameObject.name + " por un total de " + Damage + " puntos de vida. Al jugador le quedan " 
                      + Jugador.GetHitPoints() + " puntos de vida.");
        }
    }
}
