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
    public GameMusicController gameMusicController;
    public GameObject panelNewCardNewScene;
    public GameObject panelHandPlayer;
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1; 
        //panelHandPlayer.SetActive(false);
        //panelSelecteddards.SetActive(false);
    }
    public void PauseOn()
    {
        Time.timeScale = 0.00001f;
        panelPause.SetActive(true);
        gameMusicController.MusicMenuOn();
    }

    public void PauseOffContinue()
    {      
        panelPause.SetActive(false);
        gameMusicController.MusicMenuOff();
        Time.timeScale = 1;
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
        Debug.Log("SceneManager.GetActiveScene().buildIndex: "+SceneManager.GetActiveScene().buildIndex);

        if (SceneManager.GetActiveScene().buildIndex < 5)
        {
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
    public void NewCardGame()
    {       
        panelNewCardNewScene.SetActive(true);   
    }

    public void InfoGame()
    {
        panelInfoGame.SetActive(true);
    }
    public void RoundGameActive()
    {
        panelRoundGame.SetActive(true);
        Invoke("RoundGameNotActive",0.5f);
    }
    void RoundGameNotActive()
    {
        panelRoundGame.SetActive(false);
    }
    public void NewScene()
    {
        panelNewCardNewScene.SetActive(false);
        int currentScene=SceneManager.GetActiveScene().buildIndex;
        int newScene = currentScene + 1;
        SceneManager.LoadScene(newScene);
        Debug.Log("New Scene: " + newScene);
        Time.timeScale = 1;
        
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
