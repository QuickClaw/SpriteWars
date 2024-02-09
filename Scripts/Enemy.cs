using UnityEngine;
using TMPro;
using Steamworks;

public class Enemy : MonoBehaviour
{
    private GetAudioSources GetAudioSources;
    private GetParticles GetParticles;
    private ProjectileProperties ProjectileProperties;
    private Timer Timer;
    private PlayerScript PlayerScript;

    [Header("Scripts")]
    [SerializeField] private HealthBar HealthBar;
    [SerializeField] private StatusEffectManager StatusEffectManager;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource deathAS;
    [SerializeField] private AudioSource impactAS;

    [Header("Canvas Elements")]
    [SerializeField] private Canvas enemyCanvas;
    [SerializeField] private TMP_Text txt_EnemyHealth;

    [Header("Colliders & Effects")]
    [SerializeField] private GameObject missileExplosionCollider; // Füze patlama hasarý collider
    public Collider2D thisCollider;

    public SpriteRenderer thisRenderer;

    public ParticleSystem deathEffect;
    public ParticleSystem burnEffect;
    public ParticleSystem poisonEffect;

    [Header("Enemy Attributes")]
    public float maxHealth;
    public float currentHealth;
    public float enemyDamage;
    public float enemyTickDamage;
    public float enemySpeed;

    [SerializeField] private int goldValueMin, goldValueMax; // Düþmandan düþen gold miktarý

    private GameObject player;

    private Vector3 triggerPoint;

    private Collider2D swordCollider;

    public bool dead;

    private Color defaultEnemyColor;

    private bool isBoss;

    private Color previousColor;

    [SerializeField] private GameObject txtKillGold;

    public GameObject enemyHealthBar;

    public bool isFreezed;

    private float defaultSpeed;

    [Header("Last Boss")]
    [SerializeField] private GameObject TheEye;
    [SerializeField] private AudioSource theEyeAS;
    [SerializeField] private ParticleSystem theEyeSpawnEffect;

    private float fireRate;
    private float shootingInterval;

    void Start()
    {
        defaultEnemyColor = gameObject.GetComponent<SpriteRenderer>().color;
        defaultSpeed = enemySpeed;

        GetAudioSources = FindObjectOfType<GetAudioSources>();
        GetParticles = FindObjectOfType<GetParticles>();
        ProjectileProperties = FindObjectOfType<ProjectileProperties>();
        Timer = FindObjectOfType<Timer>();
        PlayerScript = FindObjectOfType<PlayerScript>();

        player = GameObject.Find("Player");

        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);

        txt_EnemyHealth.text = maxHealth.ToString("F1");

        swordCollider = GameObject.Find("swordCollider").GetComponent<Collider2D>();

        if (gameObject.tag is "Boss")
            isBoss = true;

        PlayerScript.enemiesKilled = PlayerPrefs.GetInt("enemiesKilled");

        gameObject.GetComponentInChildren<Canvas>().worldCamera = GameObject.Find("Camera").GetComponent<Camera>();

        if (gameObject.GetComponent<FireEnemyBullet>() != null)
            fireRate = gameObject.GetComponent<FireEnemyBullet>().fireRate;

