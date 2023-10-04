using UnityEngine;
using TMPro;

public class GetTexts : MonoBehaviour
{
    Player Player;

    public TMP_Text txtPlayerHealthAmount;
    public TMP_Text txtPlayerName;

    void Start()
    {
        Player = FindObjectOfType<Player>();
        txtPlayerName.text = "Batu";

        txtPlayerHealthAmount.text = Player.currentHealth.ToString("0") + " / " + Player.maxHealth;
    }
}