using UnityEngine;

public class PickupProjectile : MonoBehaviour
{
    public ProjectileProperties ProjectileProperties;
    public Shooting Shooting;
    public PlayerScript PlayerScript;

    public GameObject fire, ice, poison, bullet, missile, arrow, electric, swordAttack;

    [SerializeField] private GameObject fireWand, iceWand, snake, autoGun, bazooka, bow, lightning, sword;
    [SerializeField] private GameObject rotatePoint;

    [SerializeField] private ParticleSystem pickFire, pickIce, pickPoison, pickBullet, pickMissile, pickBow, pickElectric, pickSword;
    [SerializeField] private ParticleSystem fireVFX, iceVFX, poisonVFX, bulletVFX, missileVFX, bowVFX, electricVFX, swordVFX;

    [SerializeField] private AudioClip fireShoot, iceShoot, poisonShoot, bulletShoot, missileShoot, bowShoot, electricShoot, swordShoot;

    [SerializeField] private GameObject pickupArea_Fire;
    [SerializeField] private GameObject pickupArea_Ice;
    [SerializeField] private GameObject pickupArea_Poison;
    [SerializeField] private GameObject pickupArea_Gun;
    [SerializeField] private GameObject pickupArea_Bazooka;
    [SerializeField] private GameObject pickupArea_Bow;
    [SerializeField] private GameObject pickupArea_Electric;
    [SerializeField] private GameObject pickupArea_Sword;

    public AudioSource pickUpAS, shootingAS;

    private bool isFire, isIce, isPoison, isBullet, isMissile, isArrow, isElectric;

    public bool isSword;

    void Start()
    {
        if (PlayerPrefs.HasKey("Weapon"))
        {
            if (PlayerPrefs.GetString("Weapon") == "Fire")
                FirePickup();

            if (PlayerPrefs.GetString("Weapon") == "Ice")
                IcePickup();

            if (PlayerPrefs.GetString("Weapon") == "Poison")
                PoisonPickup();

            if (PlayerPrefs.GetString("Weapon") == "Gun")
                GunPickup();

            if (PlayerPrefs.GetString("Weapon") == "Bazooka")
                BazookaPickup();

            if (PlayerPrefs.GetString("Weapon") == "Bow")
                BowPickup();

            if (PlayerPrefs.GetString("Weapon") == "Electric")
                ElectricPickup();

            if (PlayerPrefs.GetString("Weapon") == "Sword")
                SwordPickup();
        }
        else
            FirePickup();

        if (PlayerPrefs.GetInt("FireUnlocked") == 1)
        {
            pickupArea_Fire.SetActive(true);
        }

        if (PlayerPrefs.GetInt("IceUnlocked") == 1)
        {
            pickupArea_Ice.SetActive(true);
        }

        if (PlayerPrefs.GetInt("PoisonUnlocked") == 1)
        {
            pickupArea_Poison.SetActive(true);
        }

        if (PlayerPrefs.GetInt("GunUnlocked") == 1)
        {
            pickupArea_Gun.SetActive(true);
        }

        if (PlayerPrefs.GetInt("BazookaUnlocked") == 1)
        {
            pickupArea_Bazooka.SetActive(true);
        }

        if (PlayerPrefs.GetInt("BowUnlocked") == 1)
        {
            pickupArea_Bow.SetActive(true);
        }

        if (PlayerPrefs.GetInt("ElectricUnlocked") == 1)
        {
            pickupArea_Electric.SetActive(true);          
        }

        if (PlayerPrefs.GetInt("SwordUnlocked") == 1)
        {
            pickupArea_Sword.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            PlayerPrefs.DeleteAll();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag is "Fire")
            FirePickup();

        if (collision.tag is "Ice")
            IcePickup();

        if (collision.tag is "Poison")
            PoisonPickup();

        if (collision.tag is "Bullet")
            GunPickup();

        if (collision.tag is "Missile")
            BazookaPickup();

        if (collision.tag is "Arrow")
            BowPickup();

        if (collision.tag is "Electric")
            ElectricPickup();

        if (collision.tag is "Sword")
            SwordPickup();
    }

    #region Pickup Methods
    public void FirePickup()
    {
        if (!isFire)
        {
            Shooting.projectilePrefab = fire;
            Shooting.force = ProjectileProperties.fireForce;
            Shooting.timeBetweenFiring = PlayerScript.Fire.GetComponent<ProjectileDamage>().rate;
            Shooting.shootingParticle = fireVFX;

            shootingAS.clip = fireShoot;

            pickUpAS.Play();
            pickFire.Play();

            isFire = true;
            isIce = false;
            isPoison = false;
            isBullet = false;
            isMissile = false;
            isArrow = false;
            isElectric = false;
            isSword = false;

            fireWand.GetComponent<SpriteRenderer>().enabled = true;
            iceWand.GetComponent<SpriteRenderer>().enabled = false;
            snake.GetComponent<SpriteRenderer>().enabled = false;
            autoGun.GetComponent<SpriteRenderer>().enabled = false;
            bazooka.GetComponent<SpriteRenderer>().enabled = false;
            bow.GetComponent<SpriteRenderer>().enabled = false;
            lightning.GetComponent<SpriteRenderer>().enabled = false;
            sword.GetComponent<SpriteRenderer>().enabled = false;

            PlayerPrefs.DeleteKey("Weapon");
            PlayerPrefs.SetString("Weapon", "Fire");
            PlayerPrefs.SetInt("FireUnlocked", 1);
        }
    }

