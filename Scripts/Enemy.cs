using System.Linq;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GetAudioSources GetAudioSources;
    GetParticles GetParticles;
    HealthBar HealthBar;
    EnemyFollow EnemyFollow;
    ShowDamage ShowDamage;
    StatusEffectManager StatusEffectManager;

    public SpriteRenderer thisRenderer;
    public Collider2D thisCollider;

    public ParticleSystem deathEffect;
    public ParticleSystem burnEffect;
    public ParticleSystem poisonEffect;

    public Canvas enemyCanvas;

    AudioSource deathAS;
    AudioSource impactAS;

    public float maxHealth;
    public float currentHealth;
    public float enemyDamage;
    public float enemyTickDamage;

    Vector3 triggerPoint;

    public Collider2D missileExplosionCollider;

    bool dead;

    public int deadEnemies;

    void Start()
    {
        GetAudioSources = FindObjectOfType<GetAudioSources>();
        GetParticles = FindObjectOfType<GetParticles>();

        thisRenderer = gameObject.GetComponent<SpriteRenderer>();
        thisCollider = gameObject.GetComponent<Collider2D>();

        HealthBar = gameObject.GetComponent<HealthBar>();
        EnemyFollow = gameObject.GetComponent<EnemyFollow>();
        ShowDamage = gameObject.GetComponent<ShowDamage>();
        StatusEffectManager = gameObject.GetComponent<StatusEffectManager>();

        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);

        deathAS = gameObject.GetComponent<AudioSource>();

        deathEffect = gameObject.GetComponentsInChildren<ParticleSystem>().ToList().Find(x => x.name.Contains("deathEffect"));
        burnEffect = gameObject.GetComponentsInChildren<ParticleSystem>().ToList().Find(x => x.name.Contains("burnEffect"));
        poisonEffect = gameObject.GetComponentsInChildren<ParticleSystem>().ToList().Find(x => x.name.Contains("poisonEffect"));

        impactAS = gameObject.GetComponentsInChildren<AudioSource>().ToList().Find(x => x.name.Contains("ImpactAS Holder"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag is "Projectile")
        {
            StatusEffectManager.enabled = true;

            triggerPoint = collision.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position);

            if (!dead)
            {
                Destroy(collision.gameObject);

                TakeDamage(Projectile.damage);

                if (collision.name is "Fire(Clone)")
                {
                    GetParticles.impactParticles[0].transform.position = triggerPoint;
                    GetParticles.impactParticles[0].Play();

                    impactAS.clip = GetAudioSources.impactSounds[0];
                    impactAS.Play();

                    StatusEffectManager.ApplyBurn(4);
                }

                if (collision.name is "Ice(Clone)")
                {
                    GetParticles.impactParticles[1].transform.position = triggerPoint;
                    GetParticles.impactParticles[1].Play();

                    impactAS.clip = GetAudioSources.impactSounds[1];
                    impactAS.Play();

                    StatusEffectManager.ApplySlow(1);
                }

                if (collision.name is "Poison(Clone)")
                {
                    GetParticles.impactParticles[2].transform.position = triggerPoint;
                    GetParticles.impactParticles[2].Play();

                    impactAS.clip = GetAudioSources.impactSounds[2];
                    impactAS.Play();

                    StatusEffectManager.ApplyPoison(20);
                }

                if (collision.name is "Bullet(Clone)")
                {
                    GetParticles.impactParticles[3].transform.position = triggerPoint;
                    GetParticles.impactParticles[3].Play();

                    impactAS.clip = GetAudioSources.impactSounds[3];
                    impactAS.Play();
                }

                if (collision.name is "Missile(Clone)")
                {
                    GetParticles.impactParticles[4].transform.position = triggerPoint;
                    GetParticles.impactParticles[4].Play();

                    missileExplosionCollider.transform.position = triggerPoint;
                    missileExplosionCollider.enabled = true;

                    Invoke(nameof(SendAwayExplosionCollider), 0.3f);

                    impactAS.clip = GetAudioSources.impactSounds[4];
                    impactAS.Play();
                }

                if (collision.name is "Arrow(Clone)")
                {
                    GetParticles.impactParticles[5].transform.position = triggerPoint;
                    GetParticles.impactParticles[5].Play();

                    impactAS.clip = GetAudioSources.impactSounds[5];
                    impactAS.Play();
                }

                if (collision.name is "Electric(Clone)")
                {
                    GetParticles.impactParticles[6].transform.position = triggerPoint;
                    GetParticles.impactParticles[6].Play();

                    impactAS.clip = GetAudioSources.impactSounds[6];
                    impactAS.Play();
                }
            }           
        }

        if (collision.name is "MissileExplosionCollider")
        {
            TakeDamage(Projectile.damage);
        }

        Die();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        HealthBar.SetHealth(currentHealth);

        ShowDamage.txt_EnemyHealth.text = currentHealth.ToString("0");
    }

    public void Die()
    {
        if (currentHealth <= 0)
        {
            deathEffect.Play();
            deathAS.Play();

            thisRenderer.enabled = false;
            thisCollider.enabled = false;
            EnemyFollow.enabled = false;
            ShowDamage.txt_EnemyHealth.enabled = false;

            enemyCanvas.enabled = false;

            Destroy(gameObject, 2.5f);

            dead = true;
            deadEnemies++;
        }
    }

    void SendAwayExplosionCollider()
    {
        missileExplosionCollider.transform.position = new Vector3(5000f, 5000f, 5000f);
    }
}