        if(gameObject.GetComponent<RadialShoot>() != null)
            shootingInterval = gameObject.GetComponent<RadialShoot>().shootingInterval;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemySpeed * Time.deltaTime);

        if (!dead)
            Die();

        if (isFreezed)
        {
            enemySpeed = 0;
            thisRenderer.color = Color.blue;

            if (gameObject.GetComponent<FireEnemyBullet>() != null)
                gameObject.GetComponent<FireEnemyBullet>().fireRate = 10000;

            if (gameObject.GetComponent<RadialShoot>() != null)
                gameObject.GetComponent<RadialShoot>().shootingInterval = 10000;
        }
        else if (!dead)
        {
            enemySpeed = defaultSpeed;
            thisRenderer.color = defaultEnemyColor;

            if (gameObject.GetComponent<FireEnemyBullet>() != null)
                gameObject.GetComponent<FireEnemyBullet>().fireRate = fireRate;

            if (gameObject.GetComponent<RadialShoot>() != null)
                gameObject.GetComponent<RadialShoot>().shootingInterval = shootingInterval;
        }
    }

    private void SetDefaultColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = previousColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag is "Projectile") // Kullanýcýnýn atýþý düþman ile temas ettiðinde
        {
            triggerPoint = collision.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position);

            previousColor = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Invoke(nameof(SetDefaultColor), 0.02f);

            if (!dead)
            {
                #region Fire Collision
                if (collision.name is "Fire(Clone)")
                {
                    TakeDamage(collision.GetComponent<ProjectileDamage>().damage);

                    Instantiate(GetParticles.impactParticles[0], triggerPoint, Quaternion.identity);

                    impactAS.clip = GetAudioSources.impactSounds[0];
                    impactAS.Play();

                    StatusEffectManager.ApplyBurn(5);

                    Destroy(collision.gameObject);
                }
                #endregion

                #region Ice Collision
                if (collision.name is "Ice(Clone)")
                {
                    TakeDamage(collision.GetComponent<ProjectileDamage>().damage);

                    Instantiate(GetParticles.impactParticles[1], triggerPoint, Quaternion.identity);

                    impactAS.clip = GetAudioSources.impactSounds[1];
                    impactAS.Play();

                    Destroy(collision.gameObject);
                }
                #endregion

                #region Poison Collision
                if (collision.name is "Poison(Clone)")
                {
                    TakeDamage(collision.GetComponent<ProjectileDamage>().damage);

                    Instantiate(GetParticles.impactParticles[2], triggerPoint, Quaternion.identity);

                    impactAS.clip = GetAudioSources.impactSounds[2];
                    impactAS.Play();

                    StatusEffectManager.ApplyPoison(20);

                    Destroy(collision.gameObject);
                }
                #endregion

                #region Bullet Collision
                if (collision.name is "Bullet(Clone)")
                {
                    TakeDamage(collision.GetComponent<ProjectileDamage>().damage);

                    Instantiate(GetParticles.impactParticles[3], triggerPoint, Quaternion.identity);

                    impactAS.clip = GetAudioSources.impactSounds[3];
                    impactAS.Play();

                    Destroy(collision.gameObject);
                }
                #endregion

                #region Missile Collision
                if (collision.name is "MissilePrefab(Clone)")
                {
                    Instantiate(GetParticles.impactParticles[4], triggerPoint, Quaternion.identity);

                    Instantiate(missileExplosionCollider, triggerPoint, Quaternion.identity);

                    impactAS.clip = GetAudioSources.impactSounds[4];
                    impactAS.Play();

                    Destroy(collision.gameObject);
                }
                #endregion

                #region Arrow Collision
                if (collision.name is "Arrow(Clone)")
                {
                    TakeDamage(collision.GetComponent<ProjectileDamage>().damage);

                    Instantiate(GetParticles.impactParticles[5], triggerPoint, Quaternion.identity);

                    impactAS.clip = GetAudioSources.impactSounds[5];
                    impactAS.Play();

                    Destroy(collision.gameObject);
                }
                #endregion

                #region Electric Collision
                if (collision.name is "Electric(Clone)")
                {
                    collision.GetComponent<DestroyObject>().penetrationCount++;

                    TakeDamage(collision.GetComponent<ProjectileDamage>().damage);

                    Instantiate(GetParticles.impactParticles[6], triggerPoint, Quaternion.identity);

                    impactAS.clip = GetAudioSources.impactSounds[6];
                    impactAS.Play();

                    if (collision.GetComponent<DestroyObject>().penetrationCount == 2)
                        Destroy(collision.gameObject);
                }
                #endregion
            }
        }

        // Patlama hasarý için collider temasý
        if (collision.name is "Missile(Clone)")
        {
            TakeDamage(collision.GetComponent<ProjectileDamage>().damage);
        }

        // Kýlýç hasarý için collider temasý
        if (collision.name is "swordCollider")
        {
            previousColor = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            Invoke(nameof(SetDefaultColor), 0.02f);

            TakeDamage(collision.GetComponent<ProjectileDamage>().damage);

            triggerPoint = collision.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position);
            Instantiate(GetParticles.impactParticles[7], triggerPoint, Quaternion.identity);

            impactAS.clip = GetAudioSources.impactSounds[7];
            impactAS.Play();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        HealthBar.SetHealth(currentHealth);

        txt_EnemyHealth.text = currentHealth.ToString("F1");
    }

    public void Die()
    {
        if (currentHealth <= 0)
        {
            enemySpeed = 0f;

            Instantiate(deathEffect, transform.position, Quaternion.identity);
            deathAS.Play();

            int randomGold = Random.Range(goldValueMin, goldValueMax);
            PlayerScript.gold += randomGold;
            PlayerScript.collectedGoldCurrentLevel += randomGold;

            txtKillGold.SetActive(true);
            txtKillGold.GetComponent<TMP_Text>().text = randomGold.ToString();

            thisRenderer.enabled = false;
            thisCollider.enabled = false;
            txt_EnemyHealth.enabled = false;
            enemyHealthBar.SetActive(false);

            Destroy(gameObject, 2.5f);

            if (gameObject.GetComponent<FireEnemyBullet>() != null) // Düþman uzaktan ateþ edebiliyor mu kontrol eder
                gameObject.GetComponent<FireEnemyBullet>().fireRate = 10000;

            if (gameObject.GetComponent<RadialShoot>() != null)
                gameObject.GetComponent<RadialShoot>().shootingInterval = 10000;

            dead = true;
            Timer.deadEnemies++;

            PlayerScript.enemiesKilled++;
            PlayerPrefs.SetInt("enemiesKilled", PlayerScript.enemiesKilled);

            if (isBoss)
            {
                Timer.defeatedBossCount++;
                Timer.currentTime = 5f;
            }

            if (gameObject.name is "Boss 1")
            {
                SteamUserStats.SetAchievement("achievement_05");
                SteamUserStats.StoreStats();
            }

            if (gameObject.name is "Boss 2")
            {
                SteamUserStats.SetAchievement("achievement_06");
                SteamUserStats.StoreStats();
            }

            if (gameObject.name is "Boss 3")
            {
                SteamUserStats.SetAchievement("achievement_07");
                SteamUserStats.StoreStats();
            }

            if (gameObject.name is "Boss 5")
            {
                SteamUserStats.SetAchievement("achievement_08");
                SteamUserStats.StoreStats();
            }

            if (gameObject.name is "Boss 4")
                Invoke(nameof(SpawnTheEye), 2.4f);
        }
    }

    public void DeactivateObject()
    {
        txtKillGold.gameObject.SetActive(false);
    }

    public void SpawnTheEye()
    {
        Instantiate(TheEye, new Vector3(23, 0, 0), Quaternion.identity);
        Instantiate(theEyeSpawnEffect, new Vector3(23, 0, 0), Quaternion.identity);
        theEyeAS.Play();
        Timer.bossName = "The Eye";
    }
}