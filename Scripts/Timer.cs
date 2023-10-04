using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    Player Player;

    public float totalTime = 20f;
    private float currentTime;
    public TMP_Text timerText;

    public GameObject againPanel;

    void Start()
    {
        currentTime = totalTime;
        againPanel.SetActive(false);

        Player = FindObjectOfType<Player>();
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.CeilToInt(currentTime).ToString();

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            timerText.text = "Time: " + "0";

            againPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Again()
    {
        Time.timeScale = 1f;

        againPanel.SetActive(false);        
    }
}
