using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private PlayerScript PlayerScript;

    private GameObject player;
    public GameObject bulletPos;

    [SerializeField] ParticleSystem getHitParticle;

    private Rigidbody2D rb;

    private AudioSource playerGetHitAS;

    private Vector3 triggerPoint;

    public float force;
    public float damage;

    public bool isAimingPlayer;

    void Start()
    {
        playerGetHitAS = GameObject.Find("GetHit").GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");

        PlayerScript = player.GetComponent<PlayerScript>();

        if (isAimingPlayer)
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        }      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag is "Player")
        {
            triggerPoint = collision.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position);

            collision.GetComponent<PlayerScript>().TakeDamage(damage);
            Destroy(gameObject);

            playerGetHitAS.Play();
            Instantiate(getHitParticle, triggerPoint, Quaternion.identity);
        }
    }
}