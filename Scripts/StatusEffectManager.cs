using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    private Enemy Enemy;

    private List<int> burnTickTimers = new();
    private List<int> poisonTickTimers = new();

    public static bool isBurning, isPoisoned;

    [SerializeField] private float slowTime;

    public float fireTickDamage, poisonTickDamage;

    void Start()
    {
        Enemy = gameObject.GetComponent<Enemy>();
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
            Enemy.TakeDamage(fireTickDamage);
            burnTickTimers.RemoveAll(i => i == 0);
            Enemy.burnEffect.Play();

            if (Enemy.currentHealth <= 0)
            {
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
            Enemy.TakeDamage(poisonTickDamage);
            poisonTickTimers.RemoveAll(i => i == 0);
            Enemy.poisonEffect.Play();

            if (Enemy.currentHealth <= 0)
            {
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
}