using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManagerMixer : MonoBehaviour
{
    public static AudioManagerMixer instance;
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private AudioSource audioGame;
    [SerializeField] private AudioSource audioEffectMenu;
    [SerializeField] private AudioSource audioEffect;
    [SerializeField] private List<AudioClip> musicClip = new List<AudioClip>();
    public const string Musik_Key = "GameVolume";
    public const string Effect_Key = "EffectVolume";
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        float musicVolume = PlayerPrefs.GetFloat(Musik_Key, 0.5f);
        float effectVolume = PlayerPrefs.GetFloat(Effect_Key, 0.5f);

        mixer.SetFloat(MusicControllerMixer.Mixer_Music, Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(MusicControllerMixer.Mixer_Effect, Mathf.Log10(effectVolume) * 20);
    }
    public void MusicMenu()                  //AudioManagerMixer.instance.MusicMenu();
    {
        audioGame.Stop();
        audioEffectMenu.Play();
    }
    public void MusicMenuOff()
    {
        audioGame.Play();
        audioEffectMenu.Stop();
    }
    public void ShieldEffect()
    {
        audioEffect.PlayOneShot(musicClip[0]);
    }
    public void DamageEffect()
    {
        audioEffect.PlayOneShot(musicClip[1]);
    }
    public void MusicCardFromDesk()
    {
        audioEffect.PlayOneShot(musicClip[2]);
    }
    public void OneCard()
    {
        audioEffect.PlayOneShot(musicClip[3]);
    }

}
