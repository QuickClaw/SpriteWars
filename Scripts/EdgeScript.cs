using UnityEngine;

public class EdgeScript : MonoBehaviour
{
    [SerializeField] PlayerScript PlayerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag is "Player")
            PlayerScript.TakeDamage(10f);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag is "Player")
            PlayerScript.TakeDamage(1f);
    }
}