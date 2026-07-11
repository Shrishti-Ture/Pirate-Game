using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [Header("Target")]
    public Transform player;

    [Header("Movement")]
    public float moveSpeed = 3f;
    public float rotationSpeed = 180f;

    [Header("Ranges")]
    public float detectionRange = 14f;
    public float attackRange = 7f;
    public float stopDistance = 5f;

    [Header("Combat")]
    public ShipsCannon cannon;

    public float fireRate = 2.2f;

    float fireTimer;

    Rigidbody2D rb;

    Vector2 homePosition;

    enum State
    {
        Idle,
        Chase,
        Attack,
        Return
    }

    State state = State.Idle;

    void Start()
{
    rb = GetComponent<Rigidbody2D>();

    homePosition = transform.position;

    player = GameObject.FindGameObjectWithTag("Player").transform;

    cannon = GetComponent<ShipsCannon>();
}
    void Update()
    {
        float distance =
            Vector2.Distance(transform.position,
                             player.position);

        switch(state)
        {
            case State.Idle:

                if(distance < detectionRange)
                    state = State.Chase;

                break;

            case State.Chase:

                if(distance <= stopDistance)
                    state = State.Attack;

                else
                    MoveTowards(player.position);

                break;

            case State.Attack:

                if(distance > attackRange)
                {
                    state = State.Chase;
                    break;
                }

                Attack();

                break;

            case State.Return:

                MoveTowards(homePosition);

                if(Vector2.Distance(transform.position,
                    homePosition) < 0.5f)
                {
                    state = State.Idle;
                }

                break;
        }

        if(distance > detectionRange + 2f)
            state = State.Return;

    }

    void MoveTowards(Vector2 target)
    {
        Vector2 dir =
            (target - (Vector2)transform.position).normalized;

        float angle =
            Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion targetRot =
            Quaternion.Euler(0,0,angle);

        transform.rotation =
            Quaternion.RotateTowards(
                transform.rotation,
                targetRot,
                rotationSpeed * Time.deltaTime);

        rb.linearVelocity =
            transform.up * moveSpeed;
    }

    void Attack()
{
    rb.linearVelocity = Vector2.zero;

    Vector2 toPlayer = (player.position - transform.position).normalized;

    // Rotate so LEFT side of ship faces player
    Vector2 broadside = new Vector2(toPlayer.y, -toPlayer.x);

    float angle = Mathf.Atan2(broadside.y, broadside.x) * Mathf.Rad2Deg - 90f;

    Quaternion targetRotation = Quaternion.Euler(0, 0, angle);

    transform.rotation = Quaternion.RotateTowards(
        transform.rotation,
        targetRotation,
        rotationSpeed * Time.deltaTime);

    fireTimer += Time.deltaTime;

    if (fireTimer >= fireRate)
    {
        cannon.FireLeft();
        cannon.FireRight();

        fireTimer = 0;
    }
}
}