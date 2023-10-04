using UnityEngine;

public class Player : MonoBehaviour
{
    Movement Movement;
    HealthBar HealthBar;
    Enemy Enemy;
    GetParticles GetParticles;
    GetTexts GetTexts;
    GetUIElements GetUIElements;
    EnemyFollow[] EnemyFollow;

    SpriteRenderer thisRenderer;
    Collider2D thisCollider;

    Vector3 respawnLocation;
    bool dead;

    public float maxHealth;
    public float currentHealth;

    private void Start()
    {
        Movement = FindObjectOfType<Movement>();
        GetParticles = FindObjectOfType<GetParticles>();
        GetTexts = FindObjectOfType<GetTexts>();
        GetUIElements = FindObjectOfType<GetUIElements>();
        EnemyFollow = FindObjectsOfType<EnemyFollow>();

        HealthBar = gameObject.GetComponent<HealthBar>();

        thisRenderer = gameObject.GetComponent<SpriteRenderer>();
        thisCollider = gameObject.GetComponent<Collider2D>();

        transform.localPosition = respawnLocation;

        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!dead)
        {
            if (collision.gameObject.tag is "Enemy")
            {
                Enemy = collision.gameObject.GetComponent<Enemy>();
                TakeDamage(Enemy.enemyDamage);

                GetTexts.txtPlayerHealthAmount.text = currentHealth.ToString("0") + " / " + maxHealth;
            }

            Die();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!dead)
        {
            if (collision.gameObject.tag is "Enemy")
            {
                Enemy = collision.gameObject.GetComponent<Enemy>();
                TakeDamage(Enemy.enemyTickDamage);

                GetTexts.txtPlayerHealthAmount.text = currentHealth.ToString("0") + " / " + maxHealth;
            }

            Die();
        }
    }

    void TakeDamage(float damage)
    {
        currentHealth -= damage;

        HealthBar.SetHealth(currentHealth);
    }

    void Die()
    {
        if (currentHealth <= 0)
        {
            Movement.enabled = false;

            gameObject.transform.localPosition = respawnLocation;
            GetParticles.playerDeathParticle.Play();

            thisRenderer.enabled = false;
            thisCollider.enabled = false;

            GetUIElements.deathPanel.SetActive(true);

            dead = true;

            Time.timeScale = 0f;
        }
    }

    public void Respawn()
    {
        Time.timeScale = 1f;

        dead = false;

        GetUIElements.deathPanel.SetActive(false);

        gameObject.transform.localPosition = respawnLocation;

        Movement.enabled = true;
        thisRenderer.enabled = true;
        thisCollider.enabled = true;

        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);       

        GetTexts.txtPlayerHealthAmount.text = currentHealth.ToString("0") + " / " + maxHealth;
    }
}