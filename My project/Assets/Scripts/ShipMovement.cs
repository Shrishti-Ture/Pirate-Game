using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour
{
    [Header("Movement")]
    public float acceleration = 8f;
    public float maxForwardSpeed = 6f;
    public float maxReverseSpeed = 3f;
    public float turnSpeed = 120f;
    public float waterDrag = 0.98f;

    private Rigidbody2D rb;

    private float throttle;
    private float steering;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float moveInput, float turnInput)
    {
        throttle = moveInput;
        steering = turnInput;
    }

    void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation - steering * turnSpeed * Time.fixedDeltaTime);

        if (throttle > 0)
        {
            rb.AddForce(transform.up * acceleration);
        }
        else if (throttle < 0)
        {
            rb.AddForce(-transform.up * acceleration * 0.6f);
        }

        float maxSpeed = throttle >= 0 ? maxForwardSpeed : maxReverseSpeed;

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

        rb.linearVelocity *= waterDrag;
    }
}