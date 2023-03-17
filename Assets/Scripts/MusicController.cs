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
    public Slider musicSlider;
    public Slider soundEffectsSlider;
    public AudioSource musicAudio;
    public AudioSource[] soundEffectsAudio;
    

    private void Start()
    {
        firstPlayInt=PlayerPrefs.GetInt(FirstPlay);
        if(firstPlayInt==0 )
        {
            musicFloat = 0.25f;
            soundEffectsFloat = 0.75f;

            musicSlider.value = musicFloat;
            soundEffectsSlider.value = soundEffectsFloat;

            PlayerPrefs.SetFloat(MusicPref,musicFloat);
            PlayerPrefs.SetFloat(SoundEffectPref,soundEffectsFloat);
            PlayerPrefs.SetInt(FirstPlay, firstPlayInt - 1);
        }
        else
        {
            musicFloat=PlayerPrefs.GetFloat(MusicPref);
            musicSlider.value=musicFloat;

            soundEffectsFloat=PlayerPrefs.GetFloat(SoundEffectPref);
            soundEffectsSlider.value=soundEffectsFloat;
        }
    }
    public void SaveSoundSetting()//добавити метод на кнопку виходу з меню(старт)
    {
        PlayerPrefs.SetFloat(MusicPref,musicSlider.value);
        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectsSlider.value);
    }
    
    private void OnApplicationFocus(bool infocus)
    {
        if( !infocus )
            SaveSoundSetting();
    }
   public void UpdateSound()//добавити метод у обидва слайдери
    {
        musicAudio.volume=musicSlider.value;
        for ( int i = 0; i<soundEffectsAudio.Length; i++ )
        {
            soundEffectsAudio[i].volume = soundEffectsSlider.value;
        }
    }
    public void MusicMenu()
    {
        musicAudio.Pause();       
        soundEffectsAudio[0].Play();
    }
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
