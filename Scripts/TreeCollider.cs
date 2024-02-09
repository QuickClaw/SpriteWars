using UnityEngine;

public class TreeCollider : MonoBehaviour
{
    [SerializeField] private ParticleSystem treeHitEffect;

    [SerializeField] private AudioSource treeHitAS;
    [SerializeField] private AudioClip treeHitAudioClip;

    private Vector3 collisionPoint;

    private void Start()
    {
        treeHitAS.volume = 0.07f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag is "Projectile" || collision.tag is "Enemy Bullet")
        {
            collisionPoint = collision.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position);

            Instantiate(treeHitEffect, collisionPoint, Quaternion.identity);

            treeHitAS.PlayOneShot(treeHitAudioClip);

            Destroy(collision.gameObject);
        }
    }
}