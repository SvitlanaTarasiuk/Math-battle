using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelTheEnd;
    [SerializeField] private GameObject panelInfoGame;
    [SerializeField] private GameObject panelSelectedCards;
    [SerializeField] private GameObject panelRoundGame;
    [SerializeField] private NewCardScript newCardScript;
    [SerializeField] private GameManagerScript gameManagerScript;
    public GameMusicController gameMusicController;
    public GameObject panelNewCardNewScene;
    public GameObject panelHandPlayer;
    
    public void PauseOn()
    {
        Time.timeScale = 0.00001f;
        panelPause.SetActive(true);
        gameMusicController.MusicMenuOn();
        //AudioManagerMixer.instance.MusicMenu();
    }

    public void PauseOffContinue()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
        gameMusicController.MusicMenuOff();
        // AudioManagerMixer.instance.MusicMenuOff();      
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameMusicController.MusicMenuOn();
        panelRoundGame.SetActive(false);
        panelGameOver.SetActive(true);
        panelHandPlayer.SetActive(false);
        panelSelectedCards.SetActive(false);
    }

    public void TheEnd()
    {
        Time.timeScale = 0;
        gameMusicController.MusicMenuOn();
        int currentScene = GlobalControl.Instance.GetLastSavedScene();
        Debug.Log("SceneManager.GetActiveScene().buildIndex: " + SceneManager.GetActiveScene().buildIndex);

        if (currentScene < 5) //if (SceneManager.GetActiveScene().buildIndex < 5)
        {
            newCardScript.NewCardPanelStart();
            panelNewCardNewScene.SetActive(true);
            panelHandPlayer.SetActive(false);
            panelSelectedCards.SetActive(false);
        }
        else
        {
            panelTheEnd.SetActive(true);
            panelHandPlayer.SetActive(false);
            panelSelectedCards.SetActive(false);
        }
    }
    
    public void InfoGame()
    {
        panelInfoGame.SetActive(true);
    }
    public void RoundGameActive()//GameManager
    {
        panelRoundGame.SetActive(true);
        Invoke(nameof(RoundGameNotActive), 0.5f);
    }
    void RoundGameNotActive()
    {
        panelRoundGame.SetActive(false);
    }
    public void NewScene()
    {
        Time.timeScale = 1;
        panelNewCardNewScene.SetActive(false);
        int currentScene = GlobalControl.Instance.GetLastSavedScene();//SceneManager.GetActiveScene().buildIndex;
        int newScene = currentScene + 1;
        SceneManager.LoadScene(newScene);
        PlayerPrefs.SetInt("Levels", newScene);
    }
}
