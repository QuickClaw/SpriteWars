using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private AudioSource shieldCollideAS;
    [SerializeField] private AudioClip getHit;

    [SerializeField] private ParticleSystem shieldCollideParticle;

    private Vector3 triggerPoint;

    public int blockedBullets;

    private void Awake()
    {
        blockedBullets = PlayerPrefs.GetInt("blockedBullets");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag is "Enemy Bullet")
        {
            triggerPoint = collision.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position);

            Destroy(collision.gameObject);

            shieldCollideAS.PlayOneShot(getHit);

            Instantiate(shieldCollideParticle, triggerPoint, Quaternion.identity);

            blockedBullets++;
            PlayerPrefs.SetInt("blockedBullets", blockedBullets);
        }
    }

    private void Update()
    {
        transform.position = player.position;
    }
}