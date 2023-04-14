//using UnityEngine;
//using UnityEngine.UI;

//public class MusicController : MonoBehaviour //Create the "MusicController" object and add a script to it(scene 0)
//{
//    [SerializeField] private Slider musicGameSlider;
//    [SerializeField] private Slider soundEffectsSlider;
//    [SerializeField] private AudioSource musicGame;
//    [SerializeField] private AudioSource soundEffect;
//    private static readonly string FirstPlay = "FirstPlay";
//    private static readonly string MusicPref = "MusicPref";
//    private static readonly string SoundEffectPref = "SoundEffectPref";
//    private int firstPlayInt;
//    private float musicFloat;
//    private float soundEffectsFloat;

//    private void Start()
//    {
//        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);
//        if (firstPlayInt == 0)
//        {
//            musicFloat = 0.25f;
//            soundEffectsFloat = 0.75f;

//            musicGameSlider.value = musicFloat;
//            soundEffectsSlider.value = soundEffectsFloat;

//            PlayerPrefs.SetFloat(MusicPref, musicFloat);
//            PlayerPrefs.SetFloat(SoundEffectPref, soundEffectsFloat);
//            PlayerPrefs.SetInt(FirstPlay, firstPlayInt - 1);
//        }
//        else
//        {
//            musicFloat = PlayerPrefs.GetFloat(MusicPref);
//            musicGameSlider.value = musicFloat;

//            soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectPref);
//            soundEffectsSlider.value = soundEffectsFloat;
//        }
//    }

//    public void SaveSoundSetting()//add a method to the menu exit button (start)
//    {
//        PlayerPrefs.SetFloat(MusicPref, musicGameSlider.value);
//        PlayerPrefs.SetFloat(SoundEffectPref, soundEffectsSlider.value);
//    }

//    private void OnApplicationFocus(bool infocus)
//    {
//        if (!infocus)
//            SaveSoundSetting();
//    }

//    public void UpdateSound()//add a method to both sliders
//    {
//        musicGame.volume = musicGameSlider.value;
//        soundEffect.volume = soundEffectsSlider.value;
//        //for (int i = 0; i < soundEffectsAudio.Length; i++)
//        //{
//        //    soundEffectsAudio[i].volume = soundEffectsSlider.value;      
//        //}
//    }

//    public void MusicMenu()
//    {
//        musicGame.Stop();
//        soundEffect.Play();
//    }
//}