    public void IcePickup()
    {
        if (!isIce)
        {
            Shooting.projectilePrefab = ice;
            Shooting.force = ProjectileProperties.iceForce;
            Shooting.timeBetweenFiring = PlayerScript.Ice.GetComponent<ProjectileDamage>().rate;
            Shooting.shootingParticle = iceVFX;

            shootingAS.clip = iceShoot;

            pickUpAS.Play();
            pickIce.Play();

            isFire = false;
            isIce = true;
            isPoison = false;
            isBullet = false;
            isMissile = false;
            isArrow = false;
            isElectric = false;
            isSword = false;

            fireWand.GetComponent<SpriteRenderer>().enabled = false;
            iceWand.GetComponent<SpriteRenderer>().enabled = true;
            snake.GetComponent<SpriteRenderer>().enabled = false;
            autoGun.GetComponent<SpriteRenderer>().enabled = false;
            bazooka.GetComponent<SpriteRenderer>().enabled = false;
            bow.GetComponent<SpriteRenderer>().enabled = false;
            lightning.GetComponent<SpriteRenderer>().enabled = false;
            sword.GetComponent<SpriteRenderer>().enabled = false;

            PlayerPrefs.DeleteKey("Weapon");
            PlayerPrefs.SetString("Weapon", "Ice");
            PlayerPrefs.SetInt("IceUnlocked", 1);
        }
    }

    public void PoisonPickup()
    {
        if (!isPoison)
        {
            Shooting.projectilePrefab = poison;
            Shooting.force = ProjectileProperties.poisonForce;
            Shooting.timeBetweenFiring = PlayerScript.Poison.GetComponent<ProjectileDamage>().rate;
            Shooting.shootingParticle = poisonVFX;

            shootingAS.clip = poisonShoot;

            pickUpAS.Play();
            pickPoison.Play();

            isFire = false;
            isIce = false;
            isPoison = true;
            isBullet = false;
            isMissile = false;
            isArrow = false;
            isElectric = false;
            isSword = false;

            fireWand.GetComponent<SpriteRenderer>().enabled = false;
            iceWand.GetComponent<SpriteRenderer>().enabled = false;
            snake.GetComponent<SpriteRenderer>().enabled = true;
            autoGun.GetComponent<SpriteRenderer>().enabled = false;
            bazooka.GetComponent<SpriteRenderer>().enabled = false;
            bow.GetComponent<SpriteRenderer>().enabled = false;
            lightning.GetComponent<SpriteRenderer>().enabled = false;
            sword.GetComponent<SpriteRenderer>().enabled = false;

            PlayerPrefs.DeleteKey("Weapon");
            PlayerPrefs.SetString("Weapon", "Poison");
            PlayerPrefs.SetInt("PoisonUnlocked", 1);
        }
    }

    public void GunPickup()
    {
        if (!isBullet)
        {
            Shooting.projectilePrefab = bullet;
            Shooting.force = ProjectileProperties.bulletForce;
            Shooting.timeBetweenFiring = PlayerScript.Bullet.GetComponent<ProjectileDamage>().rate;
            Shooting.shootingParticle = bulletVFX;

            shootingAS.clip = bulletShoot;

            pickUpAS.Play();
            pickBullet.Play();

            isFire = false;
            isIce = false;
            isPoison = false;
            isBullet = true;
            isMissile = false;
            isArrow = false;
            isElectric = false;
            isSword = false;

            fireWand.GetComponent<SpriteRenderer>().enabled = false;
            iceWand.GetComponent<SpriteRenderer>().enabled = false;
            snake.GetComponent<SpriteRenderer>().enabled = false;
            autoGun.GetComponent<SpriteRenderer>().enabled = true;
            bazooka.GetComponent<SpriteRenderer>().enabled = false;
            bow.GetComponent<SpriteRenderer>().enabled = false;
            lightning.GetComponent<SpriteRenderer>().enabled = false;
            sword.GetComponent<SpriteRenderer>().enabled = false;

            PlayerPrefs.DeleteKey("Weapon");
            PlayerPrefs.SetString("Weapon", "Gun");
            PlayerPrefs.SetInt("GunUnlocked", 1);
        }
    }

