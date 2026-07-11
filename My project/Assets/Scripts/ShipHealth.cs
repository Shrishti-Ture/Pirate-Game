using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 5;
    private int currentHealth;

    [Header("UI")]
    public Slider healthSlider;

    [Header("Death")]
    public GameObject explosionPrefab;
    public bool isPlayer = false;

    bool dead = false;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
{
    Debug.Log(gameObject.name + " took damage!");

    currentHealth -= damage;

    if (healthSlider != null)
        healthSlider.value = currentHealth;

    if (currentHealth <= 0)
        Die();
}

    void Die()
    {
        dead = true;

        GetComponent<Rigidbody2D>().linearVelocity = Vector2.zero;

        StartCoroutine(SinkShip());
    }

    System.Collections.IEnumerator SinkShip()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if(rb != null)
            rb.simulated = false;

        Collider2D col = GetComponent<Collider2D>();

        if(col != null)
            col.enabled = false;

        float timer = 0;

        Vector3 startScale = transform.localScale;

        while(timer < 2f)
        {
            timer += Time.deltaTime;

            transform.Rotate(0,0,40*Time.deltaTime);

            transform.localScale =
                Vector3.Lerp(startScale,
                             Vector3.zero,
                             timer/2f);

            yield return null;
        }

        if(explosionPrefab != null)
            Instantiate(explosionPrefab,
                        transform.position,
                        Quaternion.identity);

        if(isPlayer)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            EnemyCounter.EnemyKilled();

            Destroy(gameObject);
        }
    }
}