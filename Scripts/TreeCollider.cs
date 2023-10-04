using System.Linq;
using UnityEngine;

public class TreeCollider : MonoBehaviour
{
    ParticleSystem treeHitEffect;
    AudioSource treeHitAS;

    Vector3 collisionPoint;

    void Start()
    {
        treeHitEffect = gameObject.GetComponentsInChildren<ParticleSystem>().ToList().Find(x => x.name.Contains("treeHit effect"));
        treeHitAS = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag is "Projectile")
        {
            collisionPoint = collision.gameObject.GetComponent<Collider2D>().bounds.ClosestPoint(transform.position);
            treeHitEffect.transform.position = collisionPoint;
            treeHitEffect.Play();

            treeHitAS.Play();

            Destroy(collision.gameObject);
        }
    }
}