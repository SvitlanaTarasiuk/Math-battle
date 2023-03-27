using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    public void NewGame()//
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        GlobalControl.Instance.ResetData();

        //AudioManagerMixer.instance.MusicMenuOff();
    }

    public void StartGame()//Start/Continue
    {
        Time.timeScale = 1;
        int currentScene = GlobalControl.Instance.GetLastSavedScene();
        SceneManager.LoadScene(currentScene);

        //AudioManagerMixer.instance.MusicMenuOff();
    }
    public void ExitGame()
    {
        //#if UNITY_EDITOR
        //        UnityEditor.EditorApplication.isPlaying = false;
        //#endif
        //        Application.Quit();

        SceneManager.LoadScene(0);//для WEBGL
    }
}
