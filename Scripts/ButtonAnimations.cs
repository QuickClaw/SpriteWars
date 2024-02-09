using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAnimations : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private AudioSource buttonAS;

    [SerializeField] private AudioClip click, highlight;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonAS.PlayOneShot(highlight);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        buttonAS.PlayOneShot(click);
    }
}