using UnityEngine;

public class PickupProjectile : MonoBehaviour
{
    GetAudioSources GetAudioSources;
    GetParticles GetParticles;
    ProjectileProperties ProjectileProperties;

    public static GameObject fire, ice, poison, bullet, missile, arrow, electric;

    private GameObject fireWand, iceWand, snake, autoGun, bazooka, bow, lightning;
    private GameObject rotatePoint, player;

    private AudioSource pickUpAS, shootingAS;

    private bool isFire, isIce, isPoison, isBullet, isMissile, isArrow, isElectric;

    void Start()
    {
        GetAudioSources = FindObjectOfType<GetAudioSources>();
        GetParticles = FindObjectOfType<GetParticles>();
        ProjectileProperties = FindObjectOfType<ProjectileProperties>();

        rotatePoint = GameObject.Find("RotatePoint");
        shootingAS = rotatePoint.GetComponent<AudioSource>();

        player = GameObject.Find("Player");
        pickUpAS = player.GetComponent<AudioSource>();

        fire = GameObject.Find("Fire");
        ice = GameObject.Find("Ice");
        poison = GameObject.Find("Poison");
        bullet = GameObject.Find("Bullet");
        missile = GameObject.Find("Missile");
        arrow = GameObject.Find("Arrow");
        electric = GameObject.Find("Electric");

        fireWand = GameObject.Find("Sprite_fireWand");
        iceWand = GameObject.Find("Sprite_iceWand");
        snake = GameObject.Find("Sprite_snake");
        autoGun = GameObject.Find("Sprite_autoGun");
        bazooka = GameObject.Find("Sprite_bazooka");
        bow = GameObject.Find("Sprite_bow");
        lightning = GameObject.Find("Sprite_lightning");

        #region PlayerPrefs
        if (PlayerPrefs.HasKey("weapon"))
        {
            if (PlayerPrefs.GetString("weapon") == "Fire")
            {
                Shooting.projectile = fire;

                Projectile.force = ProjectileProperties.fireForce;
                Projectile.timeBetweenFiring = ProjectileProperties.fireRate;
                Projectile.damage = ProjectileProperties.fireDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = true;
                iceWand.GetComponent<SpriteRenderer>().enabled = false;
                snake.GetComponent<SpriteRenderer>().enabled = false;
                autoGun.GetComponent<SpriteRenderer>().enabled = false;
                bazooka.GetComponent<SpriteRenderer>().enabled = false;
                bow.GetComponent<SpriteRenderer>().enabled = false;
                lightning.GetComponent<SpriteRenderer>().enabled = false;

                shootingAS.clip = GetAudioSources.shootingSounds[0];
                GetParticles.shootingParticle = GetParticles.projectileParticles[0];

                isFire = true;
                isIce = false;
                isPoison = false;
                isBullet = false;
                isMissile = false;
                isArrow = false;
                isElectric = false;
            }

            if (PlayerPrefs.GetString("weapon") == "Ice")
            {
                Shooting.projectile = ice;

                Projectile.force = ProjectileProperties.iceForce;
                Projectile.timeBetweenFiring = ProjectileProperties.iceRate;
                Projectile.damage = ProjectileProperties.iceDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = false;
                iceWand.GetComponent<SpriteRenderer>().enabled = true;
                snake.GetComponent<SpriteRenderer>().enabled = false;
                autoGun.GetComponent<SpriteRenderer>().enabled = false;
                bazooka.GetComponent<SpriteRenderer>().enabled = false;
                bow.GetComponent<SpriteRenderer>().enabled = false;
                lightning.GetComponent<SpriteRenderer>().enabled = false;

                shootingAS.clip = GetAudioSources.shootingSounds[1];
                GetParticles.shootingParticle = GetParticles.projectileParticles[1];

                isFire = false;
                isIce = true;
                isPoison = false;
                isBullet = false;
                isMissile = false;
                isArrow = false;
                isElectric = false;
            }

            if (PlayerPrefs.GetString("weapon") == "Poison")
            {
                Shooting.projectile = poison;

                Projectile.force = ProjectileProperties.poisonForce;
                Projectile.timeBetweenFiring = ProjectileProperties.poisonRate;
                Projectile.damage = ProjectileProperties.poisonDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = false;
                iceWand.GetComponent<SpriteRenderer>().enabled = false;
                snake.GetComponent<SpriteRenderer>().enabled = true;
                autoGun.GetComponent<SpriteRenderer>().enabled = false;
                bazooka.GetComponent<SpriteRenderer>().enabled = false;
                bow.GetComponent<SpriteRenderer>().enabled = false;
                lightning.GetComponent<SpriteRenderer>().enabled = false;

                shootingAS.clip = GetAudioSources.shootingSounds[2];
                GetParticles.shootingParticle = GetParticles.projectileParticles[2];

                isFire = false;
                isIce = false;
                isPoison = true;
                isBullet = false;
                isMissile = false;
                isArrow = false;
                isElectric = false;
            }

            if (PlayerPrefs.GetString("weapon") == "Bullet")
            {
                Shooting.projectile = bullet;

                Projectile.force = ProjectileProperties.bulletForce;
                Projectile.timeBetweenFiring = ProjectileProperties.bulletRate;
                Projectile.damage = ProjectileProperties.bulletDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = false;
                iceWand.GetComponent<SpriteRenderer>().enabled = false;
                snake.GetComponent<SpriteRenderer>().enabled = false;
                autoGun.GetComponent<SpriteRenderer>().enabled = true;
                bazooka.GetComponent<SpriteRenderer>().enabled = false;
                bow.GetComponent<SpriteRenderer>().enabled = false;
                lightning.GetComponent<SpriteRenderer>().enabled = false;

                shootingAS.clip = GetAudioSources.shootingSounds[3];
                GetParticles.shootingParticle = GetParticles.projectileParticles[3];

                isFire = false;
                isIce = false;
                isPoison = false;
                isBullet = true;
                isMissile = false;
                isArrow = false;
                isElectric = false;
            }

            if (PlayerPrefs.GetString("weapon") == "Missile")
            {
                Shooting.projectile = missile;

                Projectile.force = ProjectileProperties.missileForce;
                Projectile.timeBetweenFiring = ProjectileProperties.missileRate;
                Projectile.damage = ProjectileProperties.missileDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = false;
                iceWand.GetComponent<SpriteRenderer>().enabled = false;
                snake.GetComponent<SpriteRenderer>().enabled = false;
                autoGun.GetComponent<SpriteRenderer>().enabled = false;
                bazooka.GetComponent<SpriteRenderer>().enabled = true;
                bow.GetComponent<SpriteRenderer>().enabled = false;
                lightning.GetComponent<SpriteRenderer>().enabled = false;

                shootingAS.clip = GetAudioSources.shootingSounds[4];
                GetParticles.shootingParticle = GetParticles.projectileParticles[4];

                isFire = false;
                isIce = false;
                isPoison = false;
                isBullet = false;
                isMissile = true;
                isArrow = false;
                isElectric = false;
            }

            if (PlayerPrefs.GetString("weapon") == "Arrow")
            {
                Shooting.projectile = arrow;

                Projectile.force = ProjectileProperties.arrowForce;
                Projectile.timeBetweenFiring = ProjectileProperties.arrowRate;
                Projectile.damage = ProjectileProperties.arrowDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = false;
                iceWand.GetComponent<SpriteRenderer>().enabled = false;
                snake.GetComponent<SpriteRenderer>().enabled = false;
                autoGun.GetComponent<SpriteRenderer>().enabled = false;
                bazooka.GetComponent<SpriteRenderer>().enabled = false;
                bow.GetComponent<SpriteRenderer>().enabled = true;
                lightning.GetComponent<SpriteRenderer>().enabled = false;

                shootingAS.clip = GetAudioSources.shootingSounds[5];
                GetParticles.shootingParticle = GetParticles.projectileParticles[5];

                isFire = false;
                isIce = false;
                isPoison = false;
                isBullet = false;
                isMissile = false;
                isArrow = true;
                isElectric = false;
            }

            if (PlayerPrefs.GetString("weapon") == "Electric")
            {
                Shooting.projectile = electric;

                Projectile.force = ProjectileProperties.electricForce;
                Projectile.timeBetweenFiring = ProjectileProperties.electriceRate;
                Projectile.damage = ProjectileProperties.electricDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = false;
                iceWand.GetComponent<SpriteRenderer>().enabled = false;
                snake.GetComponent<SpriteRenderer>().enabled = false;
                autoGun.GetComponent<SpriteRenderer>().enabled = false;
                bazooka.GetComponent<SpriteRenderer>().enabled = false;
                bow.GetComponent<SpriteRenderer>().enabled = false;
                lightning.GetComponent<SpriteRenderer>().enabled = true;

                shootingAS.clip = GetAudioSources.shootingSounds[6];
                GetParticles.shootingParticle = GetParticles.projectileParticles[6];

                isFire = false;
                isIce = false;
                isPoison = false;
                isBullet = false;
                isMissile = false;
                isArrow = false;
                isElectric = true;
            }
        }
        else
        {
            Shooting.projectile = fire;

            Projectile.force = ProjectileProperties.fireForce;
            Projectile.timeBetweenFiring = ProjectileProperties.fireRate;
            Projectile.damage = ProjectileProperties.fireDamage;

            fireWand.GetComponent<SpriteRenderer>().enabled = true;
            iceWand.GetComponent<SpriteRenderer>().enabled = false;
            snake.GetComponent<SpriteRenderer>().enabled = false;
            autoGun.GetComponent<SpriteRenderer>().enabled = false;
            bazooka.GetComponent<SpriteRenderer>().enabled = false;
            bow.GetComponent<SpriteRenderer>().enabled = false;
            lightning.GetComponent<SpriteRenderer>().enabled = false;

            shootingAS.clip = GetAudioSources.shootingSounds[0];
            GetParticles.shootingParticle = GetParticles.projectileParticles[0];

            isFire = true;
            isIce = false;
            isPoison = false;
            isBullet = false;
            isMissile = false;
            isArrow = false;
            isElectric = false;
        }
        #endregion
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        #region Fire
        if (collision.tag is "Fire")
        {
            if (!isFire)
            {
                Shooting.projectile = fire;

                Projectile.force = ProjectileProperties.fireForce;
                Projectile.timeBetweenFiring = ProjectileProperties.fireRate;
                Projectile.damage = ProjectileProperties.fireDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = true;
                iceWand.GetComponent<SpriteRenderer>().enabled = false;
                snake.GetComponent<SpriteRenderer>().enabled = false;
                autoGun.GetComponent<SpriteRenderer>().enabled = false;
                bazooka.GetComponent<SpriteRenderer>().enabled = false;
                bow.GetComponent<SpriteRenderer>().enabled = false;
                lightning.GetComponent<SpriteRenderer>().enabled = false;

                pickUpAS.Play();
                GetParticles.pickupParticles[0].Play();

                shootingAS.clip = GetAudioSources.shootingSounds[0];
                GetParticles.shootingParticle = GetParticles.projectileParticles[0];

                isFire = true;
                isIce = false;
                isPoison = false;
                isBullet = false;
                isMissile = false;
                isArrow = false;
                isElectric = false;

                PlayerPrefs.DeleteKey("weapon");
                PlayerPrefs.SetString("weapon", collision.tag);
            }
        }
        #endregion

        #region Ice
        if (collision.tag is "Ice")
        {
            if (!isIce)
            {
                Shooting.projectile = ice;

                Projectile.force = ProjectileProperties.iceForce;
                Projectile.timeBetweenFiring = ProjectileProperties.iceRate;
                Projectile.damage = ProjectileProperties.iceDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = false;
                iceWand.GetComponent<SpriteRenderer>().enabled = true;
                snake.GetComponent<SpriteRenderer>().enabled = false;
                autoGun.GetComponent<SpriteRenderer>().enabled = false;
                bazooka.GetComponent<SpriteRenderer>().enabled = false;
                bow.GetComponent<SpriteRenderer>().enabled = false;
                lightning.GetComponent<SpriteRenderer>().enabled = false;

                pickUpAS.Play();
                GetParticles.pickupParticles[1].Play();

                shootingAS.clip = GetAudioSources.shootingSounds[1];
                GetParticles.shootingParticle = GetParticles.projectileParticles[1];

                isFire = false;
                isIce = true;
                isPoison = false;
                isBullet = false;
                isMissile = false;
                isArrow = false;
                isElectric = false;

                PlayerPrefs.DeleteKey("weapon");
                PlayerPrefs.SetString("weapon", collision.tag);
            }
        }
        #endregion

        #region Poison
        if (collision.tag is "Poison")
        {
            if (!isPoison)
            {
                Shooting.projectile = poison;

                Projectile.force = ProjectileProperties.poisonForce;
                Projectile.timeBetweenFiring = ProjectileProperties.poisonRate;
                Projectile.damage = ProjectileProperties.poisonDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = false;
                iceWand.GetComponent<SpriteRenderer>().enabled = false;
                snake.GetComponent<SpriteRenderer>().enabled = true;
                autoGun.GetComponent<SpriteRenderer>().enabled = false;
                bazooka.GetComponent<SpriteRenderer>().enabled = false;
                bow.GetComponent<SpriteRenderer>().enabled = false;
                lightning.GetComponent<SpriteRenderer>().enabled = false;

                pickUpAS.Play();
                GetParticles.pickupParticles[2].Play();

                shootingAS.clip = GetAudioSources.shootingSounds[2];
                GetParticles.shootingParticle = GetParticles.projectileParticles[2];

                isFire = false;
                isIce = false;
                isPoison = true;
                isBullet = false;
                isMissile = false;
                isArrow = false;
                isElectric = false;

                PlayerPrefs.DeleteKey("weapon");
                PlayerPrefs.SetString("weapon", collision.tag);
            }
        }
        #endregion

        #region Bullet
        if (collision.tag is "Bullet")
        {
            if (!isBullet)
            {
                Shooting.projectile = bullet;

                Projectile.force = ProjectileProperties.bulletForce;
                Projectile.timeBetweenFiring = ProjectileProperties.bulletRate;
                Projectile.damage = ProjectileProperties.bulletDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = false;
                iceWand.GetComponent<SpriteRenderer>().enabled = false;
                snake.GetComponent<SpriteRenderer>().enabled = false;
                autoGun.GetComponent<SpriteRenderer>().enabled = true;
                bazooka.GetComponent<SpriteRenderer>().enabled = false;
                bow.GetComponent<SpriteRenderer>().enabled = false;
                lightning.GetComponent<SpriteRenderer>().enabled = false;

                pickUpAS.Play();
                GetParticles.pickupParticles[3].Play();

                shootingAS.clip = GetAudioSources.shootingSounds[3];
                GetParticles.shootingParticle = GetParticles.projectileParticles[3];

                isFire = false;
                isIce = false;
                isPoison = false;
                isBullet = true;
                isMissile = false;
                isArrow = false;
                isElectric = false;

                PlayerPrefs.DeleteKey("weapon");
                PlayerPrefs.SetString("weapon", collision.tag);
            }
        }
        #endregion

        #region Missile
        if (collision.tag is "Missile")
        {
            if (!isMissile)
            {
                Shooting.projectile = missile;

                Projectile.force = ProjectileProperties.missileForce;
                Projectile.timeBetweenFiring = ProjectileProperties.missileRate;
                Projectile.damage = ProjectileProperties.missileDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = false;
                iceWand.GetComponent<SpriteRenderer>().enabled = false;
                snake.GetComponent<SpriteRenderer>().enabled = false;
                autoGun.GetComponent<SpriteRenderer>().enabled = false;
                bazooka.GetComponent<SpriteRenderer>().enabled = true;
                bow.GetComponent<SpriteRenderer>().enabled = false;
                lightning.GetComponent<SpriteRenderer>().enabled = false;

                pickUpAS.Play();
                GetParticles.pickupParticles[4].Play();

                shootingAS.clip = GetAudioSources.shootingSounds[4];
                GetParticles.shootingParticle = GetParticles.projectileParticles[4];

                isFire = false;
                isIce = false;
                isPoison = false;
                isBullet = false;
                isMissile = true;
                isArrow = false;
                isElectric = false;

                PlayerPrefs.DeleteKey("weapon");
                PlayerPrefs.SetString("weapon", collision.tag);
            }
        }
        #endregion        

        #region Arrow
        if (collision.tag is "Arrow")
        {
            if (!isArrow)
            {
                Shooting.projectile = arrow;

                Projectile.force = ProjectileProperties.arrowForce;
                Projectile.timeBetweenFiring = ProjectileProperties.arrowRate;
                Projectile.damage = ProjectileProperties.arrowDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = false;
                iceWand.GetComponent<SpriteRenderer>().enabled = false;
                snake.GetComponent<SpriteRenderer>().enabled = false;
                autoGun.GetComponent<SpriteRenderer>().enabled = false;
                bazooka.GetComponent<SpriteRenderer>().enabled = false;
                bow.GetComponent<SpriteRenderer>().enabled = true;
                lightning.GetComponent<SpriteRenderer>().enabled = false;

                pickUpAS.Play();
                GetParticles.pickupParticles[5].Play();

                shootingAS.clip = GetAudioSources.shootingSounds[5];
                GetParticles.shootingParticle = GetParticles.projectileParticles[5];

                isFire = false;
                isIce = false;
                isPoison = false;
                isBullet = false;
                isMissile = false;
                isArrow = true;
                isElectric = false;

                PlayerPrefs.DeleteKey("weapon");
                PlayerPrefs.SetString("weapon", collision.tag);
            }
        }
        #endregion   

        #region Electric
        if (collision.tag is "Electric")
        {
            if (!isElectric)
            {
                Shooting.projectile = electric;

                Projectile.force = ProjectileProperties.electricForce;
                Projectile.timeBetweenFiring = ProjectileProperties.electriceRate;
                Projectile.damage = ProjectileProperties.electricDamage;

                fireWand.GetComponent<SpriteRenderer>().enabled = false;
                iceWand.GetComponent<SpriteRenderer>().enabled = false;
                snake.GetComponent<SpriteRenderer>().enabled = false;
                autoGun.GetComponent<SpriteRenderer>().enabled = false;
                bazooka.GetComponent<SpriteRenderer>().enabled = false;
                bow.GetComponent<SpriteRenderer>().enabled = false;
                lightning.GetComponent<SpriteRenderer>().enabled = true;

                pickUpAS.Play();
                GetParticles.pickupParticles[6].Play();

                shootingAS.clip = GetAudioSources.shootingSounds[6];
                GetParticles.shootingParticle = GetParticles.projectileParticles[6];

                isFire = false;
                isIce = false;
                isPoison = false;
                isBullet = false;
                isMissile = false;
                isArrow = false;
                isElectric = true;

                PlayerPrefs.DeleteKey("weapon");
                PlayerPrefs.SetString("weapon", collision.tag);
            }
        }
        #endregion   
    }
}