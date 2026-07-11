using UnityEngine;

public class ShipsCannon : MonoBehaviour
{
    [Header("Cannons")]
    public Transform leftCannon;
    public Transform rightCannon;

    public GameObject cannonballPrefab;

    [Header("Settings")]
    public float fireCooldown = 0.8f;

    private float nextFireTime;

    void Update()
    {
        if (!CompareTag("Player"))
            return;

        if (Input.GetMouseButtonDown(0))
            FireLeft();

        if (Input.GetMouseButtonDown(1))
            FireRight();
    }

    public bool FireLeft()
    {
        if (Time.time < nextFireTime)
            return false;

        nextFireTime = Time.time + fireCooldown;

        Shoot(leftCannon);

        return true;
    }

    public bool FireRight()
    {
        if (Time.time < nextFireTime)
            return false;

        nextFireTime = Time.time + fireCooldown;

        Shoot(rightCannon);

        return true;
    }

    void Shoot(Transform cannon)
    {
        GameObject ball =
            Instantiate(cannonballPrefab,
                        cannon.position,
                        cannon.rotation);

        Physics2D.IgnoreCollision(
            ball.GetComponent<Collider2D>(),
            GetComponent<Collider2D>());

        CannonBall cannonBall = ball.GetComponent<CannonBall>();

        cannonBall.Launch(cannon.up);
    }
}