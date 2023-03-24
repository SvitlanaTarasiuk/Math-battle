using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    private int firstPlayInt;
    private float musicFloat;
    private float soundEffectsFloat;
    public Slider musicGameSlider;
    public Slider soundEffectsSlider;
    public AudioSource musicGame;
    public AudioSource soundEffect;
    

    private void Start()
    {
        firstPlayInt=PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt==0 )
        {
            musicFloat = 0.25f;
            soundEffectsFloat = 0.75f;

            musicGameSlider.value = musicFloat;
            soundEffectsSlider.value = soundEffectsFloat;

            PlayerPrefs.SetFloat(MusicPref,musicFloat);
            PlayerPrefs.SetFloat(SoundEffectPref,soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, firstPlayInt - 1);
        }
        else
        {
            musicFloat=PlayerPrefs.GetFloat(MusicPref);
            musicGameSlider.value=musicFloat;

            soundEffectsFloat=PlayerPrefs.GetFloat(SoundEffectPref);
            soundEffectsSlider.value=soundEffectsFloat;
        }
    }
    public void SaveSoundSetting()//добавити метод на кнопку виходу з меню(старт)
    {
        PlayerPrefs.SetFloat(MusicPref,musicGameSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectsSlider.value);
    }
    
    private void OnApplicationFocus(bool infocus)
    {
        if( !infocus )
            SaveSoundSetting();
    }
   public void UpdateSound()//добавити метод у обидва слайдери
    {
        musicGame.volume=musicGameSlider.value;
        soundEffect.volume = soundEffectsSlider.value;
    }
    public void MusicMenu()
    {
        musicGame.Stop();
        soundEffect.Play();
    }
}
