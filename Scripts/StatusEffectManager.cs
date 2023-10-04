using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    Enemy Enemy;
    EnemyFollow EnemyFollow;

    public List<int> burnTickTimers = new();
    public List<int> poisonTickTimers = new();

    public static bool isBurning, isPoisoned, isSlowed;

    Color defaultColor;
    float speed;

    public float slowTime;

    void Start()
    {
        Enemy = gameObject.GetComponent<Enemy>();
        EnemyFollow = gameObject.GetComponent<EnemyFollow>();

        defaultColor = Color.red;
        speed = EnemyFollow.speed;
    }

    public void ApplyBurn(int ticks)
    {
        if (burnTickTimers.Count <= 0)
        {
            burnTickTimers.Add(ticks);
            StartCoroutine(Burn());
        }
        else
        {
            burnTickTimers.Add(ticks);
        }
    }

    IEnumerator Burn()
    {
        while (burnTickTimers.Count > 0)
        {
            for (int i = 0; i < burnTickTimers.Count; i++)
            {
                burnTickTimers[i]--;
            }

            isBurning = true;
            Enemy.TakeDamage(4);
            burnTickTimers.RemoveAll(i => i == 0);
            Enemy.burnEffect.Play();

            if (Enemy.currentHealth <= 0)
            {
                Enemy.Die();
                Enemy.burnEffect.Stop();
                break;
            }

            if (burnTickTimers.Count == 0)
            {
                isBurning = false;
                Enemy.burnEffect.Stop();
            }

            yield return new WaitForSeconds(1f);
        }
    }

    public void ApplyPoison(int ticks)
    {
        if (poisonTickTimers.Count <= 0)
        {
            poisonTickTimers.Add(ticks);
            StartCoroutine(Poison());
        }
        else
        {
            poisonTickTimers.Add(ticks);
        }
    }

    IEnumerator Poison()
    {
        while (poisonTickTimers.Count > 0)
        {
            for (int i = 0; i < poisonTickTimers.Count; i++)
            {
                poisonTickTimers[i]--;
            }

            isPoisoned = true;
            Enemy.TakeDamage(0.5f);
            poisonTickTimers.RemoveAll(i => i == 0);
            Enemy.poisonEffect.Play();

            if (Enemy.currentHealth <= 0)
            {
                Enemy.Die();
                Enemy.poisonEffect.Stop();
                break;
            }

            if (poisonTickTimers.Count == 0)
            {
                isPoisoned = false;
                Enemy.poisonEffect.Stop();
            }

            yield return new WaitForSeconds(0.2f);
        }
    }

    public void ApplySlow(int ticks)
    {
        if (slowTime <= 0)
        {
            slowTime += ticks;
            StartCoroutine(Slow());
        }
        else
        {
            slowTime += ticks;
        }
    }

    IEnumerator Slow()
    {
        while (slowTime > 0)
        {
            slowTime--;

            isSlowed = true;
            EnemyFollow.speed = speed - (speed * 25 / 100);
            Enemy.thisRenderer.color = Color.cyan;
                     
            yield return new WaitForSeconds(1f);
        }

        if(slowTime <= 0)
        {
            isSlowed = false;
            EnemyFollow.speed = speed; ;
            Enemy.thisRenderer.color = defaultColor;
        }
    }
}