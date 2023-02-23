using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    [SerializeField] private Image imageHpPlayer;
    [SerializeField] private GameUI gameUI;
    //public Animator animator;
    private SpriteRenderer sprRend;
    private int hpPlayer=20;
    private int hpCurrent;
    //private AudioSource audioSource;
    //public AudioClip audioClip;
    void Awake()
    {
        sprRend = GetComponent<SpriteRenderer>();
        hpCurrent = hpPlayer;
       //audioSource = GetComponent<AudioSource>(); 
       //animator = GetComponent<Animator>();   
    }
    void Start()
    {
        // GlobalControl.Instance.SaveScene();
        // hpPlayer = GlobalControl.Instance.life;        
        //gameUI.SetCountLifeUI(life);
        
    }
    void Update()
    {

    }
    private void Damage()
    {
        //hpPlayer -= 1;
        hpCurrent--;
        imageHpPlayer.fillAmount = (float)hpCurrent / hpPlayer;
        //GlobalControl.Instance.life = hpPlayer;
        PlayerPrefs.SetInt("Life", hpPlayer);
        sprRend.color = colorDamage;

        if (hpPlayer == 0) 
        {
            Time.timeScale = 0;
            gameUI.GameOver();

        }       
            else
            {
                Invoke("ResetMaterial", 0.5f);
            }
        }
    
    void ResetMaterial()
    {
        sprRend.color = Color.white;
    }

}



