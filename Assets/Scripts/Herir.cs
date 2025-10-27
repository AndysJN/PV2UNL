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
    
    [Header("Disparo (Object Pooling)")]
    [Tooltip("Pool de proyectiles compartido en la escena.")]
    public ProjectilePool Pool;

    [Tooltip("Rango de intervalo aleatorio entre ráfagas (segundos).")]
    public float IntervalMin = 0.8f;
    public float IntervalMax = 1.8f;

    [Tooltip("Cantidad de proyectiles por ráfaga.")]
    public int ProjectilesPerVolley = 1;

    [Tooltip("Velocidad del proyectil")]
    public float ProjectileSpeed = 12f;

    [Tooltip("Habilitar disparo.")]
    public bool EnableShooting = true;

    private float Timer;

    void Awake()
    {
        SpriteRendererRef = GetComponent<SpriteRenderer>();
        
        Lookup = new Dictionary<Sprite, SpriteEntry>();
        if (SpriteTable != null)
        {
            foreach (SpriteEntry Row in SpriteTable)
            {
                if (Row == null || Row.Sprite == null) continue;
                Lookup[Row.Sprite] = Row;
            }
        }

        if (Pool == null)
        {
            Pool = FindFirstObjectByType<ProjectilePool>(); 
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
        
        ResetTimer();
    }

    void Update()
    {
        if (!EnableShooting || !Pool) return;
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            FireVolley();
            ResetTimer();
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
    void ResetTimer()
    {
        float Min = Mathf.Max(0.05f, Mathf.Min(IntervalMin, IntervalMax));
        float Max = Mathf.Max(Min + 0.01f, Mathf.Max(IntervalMin, IntervalMax));
        Timer = UnityEngine.Random.Range(Min, Max);
    }

    void FireVolley()
    {
        int Count = Mathf.Max(1, ProjectilesPerVolley);
        for (int i = 0; i < Count; ++i)
        {
            Projectile Proj = Pool.Get();
            if (!Proj) return;
            Vector3 SpawnPosition = transform.position;

            Proj.transform.position = SpawnPosition;
            Proj.transform.rotation = Quaternion.identity;
            float angle = UnityEngine.Random.Range(0f, 360f) * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            Proj.Initialize(dir, Damage, ProjectileSpeed);
        }
    }
}
