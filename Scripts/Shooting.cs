using UnityEngine;

public class Shooting : MonoBehaviour
{
    public PickupProjectile PickupProjectile;

    private Camera mainCam;
    private Vector3 mousePos;

    public GameObject projectilePrefab;
    public GameObject currentProjectile;
    public Transform projectileTransform;

    public AudioSource shootingAS;

    public Collider2D swordCollider;

    public ParticleSystem shootingParticle;
    public ParticleSystem swordShoot;

    [SerializeField] private Rigidbody2D rb;

    public float force;
    public float timeBetweenFiring;

    bool canFire;
    private float timer;

    private Vector3 swordColliderLocation;

    public int shotsFired;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;

                shotsFired++;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            if (!PickupProjectile.isSword)
            {
                canFire = false;

                currentProjectile = Instantiate(projectilePrefab, projectileTransform.position, Quaternion.identity);
                Shoot(currentProjectile);
            }
            else
            {
                canFire = false;

                swordColliderLocation = new Vector3(swordShoot.transform.position.x, swordShoot.transform.position.y, swordShoot.transform.position.z);
                swordCollider.transform.position = swordColliderLocation;

                Invoke(nameof(SendAwaySwordCollider), 0.2f);
            }

            shootingAS.Play();
            shootingParticle.Play();
        }
    }
    void SendAwaySwordCollider()
    {
        swordCollider.transform.position = new Vector3(5000f, 5000f, 5000f);
    }

    void Shoot(GameObject projectile)
    {
        rb = projectile.GetComponent<Rigidbody2D>();
        Vector3 direction = mousePos - projectile.transform.position;
        Vector3 rotation = projectile.transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.Euler(0, 0, rotZ + 90);
    }
}