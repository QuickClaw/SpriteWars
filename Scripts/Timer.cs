using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private PlayerScript PlayerScript;
    [SerializeField] private Shooting Shooting;

    [SerializeField] private float totalTime;

    [SerializeField] private TMP_Text txtTimer;
    [SerializeField] private TMP_Text txtEnemiesKilled;
    [SerializeField] private TMP_Text txtShotsFired;
    [SerializeField] private TMP_Text txtGold;
    [SerializeField] private TMP_Text txtLevel;
    [SerializeField] private TMP_Text txtBossObjective;

    [SerializeField] private GameObject timesUpPanel;
    [SerializeField] private GameObject nextLevelPanel;
    [SerializeField] private GameObject deathPanel;
    [SerializeField] private GameObject nextLevelAnimObject;

    [SerializeField] private GameObject tickIcon;
    [SerializeField] private GameObject crossIcon;
    [SerializeField] private GameObject tickIconBoss;
    [SerializeField] private GameObject crossIconBoss;

    [SerializeField] private Collider2D playerCollider;

    [SerializeField] private AudioSource objectiveCompletedAS;
    [SerializeField] private AudioSource bossDefeatedAS;

    [SerializeField] private ParticleSystem objectiveCompletedEffect;
    [SerializeField] private ParticleSystem bossDefeatedEffect;

    [SerializeField] private int totalEnemies;
    public int deadEnemies;

    private int bonusGold;
    private int bonusBossGold;

    public float currentTime;

    private bool objectiveCompleted;
    private bool bossDefeated;

    public int minBonusGold, maxBonusGold;

    public int defeatedBossCount;

    public string bossName;

    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex >= 1 && SceneManager.GetActiveScene().buildIndex <= 9)
            totalTime = 15;

        if (SceneManager.GetActiveScene().buildIndex >= 11 && SceneManager.GetActiveScene().buildIndex <= 19)
            totalTime = 20f;

        if (SceneManager.GetActiveScene().buildIndex >= 21 && SceneManager.GetActiveScene().buildIndex <= 29)
            totalTime = 25;

        if (SceneManager.GetActiveScene().buildIndex >= 31 && SceneManager.GetActiveScene().buildIndex <= 39)
            totalTime = 30;

        playerCollider = GameObject.Find("Player").GetComponent<Collider2D>();

        Time.timeScale = 1f;

        currentTime = totalTime;
        timesUpPanel.SetActive(false);

        txtLevel.text = "Level " + SceneManager.GetActiveScene().buildIndex.ToString() + "/40";

        crossIcon.SetActive(true);
        tickIcon.SetActive(false);

        bonusGold = Random.Range(minBonusGold, maxBonusGold);
        bonusBossGold = bonusGold * 3;

        if (tickIconBoss != null)
        {
            crossIconBoss.SetActive(true);
            tickIconBoss.SetActive(false);

            txtBossObjective.text = "• Defeat " + "<color=red>" + bossName + "</color>." + " <color=yellow>(+" + bonusBossGold.ToString() + "g)</color>";
        }

        objectiveCompleted = false;
        bossDefeated = false;

        if (PlayerPrefs.HasKey("Gold"))
            PlayerScript.gold = PlayerPrefs.GetInt("Gold");
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        txtTimer.text = "Time: " + Mathf.CeilToInt(currentTime).ToString();
        txtShotsFired.text = "Shots Fired: " + Shooting.shotsFired.ToString();
        txtEnemiesKilled.text = "• Kill enemies." + " (<b>" + deadEnemies.ToString() + "</b>/" + totalEnemies.ToString() + ")" + " <color=yellow>(+" + bonusGold.ToString() + "g)</color>";
        txtGold.text = PlayerScript.gold.ToString();

        if (PlayerScript.dead)
            deathPanel.SetActive(true);

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            txtTimer.text = "Time: " + "0";

            playerCollider.enabled = false;
            nextLevelAnimObject.SetActive(true);
            Invoke(nameof(NextLevel), 2.5f);
        }

        if (!objectiveCompleted)
        {
            if (deadEnemies >= totalEnemies)
                GetBonusObjectiveGold();
        }

        if (!bossDefeated)
        {
            if (defeatedBossCount > 0)
                DefeatBossObjective();
        }
    }

    public void NextLevel()
    {
        nextLevelAnimObject.GetComponent<RawImage>().enabled = false;
        Time.timeScale = 0;
        nextLevelPanel.SetActive(true);
    }

    public void GetBonusObjectiveGold()
    {
        PlayerScript.gold += bonusGold;
        PlayerScript.collectedGoldCurrentLevel += bonusGold;

        objectiveCompletedEffect.Play();
        objectiveCompletedAS.Play();

        crossIcon.SetActive(false);
        tickIcon.SetActive(true);

        objectiveCompleted = true;
    }

    public void DefeatBossObjective()
    {
        PlayerScript.gold += bonusBossGold;
        PlayerScript.collectedGoldCurrentLevel += bonusBossGold;

        bossDefeatedEffect.Play();
        bossDefeatedAS.Play();

        crossIconBoss.SetActive(false);
        tickIconBoss.SetActive(true);

        bossDefeated = true;
    }

    #region Button
    public void TryAgain()
    {
        PlayerScript.Respawn();

        timesUpPanel.SetActive(false);
        deathPanel.SetActive(false);

        deadEnemies = 0;

        currentTime = totalTime;

        GameObject[] enemyBullets = GameObject.FindGameObjectsWithTag("Enemy Bullet");

        for (int i = 0; i < enemyBullets.Length; i++)
            enemyBullets[i].SetActive(false);
    }

    public void NextLevelButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion
}