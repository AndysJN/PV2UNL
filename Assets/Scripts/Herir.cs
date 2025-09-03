using System;
using UnityEngine;

public class Herir : MonoBehaviour
{
    // Variables expuestas en el editor
    [Header("Basics")]
    [SerializeField] int Damage = 10;

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
