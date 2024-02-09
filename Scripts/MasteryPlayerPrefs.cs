using UnityEngine;
using TMPro;

public class MasteryPlayerPrefs : MonoBehaviour
{
    [SerializeField] private Movement Movement;
    [SerializeField] private ShieldScript ShieldScript;

    [SerializeField] private TMP_Text txtSprintLevel;
    [SerializeField] private TMP_Text txtEnemiesKilledSprint;

    [SerializeField] private TMP_Text txtFreezeLevel;
    [SerializeField] private TMP_Text txtFreezedEnemies;

    [SerializeField] private TMP_Text txtShieldLevel;
    [SerializeField] private TMP_Text txtBlockedBullets;

    [SerializeField] private TMP_Text txtMassLevel;
    [SerializeField] private TMP_Text txtEnemiesKilledMass;

    [SerializeField] private GameObject sprintClaimButton;
    [SerializeField] private GameObject freezeClaimButton;
    [SerializeField] private GameObject shieldClaimButton;
    [SerializeField] private GameObject massClaimButton;

    private void Update()
    {
        if (PlayerPrefs.HasKey("Sprint Speed Purchaselevel"))
            txtSprintLevel.text = "(" + PlayerPrefs.GetFloat("Sprint Speed Purchaselevel").ToString() + "/7)";
        else
            txtSprintLevel.text = "(1/7)";

        if (PlayerPrefs.HasKey("Freeze Duration Purchaselevel"))
            txtFreezeLevel.text = "(" + PlayerPrefs.GetFloat("Freeze Duration Purchaselevel").ToString() + "/7)";
        else
            txtFreezeLevel.text = "(1/7)";

        if (PlayerPrefs.HasKey("Shield Duration Purchaselevel"))
            txtShieldLevel.text = "(" + PlayerPrefs.GetFloat("Shield Duration Purchaselevel").ToString() + "/7)";
        else
            txtShieldLevel.text = "(1/7)";

        if (PlayerPrefs.HasKey("Mass Explosion Damage Purchaselevel"))
            txtMassLevel.text = "(" + PlayerPrefs.GetFloat("Mass Explosion Damage Purchaselevel").ToString() + "/7 )";
        else
            txtMassLevel.text = "(1/7)";

        if (PlayerPrefs.HasKey("enemiesKilled"))
        {
            txtEnemiesKilledMass.text = "(" + PlayerPrefs.GetInt("enemiesKilled").ToString() + "/300)";
            txtEnemiesKilledSprint.text = "(" + PlayerPrefs.GetInt("enemiesKilled").ToString() + "/300)";
        }
        else
        {
            txtEnemiesKilledMass.text = "(0/300)";
            txtEnemiesKilledSprint.text = "(0/300)";
        }

        txtFreezedEnemies.text = "(" + Movement.freezedEnemies.ToString() + "/125)";
        txtBlockedBullets.text = "(" + PlayerPrefs.GetInt("blockedBullets").ToString() + "/400)";

        #region Eþ zamanlý Sprint Mastery Requirements text renk deðiþimi
        if (PlayerPrefs.GetFloat("Sprint Speed Purchaselevel") >= 7)
            txtSprintLevel.color = Color.green;
        else
            txtSprintLevel.color = Color.red;

        if (PlayerPrefs.GetInt("enemiesKilled") >= 300)
            txtEnemiesKilledSprint.color = Color.green;
        else
            txtEnemiesKilledSprint.color = Color.red;
        #endregion

        #region Eþ zamanlý Freeze Mastery Requirements text renk deðiþimi
        if (PlayerPrefs.GetFloat("Freeze Duration Purchaselevel") >= 7)
            txtFreezeLevel.color = Color.green;
        else
            txtFreezeLevel.color = Color.red;

        if (PlayerPrefs.GetInt("freezedEnemies") >= 125)
            txtFreezedEnemies.color = Color.green;
        else
            txtFreezedEnemies.color = Color.red;
        #endregion

        #region Eþ zamanlý Shield Mastery Requirements text renk deðiþimi
        if (PlayerPrefs.GetFloat("Shield Duration Purchaselevel") >= 7)
            txtShieldLevel.color = Color.green;
        else
            txtShieldLevel.color = Color.red;

        if (PlayerPrefs.GetInt("blockedBullets") >= 400)
            txtBlockedBullets.color = Color.green;
        else
            txtBlockedBullets.color = Color.red;
        #endregion

        #region Eþ zamanlý Mass Mastery Requirements text renk deðiþimi
        if (PlayerPrefs.GetFloat("Mass Explosion Damage Purchaselevel") >= 7)
            txtMassLevel.color = Color.green;
        else
            txtMassLevel.color = Color.red;

        if (PlayerPrefs.GetInt("enemiesKilled") >= 300)
            txtEnemiesKilledMass.color = Color.green;
        else
            txtEnemiesKilledMass.color = Color.red;
        #endregion

        // Sprint Mastery Claim Button
        if (PlayerPrefs.GetFloat("Sprint Speed Purchaselevel") >= 7 && PlayerPrefs.GetInt("enemiesKilled") >= 300 && !PlayerPrefs.HasKey("Sprint_Mastery_Claimed"))
            sprintClaimButton.SetActive(true);
        else
            sprintClaimButton.SetActive(false);

        // Freeze Mastery Claim Button
        if (PlayerPrefs.GetFloat("Freeze Duration Purchaselevel") >= 7 && PlayerPrefs.GetInt("freezedEnemies") >= 125 && !PlayerPrefs.HasKey("Freeze_Mastery_Claimed"))
            freezeClaimButton.SetActive(true);
        else
            freezeClaimButton.SetActive(false);

        // Shield Mastery Claim Button
        if (PlayerPrefs.GetFloat("Shield Duration Purchaselevel") >= 7 && PlayerPrefs.GetInt("blockedBullets") >= 400 && !PlayerPrefs.HasKey("Shield_Mastery_Claimed"))
            shieldClaimButton.SetActive(true);
        else
            shieldClaimButton.SetActive(false);

        // Mass Mastery Claim Button
        if (PlayerPrefs.GetFloat("Mass Explosion Damage Purchaselevel") >= 7 && PlayerPrefs.GetInt("enemiesKilled") >= 300 && !PlayerPrefs.HasKey("Mass_Mastery_Claimed"))
            massClaimButton.SetActive(true);
        else
            massClaimButton.SetActive(false);
    }
}