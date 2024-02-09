using UnityEngine;
using TMPro;
using Steamworks;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Movement Movement;
    [SerializeField] private HealthBar HealthBar;
    [SerializeField] private StarSpawner StarSpawner;
    private Enemy Enemy;

    [SerializeField] private SpriteRenderer thisRenderer;

    [SerializeField] private Collider2D thisCollider;

    [SerializeField] private ParticleSystem deathParticle;

    [SerializeField] private AudioSource getHitAS;

    [SerializeField] private TMP_Text txtRemainingLife;
    public TMP_Text txt_starObjective;

    [SerializeField] private GameObject gameOverPanel;

    public float maxHealth;
    public float currentHealth;

    public TMP_Text txtPlayerHealthAmount;
    public TMP_Text txtPlayerName;

    private Vector3 respawnLocation;
    private Vector3 triggerPoint;

    public bool dead;

    public int gold;

    public int remainingLife;

    [SerializeField] private ParticleSystem getHitParticle;

    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject[] stars;

    private GameObject boss;

    public GameObject Fire;
    public GameObject Ice;
    public GameObject Poison;
    public GameObject Bullet;
    public GameObject Missile;
    public GameObject Arrow;
    public GameObject Electric;
    public GameObject Sword;

    [SerializeField] private GameObject fireDisplay;
    [SerializeField] private GameObject iceDisplay;
    [SerializeField] private GameObject poisonDisplay;
    [SerializeField] private GameObject gunDisplay;
    [SerializeField] private GameObject bazookaDisplay;
    [SerializeField] private GameObject bowDisplay;
    [SerializeField] private GameObject electricDisplay;
    [SerializeField] private GameObject swordDisplay;

    public int collectedGoldCurrentLevel;

    public int totalStars;
    public int collectedStars;
    public int bonusStarGold;

    private Color defaultPlayerColor;

    public GameObject tickIconStar, crossIconStar;

    private AudioSource[] AudioSources;

    public int enemiesKilled;

    private void Awake()
    {
        // PlayerPrefs kullanarak damage kaydedildi mi kontrol edilir, eðer kaydedilmiþse son deðer getirilir
        #region PlayerPrefs Damage

        if (PlayerPrefs.HasKey(Fire.name + "damage"))
            Fire.GetComponent<ProjectileDamage>().damage = PlayerPrefs.GetFloat(Fire.name + "damage");
        else
            Fire.GetComponent<ProjectileDamage>().damage = 3.2f;

        if (PlayerPrefs.HasKey(Ice.name + "damage"))
            Ice.GetComponent<ProjectileDamage>().damage = PlayerPrefs.GetFloat(Ice.name + "damage");
        else
            Ice.GetComponent<ProjectileDamage>().damage = 13.1f;

        if (PlayerPrefs.HasKey(Poison.name + "damage"))
            Poison.GetComponent<ProjectileDamage>().damage = PlayerPrefs.GetFloat(Poison.name + "damage");
        else
            Poison.GetComponent<ProjectileDamage>().damage = 4.2f;

        if (PlayerPrefs.HasKey(Bullet.name + "damage"))
            Bullet.GetComponent<ProjectileDamage>().damage = PlayerPrefs.GetFloat(Bullet.name + "damage");
        else
            Bullet.GetComponent<ProjectileDamage>().damage = 1.8f;

        if (PlayerPrefs.HasKey(Missile.name + "damage"))
            Missile.GetComponent<ProjectileDamage>().damage = PlayerPrefs.GetFloat(Missile.name + "damage");
        else
            Missile.GetComponent<ProjectileDamage>().damage = 12.5f;

        if (PlayerPrefs.HasKey(Arrow.name + "damage"))
            Arrow.GetComponent<ProjectileDamage>().damage = PlayerPrefs.GetFloat(Arrow.name + "damage");
        else
            Arrow.GetComponent<ProjectileDamage>().damage = 18.8f;

        if (PlayerPrefs.HasKey(Electric.name + "damage"))
            Electric.GetComponent<ProjectileDamage>().damage = PlayerPrefs.GetFloat(Electric.name + "damage");
        else
            Electric.GetComponent<ProjectileDamage>().damage = 6.5f;

        if (PlayerPrefs.HasKey(Sword.name + "damage"))
            Sword.GetComponent<ProjectileDamage>().damage = PlayerPrefs.GetFloat(Sword.name + "damage");
        else
            Sword.GetComponent<ProjectileDamage>().damage = 7.4f;

        #endregion

        // PlayerPrefs kullanarak fire rate kaydedildi mi kontrol edilir, eðer kaydedilmiþse son deðer getirilir
        #region PlayerPrefs Rate

        if (PlayerPrefs.HasKey(Fire.name + "rate"))
            Fire.GetComponent<ProjectileDamage>().rate = PlayerPrefs.GetFloat(Fire.name + "rate");
        else
            Fire.GetComponent<ProjectileDamage>().rate = 0.65f;

        if (PlayerPrefs.HasKey(Ice.name + "rate"))
            Ice.GetComponent<ProjectileDamage>().rate = PlayerPrefs.GetFloat(Ice.name + "rate");
        else
            Ice.GetComponent<ProjectileDamage>().rate = 1f;

        if (PlayerPrefs.HasKey(Poison.name + "rate"))
            Poison.GetComponent<ProjectileDamage>().rate = PlayerPrefs.GetFloat(Poison.name + "rate");
        else
            Poison.GetComponent<ProjectileDamage>().rate = 0.9f;

        if (PlayerPrefs.HasKey(Bullet.name + "rate"))
            Bullet.GetComponent<ProjectileDamage>().rate = PlayerPrefs.GetFloat(Bullet.name + "rate");
        else
            Bullet.GetComponent<ProjectileDamage>().rate = 0.2f;

        if (PlayerPrefs.HasKey(Missile.name + "rate"))
            Missile.GetComponent<ProjectileDamage>().rate = PlayerPrefs.GetFloat(Missile.name + "rate");
        else
            Missile.GetComponent<ProjectileDamage>().rate = 1.3f;

        if (PlayerPrefs.HasKey(Arrow.name + "rate"))
            Arrow.GetComponent<ProjectileDamage>().rate = PlayerPrefs.GetFloat(Arrow.name + "rate");
        else
            Arrow.GetComponent<ProjectileDamage>().rate = 1.5f;

        if (PlayerPrefs.HasKey(Electric.name + "rate"))
            Electric.GetComponent<ProjectileDamage>().rate = PlayerPrefs.GetFloat(Electric.name + "rate");
        else
            Electric.GetComponent<ProjectileDamage>().rate = 1f;

        if (PlayerPrefs.HasKey(Sword.name + "rate"))
            Sword.GetComponent<ProjectileDamage>().rate = PlayerPrefs.GetFloat(Sword.name + "rate");
        else
            Sword.GetComponent<ProjectileDamage>().rate = 0.6f;

        #endregion

        // PlayerPrefs kullanarak skill upgradeler, health, movement speed kaydedildi mi kontrol edilir, eðer kaydedilmiþse son deðer getirilir
        #region Skill Upgrade PlayerPrefs

        if (PlayerPrefs.HasKey("Max Health Purchase"))
            maxHealth = PlayerPrefs.GetFloat("Max Health Purchase");
        else
            maxHealth = 100;

        if (PlayerPrefs.HasKey("Movement Speed Purchase"))
            Movement.movementSpeed = PlayerPrefs.GetFloat("Movement Speed Purchase");
        else
            Movement.movementSpeed = 4f;

        if (PlayerPrefs.HasKey("Sprint Speed Purchase"))
            Movement.sprintSpeed = PlayerPrefs.GetFloat("Sprint Speed Purchase");
        else
            Movement.sprintSpeed = 10f;

        if (PlayerPrefs.HasKey("Sprint Cooldown Purchase"))
            Movement.sprintCooldown = PlayerPrefs.GetFloat("Sprint Cooldown Purchase");
        else
            Movement.sprintCooldown = 3f;

        if (PlayerPrefs.HasKey("Sprint Duration Purchase"))
            Movement.sprintLength = PlayerPrefs.GetFloat("Sprint Duration Purchase");
        else
            Movement.sprintLength = 1f;

        if (PlayerPrefs.HasKey("Freeze Duration Purchase"))
            Movement.freezeLength = PlayerPrefs.GetFloat("Freeze Duration Purchase");
        else
            Movement.freezeLength = 2f;

        if (PlayerPrefs.HasKey("Freeze Cooldown Purchase"))
            Movement.freezeCooldown = PlayerPrefs.GetFloat("Freeze Cooldown Purchase");
        else
            Movement.freezeCooldown = 40f;

        if (PlayerPrefs.HasKey("Shield Duration Purchase"))
            Movement.shieldLength = PlayerPrefs.GetFloat("Shield Duration Purchase");
        else
            Movement.shieldLength = 3f;

        if (PlayerPrefs.HasKey("Shield Cooldown Purchase"))
            Movement.shieldCooldown = PlayerPrefs.GetFloat("Shield Cooldown Purchase");
        else
            Movement.shieldCooldown = 10f;

        if (PlayerPrefs.HasKey("Mass Explosion Damage Purchase"))
            Movement.massExplosionDamage = PlayerPrefs.GetFloat("Mass Explosion Damage Purchase");
        else
            Movement.massExplosionDamage = 6;

        if (PlayerPrefs.HasKey("Mass Explosion Cooldown Purchase"))
            Movement.massExplosionCooldown = PlayerPrefs.GetFloat("Mass Explosion Cooldown Purchase");
        else
            Movement.massExplosionCooldown = 40f;

        #endregion
    }

    private void Start()
    {
        thisCollider = gameObject.GetComponent<Collider2D>();

        if (StarSpawner != null)
        {
            totalStars = StarSpawner.prefabToInstantiateCount;
            bonusStarGold = totalStars * 35;
            txt_starObjective.text = "• Collect <color=green>stars</color>." +
                " (" + collectedStars.ToString() + "/" + totalStars.ToString() + ")" + " <color=yellow>(+" + bonusStarGold.ToString() + "g)</color>";
        }

        defaultPlayerColor = gameObject.GetComponent<SpriteRenderer>().color;

        transform.localPosition = respawnLocation;

        txtPlayerName.text = SteamFriends.GetPersonaName();

        currentHealth = maxHealth;
        txtPlayerHealthAmount.text = maxHealth.ToString("F0") + " / " + maxHealth.ToString("F0");
        HealthBar.SetMaxHealth(maxHealth);

        collectedGoldCurrentLevel = 0;

        if (PlayerPrefs.HasKey("remainingLife"))
            remainingLife = PlayerPrefs.GetInt("remainingLife");
        else
            remainingLife = 5;

        if (PlayerPrefs.HasKey("FireWeaponUnlock"))
        {
            fireDisplay.SetActive(true);
        }

        if (PlayerPrefs.HasKey("IceWeaponUnlock"))
        {
            iceDisplay.SetActive(true);
        }

        if (PlayerPrefs.HasKey("PoisonWeaponUnlock"))
        {
            poisonDisplay.SetActive(true);
        }

        if (PlayerPrefs.HasKey("GunWeaponUnlock"))
        {
            gunDisplay.SetActive(true);
        }

        if (PlayerPrefs.HasKey("BazookaWeaponUnlock"))
        {
            bazookaDisplay.SetActive(true);
        }

        if (PlayerPrefs.HasKey("BowWeaponUnlock"))
        {
            bowDisplay.SetActive(true);
        }

        if (PlayerPrefs.HasKey("ElectricWeaponUnlock"))
        {
            electricDisplay.SetActive(true);
        }

        if (PlayerPrefs.HasKey("SwordWeaponUnlock"))
        {
            swordDisplay.SetActive(true);
        }

        if (tickIconStar != null)
        {
            tickIconStar.SetActive(false);
            crossIconStar.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        txtPlayerHealthAmount.text = currentHealth.ToString("F1") + " / " + maxHealth.ToString("F1");

        if (PlayerPrefs.HasKey("remainingLife"))
            txtRemainingLife.text = PlayerPrefs.GetInt("remainingLife").ToString() + "/5";
        else
            txtRemainingLife.text = "5/5";

        if (tickIconStar != null)
        {
            if (collectedStars == totalStars)
            {
                tickIconStar.SetActive(true);
                crossIconStar.SetActive(false);
            }
        }

        if (Movement.sprintMasteryClaimed)
        {
            if (Movement.sprinting)
                gameObject.tag = "SprintingPlayer";
            else
                gameObject.tag = "Player";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!dead)
        {
            if (gameObject.tag is "Player" && collision.gameObject.tag is "Enemy")
            {
                triggerPoint = collision.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position);

                Enemy = collision.gameObject.GetComponent<Enemy>();

                TakeDamage(Enemy.enemyDamage);

                Instantiate(getHitParticle, triggerPoint, Quaternion.identity);

                getHitAS.Play();

                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                Invoke(nameof(SetDefaultColor), 0.1f);
            }

            if (gameObject.tag is "Player" && collision.gameObject.tag is "Enemy Bullet")
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                Invoke(nameof(SetDefaultColor), 0.1f);
            }

            Die();
        }
    }
    private void SetDefaultColor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = defaultPlayerColor;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!dead)
        {
            if (gameObject.tag is "Player" && collision.gameObject.tag is "Enemy" || collision.gameObject.tag is "Boss")
            {
                Enemy = collision.gameObject.GetComponent<Enemy>();
                TakeDamage(Enemy.enemyTickDamage);
            }

            Die();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        HealthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        if (currentHealth <= 0)
        {
            Time.timeScale = 0f;

            dead = true;

            currentHealth = 0;

            thisCollider.enabled = false;

            remainingLife--;
            PlayerPrefs.SetInt("remainingLife", remainingLife);

            Movement.enabled = false;

            gold -= collectedGoldCurrentLevel;

            if (remainingLife > 0)
            {
                gameObject.transform.localPosition = respawnLocation;
                deathParticle.Play();

                thisRenderer.enabled = false;
                thisCollider.enabled = false;
            }
            else
            {
                gameOverPanel.SetActive(true);
                PlayerPrefs.DeleteAll();
            }
        }
    }

    public void Respawn()
    {
        Time.timeScale = 1f;

        dead = false;

        gameObject.transform.localPosition = respawnLocation;

        Movement.enabled = true;
        thisRenderer.enabled = true;
        thisCollider.enabled = true;

        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);

        collectedGoldCurrentLevel = 0;

        txtPlayerHealthAmount.text = PlayerPrefs.GetFloat("Max Health Purchase").ToString("F0") + " / " + maxHealth.ToString("F0");

        collectedStars = 0;

        if (StarSpawner != null)
            txt_starObjective.text = "• Collect stars." + " (" + collectedStars.ToString() + "/" + totalStars.ToString() + ")" + " <color=yellow>(+" + bonusStarGold.ToString() + "g)</color>"; txt_starObjective.text = "• Collect stars." + " (" + collectedStars.ToString() + "/" + totalStars.ToString() + ")" + " <color=yellow>(+" + bonusStarGold.ToString() + "g)</color>";

        #region Skill Reset

        Movement.activeMoveSpeed = Movement.movementSpeed;

        Movement.sprintCoolCounter = 0f;
        Movement.sprintCounter = 0f;
        Movement.skillBar.fillAmount = 0f;
        Movement.sprintDuration = Movement.sprintLength;
        Movement.txtSkillCD.text = " ";
        Movement.txtSkillDuration.text = " ";

        Movement.freezeCoolCounter = 0f;
        Movement.freezeCounter = 0f;
        Movement.skillBar2.fillAmount = 0f;
        Movement.freezeDuration = Movement.freezeLength;
        Movement.txtSkill2CD.text = " ";
        Movement.txtSkill2Duration.text = " ";

        Movement.shieldCoolCounter = 0f;
        Movement.shieldCounter = 0f;
        Movement.skillBar3.fillAmount = 0f;
        Movement.shieldDuration = Movement.shieldLength;
        Movement.txtSkill3CD.text = " ";
        Movement.txtSkill3Duration.text = " ";

        Movement.massExplosionCoolCounter = 0f;
        Movement.massExplosionCounter = 0f;
        Movement.skillBar4.fillAmount = 0f;
        Movement.massExplosionDuration = Movement.massExplosionLength;
        Movement.txtSkill4CD.text = " ";
        Movement.txtSkill4Duration.text = " ";

        #endregion

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        boss = GameObject.FindGameObjectWithTag("Boss");
        stars = GameObject.FindGameObjectsWithTag("Star");

        if (enemies.Length != 0)
        {
            for (int i = 0; i < enemies.Length; i++)
                Destroy(enemies[i]);
        }

        if (boss != null)
            boss.transform.position = new Vector3(27f, 0f, 0f);

        if (stars.Length != 0)
        {
            for (int i = 0; i < stars.Length; i++)
            {
                Vector2 spawnPos = stars[i].GetComponent<CollectStar>().spawnPosition;
                stars[i].transform.position = spawnPos;
            }
        }
    }
}