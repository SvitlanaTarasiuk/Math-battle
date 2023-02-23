using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{ 
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
   public void ExitGame()
    {
        Application.Quit();  
    }
  
}


