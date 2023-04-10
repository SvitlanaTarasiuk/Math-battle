using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelTheEndFinish;
    [SerializeField] private GameObject panelSelectedCards;
    [SerializeField] private GameObject panelRoundGame;
    [SerializeField] private GameObject panelNewCardNewScene;
    [SerializeField] private GameObject panelTheEndNewScene;
    [SerializeField] private GameObject panelHandPlayer;
    [SerializeField] private NewCardScript newCardScript;
    [SerializeField] private GameManagerScript gameManagerScript;
    [SerializeField] private CardToCalculate cardToCalculate;
    [SerializeField] private Button PauseBtn;
    //[SerializeField] private GameMusicController gameMusicController;
    private AudioManagerMixer audioManagerMixer = AudioManagerMixer.Instance;
    private float timerInvokeRoundGameActive = 1.7f;
    private float timerInvokeRoundGameNotActive = 0.5f;
    private float timerInvokePanelSelectedCardsActive = 1.0f;
    private int numberLastScene = 5;
    
    public void PauseOn()
    {
        Time.timeScale = 0.00001f;
        panelPause.SetActive(true);
        PauseBtn.interactable = false;
        //gameMusicController.MusicMenuOn();
        audioManagerMixer.MusicMenu();
    }

    public void PauseOffContinue()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
        PauseBtn.interactable = true;
        //gameMusicController.MusicMenuOff();
        audioManagerMixer.MusicMenuOff();      
    }
   
    public void Calculate()
    {
        cardToCalculate.BattleResultCalculate();
    }
   
    public void ResetCalculate()
    {
        cardToCalculate.ResetCard();
    }
   
    public void EndTurnCalculate()
    {        
        panelSelectedCards.SetActive(false);
        gameManagerScript.EndTurn();
        Invoke(nameof(PanelSelectedCardsActive), timerInvokePanelSelectedCardsActive);
    }
  
    private void PanelSelectedCardsActive()
    {
        panelSelectedCards.SetActive(true);
    }
   
    public void GameOver()
    {
        Time.timeScale = 0;
        PauseBtn.interactable = false;
        //gameMusicController.MusicMenuOn();
        audioManagerMixer.MusicMenu();
        panelRoundGame.SetActive(false);
        panelGameOver.SetActive(true);
        panelHandPlayer.SetActive(false);
        panelSelectedCards.SetActive(false);
    }

    public void TheEnd()
    {
        Time.timeScale = 0;
        PauseBtn.interactable = false;
        //gameMusicController.MusicMenuOn();
        audioManagerMixer.MusicMenu();
        int currentScene = GlobalControl.Instance.GetLastSavedScene();

        if (currentScene < numberLastScene)
        {
            newCardScript.NewCardPanelStart();
            panelTheEndNewScene.SetActive(true);
            panelHandPlayer.SetActive(false);
            panelSelectedCards.SetActive(false);
        }
        else
        {
            panelTheEndFinish.SetActive(true);
            panelHandPlayer.SetActive(false);
            panelSelectedCards.SetActive(false);
        }
    }

    public void NewCardNewScene()
    {
        panelNewCardNewScene.SetActive(true);
        panelTheEndNewScene.SetActive(false); ;
    }

    public void RoundGameActiveInvoke()
    {
        Invoke(nameof(RoundGameActive), timerInvokeRoundGameActive);
    }

    private void RoundGameActive()//GameManager
    {
        panelRoundGame.SetActive(true);
        PauseBtn.interactable = false;
        Invoke(nameof(RoundGameNotActive), timerInvokeRoundGameNotActive);
    }
    
    private void RoundGameNotActive()
    {
        panelRoundGame.SetActive(false);
        PauseBtn.interactable = true;
    }
   
    public void NewScene()
    {
        Time.timeScale = 1;
        panelNewCardNewScene.SetActive(false);
        int currentScene = GlobalControl.Instance.GetLastSavedScene();
        int newScene = currentScene + 1;
        SceneManager.LoadScene(newScene);
        PlayerPrefs.SetInt("Levels", newScene);
        PlayerPrefs.SetInt("CountRound", 1);
        
        audioManagerMixer.MusicMenuOff();
    }
}
