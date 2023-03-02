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
    [SerializeField] private GameObject panelHandPlayer;
  
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
        panelGameOver.SetActive(true);
        panelHandPlayer.SetActive(false);
        panelSelectedCards.SetActive(false);
    }

    public void TheEnd()
    {
        panelTheEnd.SetActive(true);
        panelHandPlayer.SetActive(false);
        panelSelectedCards.SetActive(false);
    }
    public void InfoGame()
    {
        panelInfoGame.SetActive(true);
    }
    public void ExitGame()
    {
        Application.Quit();
    }


}
