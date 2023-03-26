using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicControllerMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    public AudioMixerGroup mixer;
    [SerializeField] private Slider musicSlider;//Inspector minValue 0.0001
    [SerializeField] private Slider effectSlider;//Inspector minValue 0.0001
    public const string Mixer_Music = "GameVolume";//Exposed parameters, name
    public const string Mixer_Effect = "EffectVolume";//Exposed parameters, name

    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        effectSlider.onValueChanged.AddListener(SetEffectVolume);
    }
    private void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(AudioManagerMixer.Musik_Key, 1f);//1f
        effectSlider.value = PlayerPrefs.GetFloat(AudioManagerMixer.Effect_Key, 1f);//1f
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManagerMixer.Musik_Key, musicSlider.value);
        PlayerPrefs.SetFloat(AudioManagerMixer.Effect_Key, effectSlider.value);
    }

    private void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat(Mixer_Music, Mathf.Log10(volume) * 20);
    }
    private void SetEffectVolume(float volume)
    {
        audioMixer.SetFloat(Mixer_Effect, Mathf.Log10(volume) * 20);
    }

    //***********************************************************
    //public AudioMixerGroup mixer;
    //public Slider musicSlider;
    //public Toggle musicToggle;
    //private void Start()
    //{
    //    musicToggle.isOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
    //    musicSlider.value = PlayerPrefs.GetFloat("MasterMusic", 1);
    //}
    //public void ToggleMusic(bool enabled)
    //{
    //    if (enabled)
    //        mixer.audioMixer.SetFloat("GameVolume", 0);
    //    else
    //        mixer.audioMixer.SetFloat("GameVolume", -80);
    //    PlayerPrefs.SetFloat("MusicEnabled", enabled ? 1 : 0);
    //}
    //public void ChangeVolume(float volume)
    //{
    //    mixer.audioMixer.SetFloat("MasterMusic", Mathf.Lerp(-80, 0, volume));
    //    PlayerPrefs.SetFloat("MasterMusic", volume);
    //}
    //*********************************************************
    //public AudioMixer audioMixer;

    //public void SetVolume(float volume)
    //{
    //    audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    //}

    //public void SetQuality(int qualityIndex)
    //{
    //    QualitySettings.SetQualityLevel(qualityIndex);
    //}
    //public void Sound()
    //{

    //    AudioListener.pause = !AudioListener.pause;
    //}

}
