using UnityEngine;
using TMPro;

public class CollectStar : MonoBehaviour
{
    private PlayerScript PlayerScript;

    private TMP_Text txt_objectiveStar;

    private AudioSource StarPickupAS;
    public AudioClip starPickupSound;

    public Vector2 spawnPosition;

    public ParticleSystem starPickupEffect;
    private ParticleSystem objectiveCompletedEffect;

    void Start()
    {
        spawnPosition = transform.position;

        PlayerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        txt_objectiveStar = GameObject.Find("txt_objectiveStar").GetComponent<TMP_Text>();       
        StarPickupAS = GameObject.Find("StarPickup").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag is "Player")
        {
            transform.position = new Vector2(5000f, 5000f);

            PlayerScript.collectedStars++;

            StarPickupAS.PlayOneShot(starPickupSound);

            PlayerScript.txt_starObjective.text = "• Collect stars." + " (<b>" + PlayerScript.collectedStars.ToString() + "</b>/" + PlayerScript.totalStars.ToString() + ")" + " <color=yellow>(+" + PlayerScript.bonusStarGold.ToString() + "g)</color>";

            Instantiate(starPickupEffect, spawnPosition, Quaternion.identity);

            if (PlayerScript.collectedStars == PlayerScript.totalStars)
            {
                objectiveCompletedEffect = GameObject.Find("gold text effect").GetComponent<ParticleSystem>();
                objectiveCompletedEffect.Play();
                StarPickupAS.PlayOneShot(starPickupSound);

                PlayerScript.gold += PlayerScript.bonusStarGold;

                PlayerScript.collectedGoldCurrentLevel += PlayerScript.bonusStarGold;
            }
        }
    }
}