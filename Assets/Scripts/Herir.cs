using System;
using UnityEngine;

public class Herir : MonoBehaviour
{
    // Variables expuestas en el editor
    [Header("Propiedades Basicas")]
    [SerializeField] int Danio = 10;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharacterBase Jugador = other.gameObject.GetComponent<CharacterBase>();
            Jugador.RecibirDanio(Danio);
            Debug.Log("El objeto Jugador: " + Jugador.gameObject.name + " ha sido herido por el objeto: " 
                      + gameObject.name + " por un total de " + Danio + " puntos de vida. Al jugador le quedan " 
                      + Jugador.GetPuntosDeVidaActuales() + " puntos de vida.");
        }
    }
}
