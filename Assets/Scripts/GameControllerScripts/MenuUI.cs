using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private MusicController musicController;
    
    public void Menu()
    {
        panelMenu.SetActive(true);
        musicController.MusicMenu();       
        //AudioManagerMixer.instance.MusicMenu();
    }
}