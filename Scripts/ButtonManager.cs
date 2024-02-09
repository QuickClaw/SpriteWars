using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel; // Ana Panel

    [SerializeField] private GameObject newGamePanel; // New Game paneli
    [SerializeField] private GameObject creditsPanel; // Credits Paneli
    [SerializeField] private GameObject weaponsPanel; // Weapons Paneli
    [SerializeField] private GameObject startPanel; // Round 1 Start Panel
    [SerializeField] private GameObject howToPlayPanel; // Round 1 Start Panel

    [SerializeField] private GameObject magicWeaponsPanel, militaryWeaponsPanel, medievalWeaponsPanel; // Silah bilgi panelleri

    private bool newGamePanelOpened;
    private bool creditsPanelOpened;
    private bool weaponsPanelOpened;

    void Start()
    {
        newGamePanelOpened = false;
        creditsPanelOpened = false;
        weaponsPanelOpened = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if (startPanel.activeInHierarchy)
        {
            Time.timeScale = 0f;

            //GameObject player = GameObject.Find("Player");
            //player.GetComponent<Movement>().enabled = false;
        }
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level 1");
    }

    #region New Game

    // Yeni oyun panelini açar.
    public void OpenNewGamePanel()
    {
        if (newGamePanelOpened == false)
        {
            newGamePanel.SetActive(true);
            newGamePanelOpened = true;
        }
    }

    // Yeni oyun panelini kapatýr.
    public void CloseNewGamePanel()
    {
        if (newGamePanelOpened == true)
        {
            newGamePanel.SetActive(false);
            newGamePanelOpened = false;
        }
    }

    #endregion

    #region Weapons

    // Weapons panelini açar.
    public void OpenWeaponsPanel()
    {
        if (weaponsPanelOpened == false)
        {
            weaponsPanel.SetActive(true);
            weaponsPanelOpened = true;
        }
    }

    // Weapons panelini kapatýr.
    public void CloseWeaponsPanel()
    {
        if (weaponsPanelOpened == true)
        {
            weaponsPanel.SetActive(false);
            weaponsPanelOpened = false;
        }
    }

    #endregion

    #region Credits

    // Credits panelini açar, kapatýr.
    public void OpenCloseCreditsPanel()
    {
        if (creditsPanelOpened == false)
        {
            creditsPanel.SetActive(true);
            creditsPanelOpened = true;
        }
        else
        {
            creditsPanel.SetActive(false);
            creditsPanelOpened = false;
        }
    }

    #endregion

    #region My Other Games

    // Oyuncuyu istenilen sayfaya yönlendirir.
    public void OpenURL(string link)
    {
        Application.OpenURL(link);
    }

    #endregion

    #region Quit

    // Oyundan çýkar.
    public void Quit()
    {
        Application.Quit();
    }

    #endregion

    #region Yes

    // Bütün ilerlemeyi siler ve 1. bölümden oyuna baþlar.
    public void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level 1");
    }
    #endregion

    #region Silah Bilgi Panelleri kapatma

    // Magic panelini kapatýr.
    public void CloseMagicPanel()
    {
        magicWeaponsPanel.SetActive(false);
    }

    // Military panelini kapatýr.
    public void CloseMilitaryPanel()
    {
        militaryWeaponsPanel.SetActive(false);
    }

    // Medieval panelini kapatýr.
    public void CloseMedievalPanel()
    {
        medievalWeaponsPanel.SetActive(false);
    }
    #endregion

    public void CloseStartPanel()
    {
        startPanel.SetActive(false);

        //GameObject player = GameObject.Find("Player");
        //player.GetComponent<Movement>().enabled = true;

        Time.timeScale = 1f;
    }

    public void OpenHowToPlayPanel()
    {
        howToPlayPanel.SetActive(true);
    }

    public void CloseHowToPlayPanel()
    {
        howToPlayPanel.SetActive(false);
    }
}