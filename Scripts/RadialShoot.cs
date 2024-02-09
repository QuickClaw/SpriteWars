using UnityEngine;

public class RadialShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public int numberOfProjectiles = 8; // Change this according to the number of directions you want.
    public float shootingInterval = 2f; // Time between each automatic shot

    private float timeSinceLastShot;

    void Start()
    {
        timeSinceLastShot = shootingInterval; // Start shooting immediately
    }

    void Update()
    {
        // Update the timer
        timeSinceLastShot += Time.deltaTime;

        // Check if it's time to shoot again
        if (timeSinceLastShot >= shootingInterval)
        {
            ShootProjectiles();
            timeSinceLastShot = 0f; // Reset the timer
        }
    }

    void ShootProjectiles()
    {
        float angleStep = 360f / numberOfProjectiles;

        for (int i = 0; i < numberOfProjectiles; i++)
        {
            float angle = i * angleStep;
            Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.right;

            // Instantiate projectile at the current position of the GameObject
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Set the projectile's direction and start moving
            projectile.GetComponent<Rigidbody2D>().velocity = direction * 10f; // Adjust speed as needed
        }
    }
}
