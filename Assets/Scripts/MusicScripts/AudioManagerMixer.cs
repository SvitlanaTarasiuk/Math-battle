using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioSource _audioGame;
    [SerializeField] private AudioSource _audioEffectMenu;
    [SerializeField] private AudioSource _audioEffect;
    [SerializeField] private List<AudioClip> _musicClipEffect = new List<AudioClip>();

    public static string Musik_Key { get; } = "GameVolumeKey";

    public static string Effect_Key { get; } = "EffectVolumeKey";

    public static AudioManagerMixer Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadVolume();
    }
    private void LoadVolume()//volume saved MusicControllerMixer.cs
    {
        //Debug.Log("LoadVolume");
        float musicVolume = PlayerPrefs.GetFloat(Musik_Key, 0.5f);
        float effectVolume = PlayerPrefs.GetFloat(Effect_Key, 0.5f);

        _mixer.SetFloat(MusicControllerMixer.Mixer_Music, Mathf.Log10(musicVolume) * 20);
        _mixer.SetFloat(MusicControllerMixer.Mixer_Effect, Mathf.Log10(effectVolume) * 20);
    }
    public void MusicMenu()
    {
        _audioGame.Stop();
        _audioEffectMenu.Play();
    }
    public void MusicMenuOff()
    {
        _audioGame.Play();
        _audioEffectMenu.Stop();
    }
    public void ShieldEffect()
    {
        _audioEffect.PlayOneShot(_musicClipEffect[0]);
    }
    public void DamageEffect()
    {
        _audioEffect.PlayOneShot(_musicClipEffect[1]);
    }
    public void MusicCardFromDesk()
    {
        _audioEffect.PlayOneShot(_musicClipEffect[2]);
    }
    public void OneCard()
    {
        _audioEffect.PlayOneShot(_musicClipEffect[3]);
    }

}
