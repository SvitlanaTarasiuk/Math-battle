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
    [SerializeField] private GameObject panelSelecteddards;
    [SerializeField] private GameObject panelHandPlayer;

    public void Start()
    {
        //numberCard1CalculeteText.text = "N";

        //number1 = int.Parse(objClick.number1);
        //number2 = objClick.number1;
        //Debug.Log($"{number1}");
        //Debug.Log($"{number2}");
    }
    //public void SelectedCardToCalculete(string cardCalculate)
    //{
    //    Debug.Log("SelectCard");
    //    numberCard1CalculeteText.text = cardCalculate.ToString();
    //    //GetComponent<CardInfoScript>().numberCard.text;
    //    Debug.Log($"SelectCard:{numberCard1CalculeteText.text} ");
    //}
    //public void SelectedCardToCalculete()
    //{
    //    Debug.Log("SelectCard");
    //}
    public void DebugGame()
    {
        // objClick = 
    }
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
        panelSelecteddards.SetActive(false);
    }

    public void TheEnd()
    {
        panelTheEnd.SetActive(true);
        panelHandPlayer.SetActive(false);
        panelSelecteddards.SetActive(false);
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
