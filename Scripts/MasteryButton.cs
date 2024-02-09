using UnityEngine;

public class MasteryButton : MonoBehaviour
{
    [SerializeField] private GameObject sprintMasteryClaimButton;
    [SerializeField] private GameObject freezeMasteryClaimButton;
    [SerializeField] private GameObject shieldMasteryClaimButton;
    [SerializeField] private GameObject massMasteryClaimButton;

    [SerializeField] private GameObject sprintMasteryClaimedIcon;
    [SerializeField] private GameObject freezeMasteryClaimedIcon;
    [SerializeField] private GameObject shieldMasteryClaimedIcon;
    [SerializeField] private GameObject massMasteryClaimedIcon;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Sprint_Mastery_Claimed"))
            sprintMasteryClaimedIcon.SetActive(true);

        if (PlayerPrefs.HasKey("Freeze_Mastery_Claimed"))
            freezeMasteryClaimedIcon.SetActive(true);

        if (PlayerPrefs.HasKey("Shield_Mastery_Claimed"))
            shieldMasteryClaimedIcon.SetActive(true);

        if (PlayerPrefs.HasKey("Mass_Mastery_Claimed"))
            massMasteryClaimedIcon.SetActive(true);
    }

    public void SprintMastery()
    {
        PlayerPrefs.SetInt("Sprint_Mastery_Claimed", 1);
        sprintMasteryClaimButton.SetActive(false);
        sprintMasteryClaimedIcon.SetActive(true);
    }

    public void FreezeMastery()
    {
        PlayerPrefs.SetInt("Freeze_Mastery_Claimed", 1);
        freezeMasteryClaimButton.SetActive(false);
        freezeMasteryClaimedIcon.SetActive(true);
    }

    public void ShieldMastery()
    {
        PlayerPrefs.SetInt("Shield_Mastery_Claimed", 1);
        shieldMasteryClaimButton.SetActive(false);
        shieldMasteryClaimedIcon.SetActive(true);
    }

    public void MassMastery()
    {
        PlayerPrefs.SetInt("Mass_Mastery_Claimed", 1);
        massMasteryClaimButton.SetActive(false);
        massMasteryClaimedIcon.SetActive(true);
    }
}