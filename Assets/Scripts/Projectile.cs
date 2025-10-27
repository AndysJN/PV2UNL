using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Basics")]
    public float Speed = 12f;
    public int Damage = 5;
    public float Lifetime = 4f;

    [HideInInspector] public ProjectilePool Pool;

    private Rigidbody2D RigidBody;
    private float LifeRemaining;
    private Vector2 Direction;

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        Collider2D Collider = GetComponent<Collider2D>();
        Collider.isTrigger = true;

        RigidBody.isKinematic = true;
        RigidBody.gravityScale = 0f;
    }

    private void OnEnable()
    {
        LifeRemaining = Lifetime;
        RigidBody.linearVelocity = Vector2.zero;
        RigidBody.angularVelocity = 0f;
    }

    private void Update()
    {
        Vector2 TargetPosition = RigidBody.position + Direction * (Speed * Time.deltaTime);
        RigidBody.MovePosition(TargetPosition);

        LifeRemaining -= Time.deltaTime;
        if (LifeRemaining <= 0f)
        {
            Despawn();
        }
    }

    public void Initialize(Vector2 InDirection, int InDamage = -1, float InSpeed = -1f)
    {
        Direction = InDirection.sqrMagnitude > 0f ? InDirection.normalized : Vector2.right;
        if (InDamage >= 0) Damage = InDamage;
        if (InSpeed  > 0f) Speed  = InSpeed;
    }

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if (!Other.CompareTag("Player")) return;

        CharacterBase Jugador = Other.GetComponent<CharacterBase>();
        if (Jugador != null) Jugador.TakeDamage(Damage);

        Despawn();
    }

    private void Despawn()
    {
        if (Pool) Pool.Return(this);
        else gameObject.SetActive(false);
    }
}

