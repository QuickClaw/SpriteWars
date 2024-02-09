using UnityEngine;
using UnityEngine.EventSystems;

public class WeaponPanelManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] private AudioSource buttonAS;

    public AudioClip click, highlight;

    public GameObject nextPanel;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Animator>() != null)
            gameObject.GetComponent<Animator>().Play(gameObject.name + "Highlighted");

        buttonAS.clip = highlight;
        buttonAS.Play();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        buttonAS.clip = click;
        buttonAS.Play();

        nextPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameObject.GetComponent<Animator>() != null)
            gameObject.GetComponent<Animator>().Play(gameObject.name + "Normal");
    }
}