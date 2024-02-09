using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class EffectSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer effectMixer;

    [SerializeField] private Slider effectSlider;

    [SerializeField] private TMP_Text txtEffectVolume;

    private float effectValue;

    private void Start()
    {
        if (PlayerPrefs.HasKey("effectVolume") == false)
        {
            effectSlider.value = 100f;
            effectMixer.SetFloat("EffectVol", Mathf.Log10(effectSlider.value) * 20);
        }
        else
        {
            effectSlider.value = PlayerPrefs.GetFloat("effectVolume");
            effectMixer.SetFloat("EffectVol", Mathf.Log10(effectSlider.value) * 20);
        }

        txtEffectVolume.text = effectValue.ToString("f0");
    }

    public void ChangeMasterVolume(float sliderValue)
    {
        effectMixer.SetFloat("EffectVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("effectVolume", sliderValue);

        effectValue = sliderValue * 100;
        txtEffectVolume.text = effectValue.ToString("f0");
    }
}