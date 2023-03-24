using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;
    public MusicController musicController;
    
    public void Menu()
    {
        panelMenu.SetActive(true);
        musicController.MusicMenu();       
        //AudioManagerMixer.instance.MusicMenu();
    }
}