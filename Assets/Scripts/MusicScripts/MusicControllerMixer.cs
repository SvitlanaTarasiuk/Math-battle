using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicControllerMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _musicSlider;//Inspector minValue 0.0001
    [SerializeField] private Slider _effectSlider;//Inspector minValue 0.0001
    private readonly float _multiplier = 20;

    public static string Mixer_Music { get; } = "GameVolume";//Exposed parameters, name

    public static string Mixer_Effect { get; } = "EffectVolume";//Exposed parameters, name

    private void Awake()
    {
        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _effectSlider.onValueChanged.AddListener(SetEffectVolume);
    }

    private void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat(AudioManagerMixer.Musik_Key, 0.75f);//1f
        _effectSlider.value = PlayerPrefs.GetFloat(AudioManagerMixer.Effect_Key, 0.75f);//1f

    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManagerMixer.Musik_Key, _musicSlider.value);
        PlayerPrefs.SetFloat(AudioManagerMixer.Effect_Key, _effectSlider.value);
    }

    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat(Mixer_Music, Mathf.Log10(volume) * _multiplier);
    }

    public void SetEffectVolume(float volume)
    {
        _audioMixer.SetFloat(Mixer_Effect, Mathf.Log10(volume) * _multiplier);
    }

}
