using UnityEngine;
using Steamworks;
using UnityEngine.SceneManagement;

public class SteamAchievements : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 10)
        {
            SteamUserStats.SetAchievement("achievement_01");
            SteamUserStats.StoreStats();
        }

        if (SceneManager.GetActiveScene().buildIndex == 20)
        {
            SteamUserStats.SetAchievement("achievement_02");
            SteamUserStats.StoreStats();
        }

        if (SceneManager.GetActiveScene().buildIndex == 30)
        {
            SteamUserStats.SetAchievement("achievement_03");
            SteamUserStats.StoreStats();
        }

        if (SceneManager.GetActiveScene().buildIndex == 40)
        {
            SteamUserStats.SetAchievement("achievement_04");
            SteamUserStats.StoreStats();
        }
    }

    private void Update()
    {
        if (!SteamManager.Initialized)
        {
            return;
        }
    }
}