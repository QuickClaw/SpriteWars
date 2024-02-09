using UnityEngine;
using TMPro;

public class AttributeUpgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text txtNewAttributes;

    [SerializeField] private GameObject projectilePrefab;

    private float oldRate;
    private float newRate;

    private float oldDamage;
    private float newDamage;

    private float increaseAmountDamage;
    private float decreaseAmountRate;

    public float minDamage, maxDamage;
    public float minRate, maxRate;

    void Start()
    {
        increaseAmountDamage = Random.Range(minDamage, maxDamage);
        decreaseAmountRate = Random.Range(minRate, maxRate);

        #region Damage Upgrade

        if (gameObject.name.Contains("DamageAttribute"))
        {
            if (PlayerPrefs.HasKey(projectilePrefab.name + "damage"))
                oldDamage = PlayerPrefs.GetFloat(projectilePrefab.name + "damage");
            else
                oldDamage = projectilePrefab.GetComponent<ProjectileDamage>().damage;

            newDamage = oldDamage + increaseAmountDamage;

            txtNewAttributes.text = "Damage: <b>" + oldDamage.ToString("F2") + " <size=25>→ " + newDamage.ToString("F2") + "</size></b>";
        }

        #endregion

        #region Rate Upgrade

        if (gameObject.name.Contains("RateAttribute"))
        {
            if (PlayerPrefs.HasKey(projectilePrefab.name + "rate"))
                oldRate = PlayerPrefs.GetFloat(projectilePrefab.name + "rate");
            else
                oldRate = projectilePrefab.GetComponent<ProjectileDamage>().rate;

            newRate = oldRate - decreaseAmountRate;

            txtNewAttributes.text = "Fire Rate: <b>" + oldRate.ToString("F2") + " <size=25>→ " + newRate.ToString("F2") + "</size></b>";
        }

        #endregion
    }

    public void UpgradeDamageAttribute()
    {
        oldDamage = newDamage;
        PlayerPrefs.SetFloat(projectilePrefab.name + "damage", newDamage);
    }

    public void UpgradeRateAttribute()
    {
        oldRate = newRate;
        PlayerPrefs.SetFloat(projectilePrefab.name + "rate", newRate);
    }
}
