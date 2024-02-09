using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Gradient gradient;

    public Slider slider;
    private Image fill;

    private GameObject playerHealthBar;
    private Slider playerHealthSlider;
    private Image playerHealthFill;

    private Canvas enemyCanvas;
    private Slider enemySlider;
    private Image enemyFill;

    private void Start()
    {
        if (gameObject.tag is "Player")
        {
            playerHealthBar = GameObject.Find("PlayerHealthBar");
            playerHealthSlider = playerHealthBar.GetComponent<Slider>();
            playerHealthFill = playerHealthBar.GetComponentsInChildren<Image>().ToList().Find(x => x.name.Contains("PlayerFill"));

            slider = playerHealthSlider;
            fill = playerHealthFill;

            slider.maxValue = gameObject.GetComponent<PlayerScript>().maxHealth;
        }

        if (gameObject.tag is "Enemy" || gameObject.tag is "Boss")
        {
            enemyCanvas = gameObject.GetComponentsInChildren<Canvas>().ToList().Find(x => x.name.Contains("Canvas_Enemy"));
            enemySlider = enemyCanvas.GetComponentsInChildren<Slider>().ToList().Find(x => x.name.Contains("EnemyHealthBar"));
            enemyFill = enemyCanvas.GetComponentsInChildren<Image>().ToList().Find(x => x.name.Contains("EnemyFill"));

            slider = enemySlider;
            fill = enemyFill;

            slider.maxValue = gameObject.GetComponent<Enemy>().maxHealth;
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