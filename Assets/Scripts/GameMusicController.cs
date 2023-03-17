using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicController : MonoBehaviour
{
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    public AudioSource musicAudio;
    public AudioSource[] soundEffectsAudio;    
    private float musicFloat;
    private float soundEffectsFloat;

    private void Awake()
    {
        LevelSoundSettings();
    }

    void LevelSoundSettings()
    {
        musicFloat=PlayerPrefs.GetFloat(MusicPref);
        soundEffectsFloat =PlayerPrefs.GetFloat(SoundEffectPref);

        musicAudio.volume=musicFloat;
        for (int i = 0; i < soundEffectsAudio.Length; i++)
        {
            soundEffectsAudio[i].volume = soundEffectsFloat;      
        }
    }
    public void MusicMenuOn()
    {
        musicAudio.Pause();
        soundEffectsAudio[0].Play();
    }
    public void MusicMenuOff()
    {
        musicAudio.UnPause();
        soundEffectsAudio[0].Pause();
    }
    public void ShieldEffectMusic()
    {
        soundEffectsAudio[1].PlayOneShot(soundEffectsAudio[1].clip);       
    }
    public void DamageEffectMusic()
    {
        soundEffectsAudio[2].PlayOneShot(soundEffectsAudio[2].clip);
    }
    public void CardFromDescMusic()
    {
        soundEffectsAudio[3].PlayOneShot(soundEffectsAudio[3].clip);
    }
    public void OneCardMusic()
    {
        soundEffectsAudio[4].PlayOneShot(soundEffectsAudio[4].clip);
    }
}
