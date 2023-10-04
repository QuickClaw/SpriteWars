using UnityEngine;

public class GetUIElements : MonoBehaviour
{
    public GameObject deathPanel;

    void Start()
    {
        deathPanel.SetActive(false);
    }
}