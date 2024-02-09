using UnityEngine;
using UnityEngine.UI;

public class ShopPagesNavigate : MonoBehaviour
{
    public Color selectedColor;
    public Color defaultColor;

    public GameObject shopPanel;
    public GameObject masteryPanel;

    public Button shopButton;
    public Button masteryButton;

    private bool shopOpened;
    private bool masteriesOpened;

    public void ShopPanel()
    {
        if (!shopOpened)
        {
            shopPanel.SetActive(true);
            masteryPanel.SetActive(false);

            shopButton.image.color = selectedColor;
            masteryButton.image.color = defaultColor;

            shopOpened = true;
            masteriesOpened = false;
        }
    }

    public void MasteryPanel()
    {
        if (!masteriesOpened)
        {
            shopPanel.SetActive(false);
            masteryPanel.SetActive(true);

            shopButton.image.color = defaultColor;
            masteryButton.image.color = selectedColor;

            shopOpened = false;
            masteriesOpened = true;
        }
    }
}