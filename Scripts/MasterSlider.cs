using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MasterSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer masterMixer;

    [SerializeField] private Slider masterSlider;

    [SerializeField] private TMP_Text txtMasterVolume;

    private float masterValue;

    private void Start()
    {
        if (PlayerPrefs.HasKey("masterVolume") == false)
        {
            masterSlider.value = 100f;
            masterMixer.SetFloat("MasterVol", Mathf.Log10(masterSlider.value) * 20);
        }
        else
        {
            masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
            masterMixer.SetFloat("MasterVol", Mathf.Log10(masterSlider.value) * 20);
        }

        txtMasterVolume.text = masterValue.ToString("f0");
    }

    public void ChangeMasterVolume(float sliderValue)
    {
        masterMixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("masterVolume", sliderValue);

        masterValue = sliderValue * 100;
        txtMasterVolume.text = masterValue.ToString("f0");
    }
}