    public void BazookaPickup()
    {
        if (!isMissile)
        {
            Shooting.projectilePrefab = missile;
            Shooting.force = ProjectileProperties.missileForce;
            Shooting.timeBetweenFiring = PlayerScript.Missile.GetComponent<ProjectileDamage>().rate;
            Shooting.shootingParticle = missileVFX;

            shootingAS.clip = missileShoot;

            pickUpAS.Play();
            pickMissile.Play();

            isFire = false;
            isIce = false;
            isPoison = false;
            isBullet = false;
            isMissile = true;
            isArrow = false;
            isElectric = false;
            isSword = false;

            fireWand.GetComponent<SpriteRenderer>().enabled = false;
            iceWand.GetComponent<SpriteRenderer>().enabled = false;
            snake.GetComponent<SpriteRenderer>().enabled = false;
            autoGun.GetComponent<SpriteRenderer>().enabled = false;
            bazooka.GetComponent<SpriteRenderer>().enabled = true;
            bow.GetComponent<SpriteRenderer>().enabled = false;
            lightning.GetComponent<SpriteRenderer>().enabled = false;
            sword.GetComponent<SpriteRenderer>().enabled = false;

            PlayerPrefs.DeleteKey("Weapon");
            PlayerPrefs.SetString("Weapon", "Bazooka");
            PlayerPrefs.SetInt("BazookaUnlocked", 1);
        }
    }

    public void BowPickup()
    {
        if (!isArrow)
        {
            Shooting.projectilePrefab = arrow;
            Shooting.force = ProjectileProperties.arrowForce;
            Shooting.timeBetweenFiring = PlayerScript.Arrow.GetComponent<ProjectileDamage>().rate;
            Shooting.shootingParticle = bowVFX;

            shootingAS.clip = bowShoot;

            pickUpAS.Play();
            pickBow.Play();

            isFire = false;
            isIce = false;
            isPoison = false;
            isBullet = false;
            isMissile = false;
            isArrow = true;
            isElectric = false;
            isSword = false;

            fireWand.GetComponent<SpriteRenderer>().enabled = false;
            iceWand.GetComponent<SpriteRenderer>().enabled = false;
            snake.GetComponent<SpriteRenderer>().enabled = false;
            autoGun.GetComponent<SpriteRenderer>().enabled = false;
            bazooka.GetComponent<SpriteRenderer>().enabled = false;
            bow.GetComponent<SpriteRenderer>().enabled = true;
            lightning.GetComponent<SpriteRenderer>().enabled = false;
            sword.GetComponent<SpriteRenderer>().enabled = false;

            PlayerPrefs.DeleteKey("Weapon");
            PlayerPrefs.SetString("Weapon", "Bow");
            PlayerPrefs.SetInt("BowUnlocked", 1);
        }
    }

    public void ElectricPickup()
    {
        if (!isElectric)
        {
            Shooting.projectilePrefab = electric;
            Shooting.force = ProjectileProperties.electricForce;
            Shooting.timeBetweenFiring = PlayerScript.Electric.GetComponent<ProjectileDamage>().rate;
            Shooting.shootingParticle = electricVFX;

            shootingAS.clip = electricShoot;

            pickUpAS.Play();
            pickElectric.Play();

            isFire = false;
            isIce = false;
            isPoison = false;
            isBullet = false;
            isMissile = false;
            isArrow = false;
            isElectric = true;
            isSword = false;

            fireWand.GetComponent<SpriteRenderer>().enabled = false;
            iceWand.GetComponent<SpriteRenderer>().enabled = false;
            snake.GetComponent<SpriteRenderer>().enabled = false;
            autoGun.GetComponent<SpriteRenderer>().enabled = false;
            bazooka.GetComponent<SpriteRenderer>().enabled = false;
            bow.GetComponent<SpriteRenderer>().enabled = false;
            lightning.GetComponent<SpriteRenderer>().enabled = true;
            sword.GetComponent<SpriteRenderer>().enabled = false;

            PlayerPrefs.DeleteKey("Weapon");
            PlayerPrefs.SetString("Weapon", "Electric");
            PlayerPrefs.SetInt("ElectricUnlocked", 1);
        }
    }

    public void SwordPickup()
    {
        if (!isSword)
        {
            Shooting.projectilePrefab = swordAttack;
            Shooting.force = ProjectileProperties.swordForce;
            Shooting.timeBetweenFiring = PlayerScript.Sword.GetComponent<ProjectileDamage>().rate;
            Shooting.shootingParticle = swordVFX;

            shootingAS.clip = swordShoot;

            pickUpAS.Play();
            pickSword.Play();

            isFire = false;
            isIce = false;
            isPoison = false;
            isBullet = false;
            isMissile = false;
            isArrow = false;
            isElectric = false;
            isSword = true;

            fireWand.GetComponent<SpriteRenderer>().enabled = false;
            iceWand.GetComponent<SpriteRenderer>().enabled = false;
            snake.GetComponent<SpriteRenderer>().enabled = false;
            autoGun.GetComponent<SpriteRenderer>().enabled = false;
            bazooka.GetComponent<SpriteRenderer>().enabled = false;
            bow.GetComponent<SpriteRenderer>().enabled = false;
            lightning.GetComponent<SpriteRenderer>().enabled = false;
            sword.GetComponent<SpriteRenderer>().enabled = true;

            PlayerPrefs.DeleteKey("Weapon");
            PlayerPrefs.SetString("Weapon", "Sword");
            PlayerPrefs.SetInt("SwordUnlocked", 1);
        }
    }
    #endregion
}