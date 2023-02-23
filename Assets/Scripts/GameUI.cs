using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
        [SerializeField] private GameObject panelPause;
        [SerializeField] private GameObject panelGameOver;
        [SerializeField] private GameObject panelTheEnd;
        [SerializeField] private GameObject panelInfoGame;

        public void NewGame()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
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
        }

        public void TheEnd()
        {
            panelTheEnd.SetActive(true);
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
