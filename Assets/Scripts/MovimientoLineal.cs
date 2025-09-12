using UnityEngine;

public class MovimientoLineal : MonoBehaviour
{
    // Variables expuestas en el editor
    [Header("Basics")]
    [SerializeField] float Velocity = 5f;
    
    private Vector2 Direction;
    private Rigidbody2D ActorRigidbody;
    private Animator Animator;

    private void OnEnable()
    {
        ActorRigidbody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Animator.SetBool("IsWalking", true);
            Direction.x = Input.GetAxis("Horizontal");
            Direction.y = Input.GetAxis("Vertical");
            Animator.SetFloat("InputX", Direction.x );
            Animator.SetFloat("InputY", Direction.y );
        }
        else if (Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
        {
            Animator.SetBool("IsWalking", false);
            Animator.SetFloat("LastInputX", Direction.x);
            Animator.SetFloat("LastInputY", Direction.y);
        }
        
    }
    private void FixedUpdate()
    {
        ActorRigidbody.MovePosition(ActorRigidbody.position + Direction * (Velocity * Time.fixedDeltaTime));
    }
}
