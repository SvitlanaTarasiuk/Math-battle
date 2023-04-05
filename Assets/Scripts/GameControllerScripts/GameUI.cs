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
    [SerializeField] private GameMusicController gameMusicController;
    [SerializeField] private CardToCalculate cardToCalculate;
    [SerializeField] private Button PauseBtn;

    public void PauseOn()
    {
        Time.timeScale = 0.00001f;
        panelPause.SetActive(true);
        PauseBtn.interactable = false;
        gameMusicController.MusicMenuOn();
        //AudioManagerMixer.instance.MusicMenu();
    }

    public void PauseOffContinue()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
        PauseBtn.interactable = true;
        gameMusicController.MusicMenuOff();
        // AudioManagerMixer.instance.MusicMenuOff();      
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
        Invoke(nameof(PanelSelectedCardsActive), 1f);
    }
    private void PanelSelectedCardsActive()
    {
        panelSelectedCards.SetActive(true);
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        PauseBtn.interactable = false;
        gameMusicController.MusicMenuOn();
        panelRoundGame.SetActive(false);
        panelGameOver.SetActive(true);
        panelHandPlayer.SetActive(false);
        panelSelectedCards.SetActive(false);
    }

    public void TheEnd()
    {
        Time.timeScale = 0;
        PauseBtn.interactable = false;
        gameMusicController.MusicMenuOn();
        int currentScene = GlobalControl.Instance.GetLastSavedScene();
        //Debug.Log("SceneManager.GetActiveScene().buildIndex: " + SceneManager.GetActiveScene().buildIndex);

        if (currentScene < 5)
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
        Invoke(nameof(RoundGameActive), 1.7f);
    }

    private void RoundGameActive()//GameManager
    {
        panelRoundGame.SetActive(true);
        Invoke(nameof(RoundGameNotActive), 0.5f);
    }
    private void RoundGameNotActive()
    {
        panelRoundGame.SetActive(false);
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
    }
}
