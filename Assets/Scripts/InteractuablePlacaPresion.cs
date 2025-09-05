using UnityEngine;
using UnityEngine.Events;

public class InteractuablePlacaPresion : MonoBehaviour
{
    public UnityEvent OnPlacaTriggered;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlacaTriggered.Invoke();
            Debug.Log("El objeto Jugador: " + other.gameObject.name + " interactuo con la PLACA: " 
                      + gameObject.name);
        }
    }
}
