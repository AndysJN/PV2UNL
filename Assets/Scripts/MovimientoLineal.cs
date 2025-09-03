using UnityEngine;

public class MovimientoLineal : MonoBehaviour
{
    // Variables expuestas en el editor
    [Header("Basics")]
    [SerializeField] float Velocity = 5f;
    
    private Vector2 Direction;
    private Rigidbody2D ActorRigidbody;

    private void OnEnable()
    {
        ActorRigidbody = GetComponent<Rigidbody2D>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        Direction.x = Input.GetAxis("Horizontal");
        Direction.y = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        ActorRigidbody.MovePosition(ActorRigidbody.position + Direction * (Velocity * Time.fixedDeltaTime));
    }
}
