using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MusicSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;

    [SerializeField] private Slider musicSlider;

    [SerializeField] private TMP_Text txtMusicVolume;

    private float musicValue;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume") == false)
        {
            musicSlider.value = 100f;
            masterMixer.SetFloat("MusicVol", Mathf.Log10(musicSlider.value) * 20);
        }
        else
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            masterMixer.SetFloat("MusicVol", Mathf.Log10(musicSlider.value) * 20);
        }

        txtMusicVolume.text = musicValue.ToString("f0");
    }

    public void ChangeMusicVolume(float sliderValue)
    {
        masterMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("musicVolume", sliderValue);

        musicValue = sliderValue * 100;
        txtMusicVolume.text = musicValue.ToString("f0");
    }
}
