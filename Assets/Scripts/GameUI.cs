using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private GameObject panelTheEnd;
    [SerializeField] private GameObject panelInfoGame;
    [SerializeField] private GameObject panelSelectedCards;   
    [SerializeField] private GameObject panelRoundGame;
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
    }

    public void PauseOffContinue()
    {
        Time.timeScale = 1;
        panelPause.SetActive(false);
    }

    public void GameOver()
    {
        panelRoundGame.SetActive(false);
        panelGameOver.SetActive(true);
        panelHandPlayer.SetActive(false);
        panelSelectedCards.SetActive(false);
    }

    public void TheEnd()
    {
        Time.timeScale = 0;
        Debug.Log("SceneManager.GetActiveScene().buildIndex: "+SceneManager.GetActiveScene().buildIndex);
        panelTheEnd.SetActive(true);
        panelHandPlayer.SetActive(false);
        panelSelectedCards.SetActive(false);
        //if (SceneManager.GetActiveScene().buildIndex < 5)
        //{
        //    panelNewCard.SetActive(true);
        //    panelHandPlayer.SetActive(false);
        //    panelSelectedCards.SetActive(false);
        //}
        //else
        //{
        //    panelTheEnd.SetActive(true);
        //    panelHandPlayer.SetActive(false);
        //    panelSelectedCards.SetActive(false);
        //}
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
        Invoke("RoundGameNotActive",0.2f);
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
        //SceneManager.LoadScene(currentScene+1);
        Debug.Log("New Scene: " + newScene);
        Time.timeScale = 1;
        
    }
    public void ExitGame()
    {
        Application.Quit();
    }


}
