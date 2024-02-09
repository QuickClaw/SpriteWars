using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public List<GameObject> objectsToActivate;
    public int numberOfObjectsToActivate = 3;

    [Header("Weapon Unlocks")]
    [SerializeField] private GameObject iceUpgrade;
    [SerializeField] private GameObject poisonUpgrade;
    [SerializeField] private GameObject gunUpgrade;
    [SerializeField] private GameObject bazookaUpgrade;
    [SerializeField] private GameObject bowUpgrade;
    [SerializeField] private GameObject electricUpgrade;
    [SerializeField] private GameObject swordUpgrade;

    [Header("Weapon Damages")]
    [SerializeField] private GameObject fireDmg;
    [SerializeField] private GameObject iceDmg;
    [SerializeField] private GameObject poisonDmg;
    [SerializeField] private GameObject gunDmg;
    [SerializeField] private GameObject bazookaDmg;
    [SerializeField] private GameObject bowDmg;
    [SerializeField] private GameObject electricDmg;
    [SerializeField] private GameObject swordDmg;

    [Header("Weapon Fire Rates")]
    [SerializeField] private GameObject fireRate;
    [SerializeField] private GameObject iceRate;
    [SerializeField] private GameObject poisonRate;
    [SerializeField] private GameObject gunRate;
    [SerializeField] private GameObject bazookaRate;
    [SerializeField] private GameObject bowRate;
    [SerializeField] private GameObject electricRate;
    [SerializeField] private GameObject swordRate;

    void Start()
    {
        objectsToActivate.Add(fireDmg);
        objectsToActivate.Add(fireRate);

        if (PlayerPrefs.GetInt("IceUnlocked") == 1)
        {
            objectsToActivate.Remove(iceUpgrade);
            objectsToActivate.Add(iceDmg);
            objectsToActivate.Add(iceRate);
        }

        if (PlayerPrefs.GetInt("PoisonUnlocked") == 1)
        {
            objectsToActivate.Remove(poisonUpgrade);
            objectsToActivate.Add(poisonDmg);
            objectsToActivate.Add(poisonRate);
        }

        if (PlayerPrefs.GetInt("GunUnlocked") == 1)
        {
            objectsToActivate.Remove(gunUpgrade);
            objectsToActivate.Add(gunDmg);
            objectsToActivate.Add(gunRate);
        }

        if (PlayerPrefs.GetInt("BazookaUnlocked") == 1)
        {
            objectsToActivate.Remove(bazookaUpgrade);
            objectsToActivate.Add(bazookaDmg);
            objectsToActivate.Add(bazookaRate);
        }

        if (PlayerPrefs.GetInt("BowUnlocked") == 1)
        {
            objectsToActivate.Remove(bowUpgrade);
            objectsToActivate.Add(bowDmg);
            objectsToActivate.Add(bowRate);
        }

        if (PlayerPrefs.GetInt("ElectricUnlocked") == 1)
        {
            objectsToActivate.Remove(electricUpgrade);
            objectsToActivate.Add(electricDmg);
            objectsToActivate.Add(electricRate);
        }

        if (PlayerPrefs.GetInt("SwordUnlocked") == 1)
        {
            objectsToActivate.Remove(swordUpgrade);
            objectsToActivate.Add(swordDmg);
            objectsToActivate.Add(swordRate);
        }

        // Önce tüm GameObject'leri devre dýþý býrakalým.
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(false);
        }

        // Rastgele 3 GameObject'i etkinleþtirelim.
        ActivateRandomObjects();
    }

    void ActivateRandomObjects()
    {
        List<int> randomIndexes = new List<int>();

        // 0'dan baþlayarak GameObject dizisinin indislerini karýþtýrarak rastgele indisleri seçelim.
        for (int i = 0; i < objectsToActivate.Count; i++)
        {
            randomIndexes.Add(i);
        }
        randomIndexes = ShuffleList(randomIndexes);

        // Belirtilen sayýda rastgele GameObject'i etkinleþtirelim.
        for (int i = 0; i < numberOfObjectsToActivate; i++)
        {
            int index = randomIndexes[i];
            objectsToActivate[index].SetActive(true);
        }
    }

    List<T> ShuffleList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randIndex = Random.Range(i, list.Count);
            T temp = list[i];
            list[i] = list[randIndex];
            list[randIndex] = temp;
        }
        return list;
    }
}
