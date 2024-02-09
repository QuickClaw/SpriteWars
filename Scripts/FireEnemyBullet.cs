using UnityEngine;

public class FireEnemyBullet : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    public float fireRate;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > fireRate)
        {
            timer = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}