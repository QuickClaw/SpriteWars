using UnityEngine;

public class ExplosionCollider : MonoBehaviour
{
    Enemy Enemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag is "Enemy")
        {
            Enemy = collision.GetComponent<Enemy>();
            Enemy.TakeDamage(5);           
        }
    }
}