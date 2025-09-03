using UnityEngine;

/*
 * Busco crear un movimiento estilo patinaje, que genere momentun y lo mantenga.
 * Que sea dificil de volver al estado inicial Y genere inercia. Progresivo.
 */

public class MovimientoProgresivo : MonoBehaviour
{
    // Variables expuestas en el editor
    [Header("Basics")]
    [SerializeField] private float Velocity = 25.0f;
    [SerializeField] private float Acceleration = 1.0f;

    private Vector2 Direction;
    private Rigidbody2D ActorRigidbody;
    
    private void OnEnable()
    {
        ActorRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Direction.x = Input.GetAxisRaw("Horizontal");
        Direction.y = Input.GetAxisRaw("Vertical");
        
        /* Debugs */
        //Debug.Log(Direccion);
        /* Debugs */
    }

    void FixedUpdate()
    {
        // Aparentemente no hace falta normalizar la direccion, si hay que tener en cuenta que tal vez usando un input de joystick puede afectar ?
        // Vector2 DireccionNormalizada = Direccion.normalized;
        Vector2 TargetVelocity = Direction * Velocity;

        ActorRigidbody.linearVelocity = Vector2.Lerp(
            ActorRigidbody.linearVelocity,
            TargetVelocity,
            Acceleration * Time.fixedDeltaTime);
    }
    
}