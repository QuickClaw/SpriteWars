using UnityEngine;

public class Slowdown : MonoBehaviour
{
    private Enemy Enemy;

    private float originalSpeed; // Adjust this value to the original speed of your object
    public float slowdownDuration;

    private bool isSlowedDown = false;
    private float slowdownTimer = 0f;

    Color defaultColor;

    private void Start()
    {
        Enemy = gameObject.GetComponent<Enemy>();

        defaultColor = gameObject.GetComponent<SpriteRenderer>().color;
        originalSpeed = Enemy.enemySpeed;
    }

    private void Update()
    {
        if (isSlowedDown)
        {
            slowdownTimer -= Time.deltaTime;

            Enemy.enemySpeed = originalSpeed - (originalSpeed * 40 / 100);
            Enemy.thisRenderer.color = Color.cyan;
        }
        else
        {
            Enemy.enemySpeed = originalSpeed;
            Enemy.thisRenderer.color = defaultColor;
        }

        if (slowdownTimer <= 0f)
            isSlowedDown = false;

        if (Enemy.dead)
            Enemy.enemySpeed = 0f;

        if (Enemy.isFreezed)
        {
            Enemy.enemySpeed = 0f;
            Enemy.thisRenderer.color = Color.blue;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name is "Ice(Clone)")
        {
            if (!isSlowedDown)
            {
                isSlowedDown = true;
                slowdownTimer = slowdownDuration;
            }
            else
            {
                slowdownTimer = slowdownDuration;
            }
        }
    }
}