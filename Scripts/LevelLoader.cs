using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private PlayerScript PlayerScript;

    public GameObject loadingScreen;
    public Slider loadingSlider;

    public static int buildIndex = 0;

    public TMP_Text txtProgress;

    private void Start()
    {
        buildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Ýstediðin bölümü açar
    public void LoadLevel(int sceneIndex)
    {
        int saveIndex = PlayerPrefs.GetInt("saveIndex");

        if (buildIndex > saveIndex)
            PlayerPrefs.SetInt("saveIndex", buildIndex);

        PlayerPrefs.SetInt("buildIndex", buildIndex);

        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    public void NextLevel()
    {
        int saveIndex = PlayerPrefs.GetInt("saveIndex");

        if (buildIndex > saveIndex)
            PlayerPrefs.SetInt("saveIndex", buildIndex);

        PlayerPrefs.SetInt("buildIndex", buildIndex);

        PlayerPrefs.SetInt("Gold", PlayerScript.gold);

        StartCoroutine(ContinueAsynchronously());
    }

    // Kaldýðýn bölümden devam eder
    public void ContinueLevel()
    {
        StartCoroutine(ContinueAsynchronously());
    }

    // Yeni oyun baþlatýr
    public void StartNewGame()
    {
        StartCoroutine(StartNewGameAsynchronously());
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingSlider.value = progress;
            txtProgress.text = (progress * 100f).ToString("f0") + "%";

            yield return null;
        }
    }

    IEnumerator ContinueAsynchronously()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("saveIndex") + 1);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingSlider.value = progress;
            txtProgress.text = (progress * 100f).ToString("f0") + "%";

            yield return null;
        }
    }

    IEnumerator StartNewGameAsynchronously()
    {
        PlayerPrefs.DeleteAll();
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingSlider.value = progress;
            txtProgress.text = (progress * 100f).ToString("f0") + "%";

            yield return null;
        }
    }
}