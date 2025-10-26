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
            if (HasValidPersistentListeners(OnCharacterMapReached))
            { 
                OnCharacterMapReached.Invoke(other.gameObject.GetComponent<CharacterBase>().IsAlive(), other.gameObject.GetComponent<Puntaje>().GetScore());
            }
            else
            {
                if (GameManager.Instance != null)
                    GameManager.Instance.GotoNextScene();
                else
                    Debug.LogWarning("[Meta] No hay listeners y GameManager.Instance es null; no se puede cambiar de escena.", this);
            }
        }
    }
    
    private bool HasValidPersistentListeners(UnityEvent<bool, int> evt)
    {
        if (evt == null) return false;
        int count = evt.GetPersistentEventCount();
        for (int i = 0; i < count; i++)
        {
            var target = evt.GetPersistentTarget(i);
            var method = evt.GetPersistentMethodName(i);
            if (target != null && !string.IsNullOrEmpty(method))
                return true;
        }
        return false;
    }
}
