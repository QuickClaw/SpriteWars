using UnityEngine;

public class Shooting : MonoBehaviour
{
    GetParticles GetParticles;

    private Camera mainCam;
    private Vector3 mousePos;

    public static GameObject projectile;

    private GameObject projectileTransform;

    public static AudioSource shootingAS;

    bool canFire;

    private float timer;

    private void Start()
    {
        GetParticles = FindObjectOfType<GetParticles>();

        projectileTransform = GameObject.Find("Weapon Transform");

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        shootingAS = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > Projectile.timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(projectile, projectileTransform.transform.position, transform.rotation);

            shootingAS.Play();
            GetParticles.shootingParticle.Play();
        }      
    }
}