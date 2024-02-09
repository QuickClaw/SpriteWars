using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseUpgrade : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private PickupProjectile PickupProjectile;
    [SerializeField] private AttributeUpgrade AttributeUpgrade;

    [SerializeField] private GameObject[] otherUpgrades;

    [SerializeField] private GameObject nextLevelButton;
    [SerializeField] private GameObject txtWonDesc;

    private void Start()
    {
        nextLevelButton.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.name is "FireWeaponUnlock")
        {
            PickupProjectile.FirePickup();
            PlayerPrefs.SetInt(gameObject.name, 1);
        }

        if (gameObject.name is "IceWeaponUnlock")
        {
            PickupProjectile.IcePickup();
            PlayerPrefs.SetInt(gameObject.name, 1);
        }

        if (gameObject.name is "PoisonWeaponUnlock")
        {
            PickupProjectile.PoisonPickup();
            PlayerPrefs.SetInt(gameObject.name, 1);
        }

        if (gameObject.name is "GunWeaponUnlock")
        {
            PickupProjectile.GunPickup();
            PlayerPrefs.SetInt(gameObject.name, 1);
        }

        if (gameObject.name is "BazookaWeaponUnlock")
        {
            PickupProjectile.BazookaPickup();
            PlayerPrefs.SetInt(gameObject.name, 1);
        }

        if (gameObject.name is "BowWeaponUnlock")
        {
            PickupProjectile.BowPickup();
            PlayerPrefs.SetInt(gameObject.name, 1);
        }

        if (gameObject.name is "ElectricWeaponUnlock")
        {
            PickupProjectile.ElectricPickup();
            PlayerPrefs.SetInt(gameObject.name, 1);
        }

        if (gameObject.name is "SwordWeaponUnlock")
        {
            PickupProjectile.SwordPickup();
            PlayerPrefs.SetInt(gameObject.name, 1);
        }

        if (AttributeUpgrade != null)
        {
            if (gameObject.name.Contains("DamageAttribute"))
                AttributeUpgrade.UpgradeDamageAttribute();
            else
                AttributeUpgrade.UpgradeRateAttribute();
        }

        foreach (GameObject other in otherUpgrades)
            other.SetActive(false);

        nextLevelButton.SetActive(true);
        txtWonDesc.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(0.5848988f, 0.1843548f, 0.1843548f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.localScale = new Vector3(0.4933356f, 0.1554949f, 0.1554949f);
    }
}
