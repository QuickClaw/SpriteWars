using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    GameObject playerHealthBar;
    Slider playerHealthSlider;
    Image playerHealthFill;

    Canvas canvas;
    Slider sliderEnemy;
    Image fillEnemy;

    private void Start()
    {               
        if (gameObject.tag is "Player")
        {
            playerHealthBar = GameObject.Find("PlayerHealthBar");
            playerHealthSlider = playerHealthBar.GetComponent<Slider>();
            playerHealthFill = playerHealthBar.GetComponentsInChildren<Image>().ToList().Find(x => x.name.Contains("PlayerFill"));

            slider = playerHealthSlider;
            fill = playerHealthFill;
        }

        if (gameObject.tag is "Enemy")
        {
            canvas = gameObject.GetComponentsInChildren<Canvas>().ToList().Find(x => x.name.Contains("Canvas_Enemy"));
            sliderEnemy = canvas.GetComponentsInChildren<Slider>().ToList().Find(x => x.name.Contains("EnemyHealthBar"));
            fillEnemy = canvas.GetComponentsInChildren<Image>().ToList().Find(x => x.name.Contains("EnemyFill"));

            slider = sliderEnemy;
            fill = fillEnemy;
        }

        fill.color = gradient.Evaluate(1f);
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}