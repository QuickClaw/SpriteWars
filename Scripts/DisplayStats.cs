using UnityEngine;
using TMPro;

public class DisplayStats : MonoBehaviour
{
    [Header("Fire Staff")]
    [SerializeField] private TMP_Text fireDamage;
    [SerializeField] private TMP_Text fireRate;

    [Header("Ice Wand")]
    [SerializeField] private TMP_Text iceDamage;
    [SerializeField] private TMP_Text iceRate;

    [Header("Poison")]
    [SerializeField] private TMP_Text poisonDamage;
    [SerializeField] private TMP_Text poisonRate;

    [Header("Gun")]
    [SerializeField] private TMP_Text gunDamage;
    [SerializeField] private TMP_Text gunRate;

    [Header("Bazooka")]
    [SerializeField] private TMP_Text bazookaDamage;
    [SerializeField] private TMP_Text bazookaRate;

    [Header("Bow")]
    [SerializeField] private TMP_Text bowDamage;
    [SerializeField] private TMP_Text bowRate;

    [Header("Electric")]
    [SerializeField] private TMP_Text electricDamage;
    [SerializeField] private TMP_Text electricRate;

    [Header("Sword")]
    [SerializeField] private TMP_Text swordDamage;
    [SerializeField] private TMP_Text swordRate;

    [Header("Projectile Prefabs")]
    [SerializeField] private GameObject Fire;
    [SerializeField] private GameObject Ice;
    [SerializeField] private GameObject Poison;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Missile;
    [SerializeField] private GameObject Arrow;
    [SerializeField] private GameObject Electric;
    [SerializeField] private GameObject Sword;

    void Start()
    {
        #region PlayerPrefs Damage

        if (PlayerPrefs.HasKey(Fire.name + "damage"))
            fireDamage.text = "<color=green>" + PlayerPrefs.GetFloat(Fire.name + "damage").ToString("F2") + "</color>";
        else
            fireDamage.text = "3.2";

        if (PlayerPrefs.HasKey(Ice.name + "damage"))
            iceDamage.text = "<color=green>" + PlayerPrefs.GetFloat(Ice.name + "damage").ToString("F2") + "</color>";
        else
            iceDamage.text = "13.1";

        if (PlayerPrefs.HasKey(Poison.name + "damage"))
            poisonDamage.text = "<color=green>" + PlayerPrefs.GetFloat(Poison.name + "damage").ToString("F2") + "</color>";
        else
            poisonDamage.text = "4.2";

        if (PlayerPrefs.HasKey(Bullet.name + "damage"))
            gunDamage.text = "<color=green>" + PlayerPrefs.GetFloat(Bullet.name + "damage").ToString("F2") + "</color>";
        else
            gunDamage.text = "2.1";

        if (PlayerPrefs.HasKey(Missile.name + "damage"))
            bazookaDamage.text = "<color=green>" + PlayerPrefs.GetFloat(Missile.name + "damage").ToString("F2") + "</color>";
        else
            bazookaDamage.text = "12.5";

        if (PlayerPrefs.HasKey(Arrow.name + "damage"))
            bowDamage.text = "<color=green>" + PlayerPrefs.GetFloat(Arrow.name + "damage").ToString("F2") + "</color>";
        else
            bowDamage.text = "18.8";

        if (PlayerPrefs.HasKey(Electric.name + "damage"))
            electricDamage.text = "<color=green>" + PlayerPrefs.GetFloat(Electric.name + "damage").ToString("F2") + "</color>";
        else
            electricDamage.text = "6.5";

        if (PlayerPrefs.HasKey(Sword.name + "damage"))
            swordDamage.text = "<color=green>" + PlayerPrefs.GetFloat(Sword.name + "damage").ToString("F2") + "</color>";
        else
            swordDamage.text = "7.4";

        #endregion

        #region PlayerPrefs Fire Rate

        if (PlayerPrefs.HasKey(Fire.name + "rate"))
            fireRate.text = "<color=green>" + PlayerPrefs.GetFloat(Fire.name + "rate").ToString("F2") + "</color>";
        else
            fireRate.text = "0.65";

        if (PlayerPrefs.HasKey(Ice.name + "rate"))
            iceRate.text = "<color=green>" + PlayerPrefs.GetFloat(Ice.name + "rate").ToString("F2") + "</color>";
        else
            iceRate.text = "1";

        if (PlayerPrefs.HasKey(Poison.name + "rate"))
            poisonRate.text = "<color=green>" + PlayerPrefs.GetFloat(Poison.name + "rate").ToString("F2") + "</color>";
        else
            poisonRate.text = "0.9";

        if (PlayerPrefs.HasKey(Bullet.name + "rate"))
            gunRate.text = "<color=green>" + PlayerPrefs.GetFloat(Bullet.name + "rate").ToString("F2") + "</color>";
        else
            gunRate.text = "0.15";

        if (PlayerPrefs.HasKey(Missile.name + "rate"))
            bazookaRate.text = "<color=green>" + PlayerPrefs.GetFloat(Missile.name + "rate").ToString("F2") + "</color>";
        else
            bazookaRate.text = "1.3";

        if (PlayerPrefs.HasKey(Arrow.name + "rate"))
            bowRate.text = "<color=green>" + PlayerPrefs.GetFloat(Arrow.name + "rate").ToString("F2") + "</color>";
        else
            bowRate.text = "1.5";

        if (PlayerPrefs.HasKey(Electric.name + "rate"))
            electricRate.text = "<color=green>" + PlayerPrefs.GetFloat(Electric.name + "rate").ToString("F2") + "</color>";
        else
            electricRate.text = "1";

        if (PlayerPrefs.HasKey(Sword.name + "rate"))
            swordRate.text = "<color=green>" + PlayerPrefs.GetFloat(Sword.name + "rate").ToString("F2") + "</color>";
        else
            swordRate.text = "0.6";

        #endregion
    }
}