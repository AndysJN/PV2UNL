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
    
    private bool HasValidPersistentListeners(UnityEvent<bool, int> Evt)
    {
        if (Evt == null) return false;
        int Count = Evt.GetPersistentEventCount();
        for (int i = 0; i < Count; ++i)
        {
            var Target = Evt.GetPersistentTarget(i);
            var Method = Evt.GetPersistentMethodName(i);
            if (Target != null && !string.IsNullOrEmpty(Method))
                return true;
        }
        return false;
    }
}
