using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject nextLevelPanel;

    public int gameCompletedCount;
    void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (!nextLevelPanel.activeInHierarchy && !shopPanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!pausePanel.activeInHierarchy)
                {
                    pausePanel.SetActive(true);
                    Time.timeScale = 0f;
                }
                else
                {
                    pausePanel.SetActive(false);
                    Time.timeScale = 1f;
                }
            }
        }
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OpenShop()
    {
        shopPanel.SetActive(true);
        nextLevelPanel.SetActive(false);
    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        nextLevelPanel.SetActive(true);
    }

    public void MainMenuLastLevel()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;

        gameCompletedCount++;
        PlayerPrefs.SetInt("gameCompletedCount", gameCompletedCount);
    }
}