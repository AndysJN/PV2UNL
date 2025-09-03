using UnityEngine;

public class MovimientoLineal : MonoBehaviour
{
    // Variables expuestas en el editor
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;
    
    private Vector2 Direccion;
    private Rigidbody2D ActorRigidbody;

    private void OnEnable()
    {
        ActorRigidbody = GetComponent<Rigidbody2D>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        Direccion.x = Input.GetAxis("Horizontal");
        Direccion.y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        ActorRigidbody.MovePosition(ActorRigidbody.position + Direccion * (velocidad * Time.fixedDeltaTime));
    }
}
