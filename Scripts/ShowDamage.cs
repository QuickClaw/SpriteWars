using UnityEngine;
using TMPro;
using System.Linq;

public class ShowDamage : MonoBehaviour
{
    Enemy Enemy;

    public TMP_Text txt_EnemyHealth;

    void Start()
    {
        Enemy = gameObject.GetComponent<Enemy>();       

        txt_EnemyHealth = gameObject.GetComponentsInChildren<TMP_Text>().ToList().Find(x => x.name.Contains("txt_enemyHealth"));
        txt_EnemyHealth.text = Enemy.maxHealth.ToString("0");
    }
}