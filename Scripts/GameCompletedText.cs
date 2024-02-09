using UnityEngine;
using TMPro;

public class GameCompletedText : MonoBehaviour
{
    [SerializeField] private TMP_Text txtGameCompletedCount;

    void Start()
    {
        if (PlayerPrefs.HasKey("gameCompletedCount"))
            txtGameCompletedCount.text = "You have completed the game <color=green>" + PlayerPrefs.GetInt("gameCompletedCount") + "</color> times.";
        else
            txtGameCompletedCount.text = "You have completed the game <color=red>0</color> times.";
    }
}