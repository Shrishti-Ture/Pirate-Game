using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 20f;
    public float lifetime = 8f;

    [Header("Damage")]
    public int damage = 1;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction)
    {
        rb.linearVelocity = direction.normalized * speed;

        transform.up = direction;

        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ignore bullets
        if (other.CompareTag("PlayerBullet") || other.CompareTag("EnemyBullet"))
            return;

        // Player bullet
        if (CompareTag("PlayerBullet") && other.CompareTag("Enemy"))
        {
            ShipHealth hp = other.GetComponent<ShipHealth>();

            if (hp != null)
                hp.TakeDamage(damage);

            Destroy(gameObject);
            return;
        }

        // Enemy bullet
        if (CompareTag("EnemyBullet") && other.CompareTag("Player"))
        {
            ShipHealth hp = other.GetComponent<ShipHealth>();

            if (hp != null)
                hp.TakeDamage(damage);

            Destroy(gameObject);
            return;
        }

        if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}