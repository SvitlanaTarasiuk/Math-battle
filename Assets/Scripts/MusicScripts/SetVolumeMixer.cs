using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolumeMixer : MonoBehaviour
{ 
    public AudioMixer mixer;
    public Slider slider;
    
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.25f);
    }
    
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat("GameVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }
}
