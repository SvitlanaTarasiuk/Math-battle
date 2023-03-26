using UnityEngine;

public class GameMusicController : MonoBehaviour
{
    private static readonly string MusicPref = "MusicPref";
    private static readonly string SoundEffectPref = "SoundEffectPref";
    public AudioSource musicGame;
    //public AudioSource[] soundEffectsAudio; 
    public AudioSource soundEffect;
    public AudioClip[] soundEffectClip;
    private float musicFloat;
    private float soundEffectsFloat;

    private void Awake()
    {
        LevelSoundSettings();
    }
    void LevelSoundSettings()
    {
        musicFloat = PlayerPrefs.GetFloat(MusicPref);
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectPref);

        musicGame.volume = musicFloat;
        soundEffect.volume = soundEffectsFloat;
        //for (int i = 0; i < soundEffectsAudio.Length; i++)
        //{
        //    soundEffectsAudio[i].volume = soundEffectsFloat;      
        //}
    }
    public void MusicMenuOn()
    {
        musicGame.Stop();
        soundEffect.Play();
        //soundEffectsAudio[0].Play();
    }
    public void MusicMenuOff()
    {
        musicGame.Play();
        soundEffect.Stop();
        //soundEffectsAudio[0].Stop();
    }
    public void ShieldEffectMusic()
    {
        soundEffect.PlayOneShot(soundEffectClip[0]);
        //soundEffectsAudio[1].PlayOneShot(soundEffectsAudio[1].clip);       
    }
    public void DamageEffectMusic()
    {
        soundEffect.PlayOneShot(soundEffectClip[1]);
        //soundEffectsAudio[2].PlayOneShot(soundEffectsAudio[2].clip);
    }
    public void CardFromDescMusic()
    {
        soundEffect.PlayOneShot(soundEffectClip[2]);
        //soundEffectsAudio[3].PlayOneShot(soundEffectsAudio[3].clip);
    }
    public void OneCardMusic()
    {
        soundEffect.PlayOneShot(soundEffectClip[3]);
        //soundEffectsAudio[4].PlayOneShot(soundEffectsAudio[4].clip);
    }
}
