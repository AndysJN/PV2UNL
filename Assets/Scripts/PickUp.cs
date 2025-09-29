using UnityEngine;

public class PickUp : MonoBehaviour
{
    [Header("Basics")]
    [SerializeField] private int Points = 10;
    [SerializeField] private int Experiencia = 100;
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