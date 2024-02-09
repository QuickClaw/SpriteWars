using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Movement : MonoBehaviour
{
    public float movementSpeed;
    SpriteRenderer playerSprite;

    public Rigidbody2D rb;
    Vector2 movement;

    public float activeMoveSpeed;
    public float sprintSpeed;
    public float sprintLength;
    public float sprintCooldown;
    public float sprintCounter;
    public float sprintCoolCounter;
    public float sprintDuration;

    private float defaultEnemySpeed;
    public float freezeLength;
    public float freezeCooldown;
    public float freezeCounter;
    public float freezeCoolCounter;
    public float freezeDuration;

    public float shieldLength;
    public float shieldCooldown;
    public float shieldCounter;
    public float shieldCoolCounter;
    public float shieldDuration;

    public float massExplosionDamage;
    public float massExplosionLength;
    public float massExplosionCooldown;
    public float massExplosionCounter;
    public float massExplosionCoolCounter;
    public float massExplosionDuration;

    public Image skillBar;
    public Image skillBar2;
    public Image skillBar3;
    public Image skillBar4;

    [SerializeField] private AudioSource sprintAS;
    [SerializeField] private AudioSource freezeAS;
    [SerializeField] private AudioSource shieldAS;
    [SerializeField] private AudioSource massExplosionAS;
    [SerializeField] private AudioSource sprintUpAS;

    public TMP_Text txtSkillCD;
    public TMP_Text txtSkill2CD;
    public TMP_Text txtSkill3CD;
    public TMP_Text txtSkill4CD;

    public TMP_Text txtSkillDuration;
    public TMP_Text txtSkill2Duration;
    public TMP_Text txtSkill3Duration;
    public TMP_Text txtSkill4Duration;

    [SerializeField] private ParticleSystem freezeEffect;
    [SerializeField] private ParticleSystem sprintEffect;
    [SerializeField] private ParticleSystem shieldEffect;
    [SerializeField] private ParticleSystem massExplosionEffect;

    [SerializeField] private GameObject shield;

    public ParticleSystem shieldExplode;

    private Color defaultEnemyColor;

    public bool sprintMasteryClaimed;
    public bool freezeMasteryClaimed;
    public bool shieldMasteryClaimed;
    public bool massMasteryClaimed;

    public int freezedEnemies;

    public bool sprinting;

    private Sprite defaultSprite;
    [SerializeField] private Sprite spriteRunning;

    private void Awake()
    {
        freezedEnemies = PlayerPrefs.GetInt("freezedEnemies");
    }

    private void Start()
    {
        sprinting = false;

        defaultSprite = gameObject.GetComponent<SpriteRenderer>().sprite;

        sprintDuration = sprintLength;
        freezeDuration = freezeLength;
        shieldDuration = shieldLength;
        massExplosionDuration = massExplosionLength;

        activeMoveSpeed = movementSpeed;

        skillBar.fillAmount = 0f;
        skillBar2.fillAmount = 0f;
        skillBar3.fillAmount = 0f;
        skillBar4.fillAmount = 0f;

        playerSprite = gameObject.GetComponent<SpriteRenderer>();

        if (PlayerPrefs.HasKey("Sprint_Mastery_Claimed"))
            sprintMasteryClaimed = true;

        if (PlayerPrefs.HasKey("Freeze_Mastery_Claimed"))
            freezeMasteryClaimed = true;

        if (PlayerPrefs.HasKey("Shield_Mastery_Claimed"))
            shieldMasteryClaimed = true;

        if (PlayerPrefs.HasKey("Mass_Mastery_Claimed"))
            massMasteryClaimed = true;
    }
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();

        rb.velocity = movement * activeMoveSpeed;

        if (Input.GetKey(KeyCode.A))
            playerSprite.flipX = true;

        if (Input.GetKey(KeyCode.D))
            playerSprite.flipX = false;

        Sprint();
        Freeze();
        Shield();
        MassExplosion();
    }

    public void Sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (sprintCoolCounter <= 0 && sprintCounter <= 0)
            {
                skillBar.fillAmount = 1;
                activeMoveSpeed = sprintSpeed;
                sprintCounter = sprintLength;

                sprintEffect.Play();
                sprintAS.Play();

                sprinting = true;

                gameObject.GetComponent<SpriteRenderer>().sprite = spriteRunning;
            }
        }

        if (sprintCounter > 0)
        {
            sprintCounter -= Time.deltaTime;
            sprintDuration -= Time.deltaTime;

            txtSkillDuration.text = sprintDuration.ToString("F1");

            if (sprintCounter <= 0)
            {
                activeMoveSpeed = movementSpeed;
                sprintCoolCounter = sprintCooldown;
                gameObject.GetComponent<Collider2D>().enabled = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = defaultSprite;
                sprintEffect.Stop();
                sprinting = false;
            }
        }

        if (sprintCoolCounter > 0)
        {
            sprintCoolCounter -= Time.deltaTime;

            skillBar.fillAmount -= Time.deltaTime / sprintCooldown;

            if (skillBar.fillAmount == 0f)
                sprintUpAS.Play();

            txtSkillDuration.text = " ";
            sprintDuration = sprintLength;
            txtSkillCD.text = sprintCoolCounter.ToString("F0");
        }
        else
        {
            txtSkillCD.text = " ";
        }
    }

    public void Freeze()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (freezeCoolCounter <= 0 && freezeCounter <= 0)
            {
                skillBar2.fillAmount = 1;

                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("Enemy Bullet");

                foreach (var enemy in enemies)
                    enemy.GetComponent<Enemy>().isFreezed = true;

                freezedEnemies += enemies.Length;
                PlayerPrefs.SetInt("freezedEnemies", freezedEnemies);

                for (int i = 0; i < enemyBullets.Length; i++)
                    enemyBullets[i].SetActive(false);

                if (freezeMasteryClaimed)
                {
                    freezeLength = 9999f;
                    freezeCounter = 2f;
                }
                else
                {
                    freezeCounter = freezeLength;
                }

                freezeEffect.Play();
                freezeAS.Play();
            }
        }

        if (freezeCounter > 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            freezeCounter -= Time.deltaTime;
            freezeDuration -= Time.deltaTime;

            txtSkill2Duration.text = freezeDuration.ToString("F1");

            if (freezeCounter <= 0)
            {
                if (!freezeMasteryClaimed)
                {
                    foreach (var enemy in enemies)
                        enemy.GetComponent<Enemy>().isFreezed = false;
                }

                freezeCoolCounter = freezeCooldown;
            }
        }

        if (freezeCoolCounter > 0)
        {
            freezeCoolCounter -= Time.deltaTime;
            skillBar2.fillAmount -= Time.deltaTime / freezeCooldown;

            if (skillBar2.fillAmount == 0f)
                sprintUpAS.Play();

            txtSkill2Duration.text = " ";
            freezeDuration = freezeLength;
            txtSkill2CD.text = freezeCoolCounter.ToString("F0");
        }
        else
        {
            txtSkill2CD.text = " ";
        }
    }

    public void Shield()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (shieldCoolCounter <= 0 && shieldCounter <= 0)
            {
                skillBar3.fillAmount = 1;
                shieldCounter = shieldLength;
                shield.SetActive(true);

                shieldEffect.Play();
                shieldAS.Play();
            }
        }

        if (shieldCounter > 0)
        {
            shieldCounter -= Time.deltaTime;
            shieldDuration -= Time.deltaTime;

            txtSkill3Duration.text = shieldDuration.ToString("F1");

            if (shieldCounter <= 0)
            {
                shieldCoolCounter = shieldCooldown;
                shield.SetActive(false);

                if (shieldMasteryClaimed) // Mastery panelden shield mastery aldýysa açýlýr
                {
                    shieldExplode.Play();
                    shieldAS.Play();

                    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

                    if (enemies.Length > 0)
                    {
                        for (int i = 0; i < enemies.Length; i++)
                            enemies[i].GetComponent<Enemy>().TakeDamage(25);
                    }
                }
            }
        }

        if (shieldCoolCounter > 0)
        {
            shieldCoolCounter -= Time.deltaTime;

            skillBar3.fillAmount -= Time.deltaTime / shieldCooldown;

            if (skillBar3.fillAmount == 0f)
                sprintUpAS.Play();

            txtSkill3Duration.text = " ";
            shieldDuration = shieldLength;
            txtSkill3CD.text = shieldCoolCounter.ToString("F0");
        }
        else
        {
            txtSkill3CD.text = " ";
        }
    }

    public void MassExplosion()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("Enemy Bullet");
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (massExplosionCoolCounter <= 0 && massExplosionCounter <= 0)
            {
                if (!massMasteryClaimed)
                {
                    if (enemies.Length > 0)
                    {
                        for (int i = 0; i < enemies.Length; i++)
                            enemies[i].GetComponent<Enemy>().TakeDamage(massExplosionDamage);
                    }
                }
                else
                {
                    if (enemies.Length > 0)
                    {
                        for (int i = 0; i < enemies.Length; i++)
                            enemies[i].GetComponent<Enemy>().TakeDamage(massExplosionDamage + 15);
                    }
                }

                skillBar4.fillAmount = 1;

                for (int i = 0; i < enemyBullets.Length; i++)
                    enemyBullets[i].SetActive(false);

                massExplosionCounter = massExplosionLength;

                massExplosionEffect.Play();
                massExplosionAS.Play();
            }
        }

        if (massExplosionCounter > 0)
        {
            massExplosionCounter -= Time.deltaTime;
            massExplosionDuration -= Time.deltaTime;

            txtSkill4Duration.text = massExplosionDuration.ToString("F1");

            if (massExplosionCounter <= 0)
            {
                massExplosionCoolCounter = massExplosionCooldown;
            }
        }

        if (massExplosionCoolCounter > 0)
        {
            massExplosionCoolCounter -= Time.deltaTime;
            skillBar4.fillAmount -= Time.deltaTime / massExplosionCooldown;

            if (skillBar4.fillAmount == 0f)
                sprintUpAS.Play();

            txtSkill4Duration.text = " ";
            massExplosionDuration = massExplosionLength;
            txtSkill4CD.text = massExplosionCoolCounter.ToString("F0");
        }
        else
        {
            txtSkill4CD.text = " ";
        }
    }
}