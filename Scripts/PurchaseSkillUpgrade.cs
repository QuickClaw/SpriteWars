using UnityEngine;
using TMPro;

public class PurchaseSkillUpgrade : MonoBehaviour
{
    [SerializeField] private Movement Movement;
    [SerializeField] private PlayerScript PlayerScript;

    [SerializeField] private TMP_Text txtSkillLevel;
    [SerializeField] private TMP_Text txtskillUpgrade;
    [SerializeField] private TMP_Text txtPrice;
    [SerializeField] private TMP_Text txtTotalSkillLevel;

    [SerializeField] private GameObject purchaseButton;
    [SerializeField] private GameObject txtNotEnoughGold;

    [SerializeField] private GameObject tickIcon;

    public string skillName;

    private float skillLevel;

    private float oldValue;
    private float newValue;

    private float increaseValue;
    public float minIncrease, maxIncrease;

    public int price;
    private int increasePrice;
    public int minIncreasePrice, maxIncreasePrice;

    public int firstPrice;
    void Start()
    {
        increaseValue = Random.Range(minIncrease, maxIncrease); // Skill upgradeler float tipinde random üretir
        increasePrice = Random.Range(minIncreasePrice, maxIncreasePrice); // Para integer tipinde random üretir 
    }

    private void Update()
    {
        if (PlayerPrefs.HasKey(gameObject.name))
            oldValue = PlayerPrefs.GetFloat(gameObject.name);
        else
        {
            if (gameObject.name is "Max Health Purchase")
                oldValue = PlayerScript.maxHealth;

            if (gameObject.name is "Movement Speed Purchase")
                oldValue = Movement.movementSpeed;

            if (gameObject.name is "Sprint Speed Purchase")
                oldValue = Movement.sprintSpeed;

            if (gameObject.name is "Sprint Cooldown Purchase")
                oldValue = Movement.sprintCooldown;

            if (gameObject.name is "Sprint Duration Purchase")
                oldValue = Movement.sprintLength;

            if (gameObject.name is "Freeze Cooldown Purchase")
                oldValue = Movement.freezeCooldown;

            if (gameObject.name is "Freeze Duration Purchase")
                oldValue = Movement.freezeDuration;

            if (gameObject.name is "Shield Duration Purchase")
                oldValue = Movement.shieldLength;

            if (gameObject.name is "Shield Cooldown Purchase")
                oldValue = Movement.shieldCooldown;

            if (gameObject.name is "Mass Explosion Damage Purchase")
                oldValue = Movement.massExplosionDamage;

            if (gameObject.name is "Mass Explosion Cooldown Purchase")
                oldValue = Movement.massExplosionCooldown;
        }

        if (gameObject.name.Contains("Cooldown"))
            newValue = oldValue - increaseValue;
        else
            newValue = oldValue + increaseValue;

        if (gameObject.name is "Max Health Purchase")
            txtskillUpgrade.text = skillName + oldValue.ToString("F0") + "<b><color=green> →" + newValue.ToString("F0") + "</b></color>";
        else
            txtskillUpgrade.text = skillName + oldValue.ToString("F1") + "<b><color=green> →" + newValue.ToString("F1") + "</b></color>";

        // Skill Level PlayerPrefs
        if (PlayerPrefs.HasKey(gameObject.name + "level"))
        {
            skillLevel = PlayerPrefs.GetFloat(gameObject.name + "level");
            txtSkillLevel.text = "<color=orange>Level " + PlayerPrefs.GetFloat(gameObject.name + "level") + "/7</color>";
        }
        else
        {
            skillLevel = 1;
            txtSkillLevel.text = "Level 1/7";
        }       

        // Price PlayerPrefs
        if (PlayerPrefs.HasKey(gameObject.name + "price"))
        {
            price = PlayerPrefs.GetInt(gameObject.name + "price");
            txtPrice.text = PlayerPrefs.GetInt(gameObject.name + "price").ToString("F0");
        }
        else
        {
            price = firstPrice;
            txtPrice.text = price.ToString("F0");
        }

        if (PlayerScript.gold >= price && skillLevel != 7)
        {
            txtNotEnoughGold.SetActive(false);
            purchaseButton.SetActive(true);
            tickIcon.SetActive(false);
        }
        else
        {
            txtNotEnoughGold.SetActive(true);
            purchaseButton.SetActive(false);
        }

        if (skillLevel == 7)
        {
            txtskillUpgrade.text = skillName + "<b><color=green>" + oldValue.ToString("F1") + "</b></color>";
            txtSkillLevel.text = "<b><color=green>Max Level</color></b>";
            txtPrice.gameObject.SetActive(false);
            purchaseButton.SetActive(false);
            txtNotEnoughGold.SetActive(false);
            tickIcon.SetActive(true);
        }
    }

    public void UpgradeSkill()
    {
        oldValue = newValue;
        PlayerPrefs.SetFloat(gameObject.name, newValue);

        PlayerScript.gold -= price;
        PlayerPrefs.SetInt("Gold", PlayerScript.gold);

        price += increasePrice;
        PlayerPrefs.SetInt(gameObject.name + "price", price);

        skillLevel++;
        PlayerPrefs.SetFloat(gameObject.name + "level", skillLevel);
    }
}