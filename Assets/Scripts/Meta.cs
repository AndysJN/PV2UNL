using UnityEngine;
using UnityEngine.Events;

public class Meta : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<bool, int> OnCharacterMapReached;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           OnCharacterMapReached.Invoke(other.gameObject.GetComponent<CharacterBase>().IsAlive(), other.gameObject.GetComponent<Puntaje>().GetScore());
        }
    }
}
