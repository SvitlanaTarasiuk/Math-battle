using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    [SerializeField] private Image imageHpPlayer;
    [SerializeField] private GameUI gameUI;
    public TextMeshProUGUI shieldCountText;
    public TextMeshProUGUI hpCurrentText;  
    public TextMeshProUGUI hpDamageText;
    //public Animator animator;
    private SpriteRenderer sprRend;
    private int shieldCount = 0;
    private int hpPlayer=20;
    private int hpCurrent;
    //private AudioSource audioSource;
    //public AudioClip audioClip;
    void Awake()
    {
        sprRend = GetComponent<SpriteRenderer>();
        hpCurrent = hpPlayer;
        shieldCountText.text = shieldCount.ToString();
        hpCurrentText.text = hpCurrent.ToString();
       //audioSource = GetComponent<AudioSource>(); 
       //animator = GetComponent<Animator>();   
    }
    void Start()
    {
        // GlobalControl.Instance.SaveScene();
        // hpPlayer = GlobalControl.Instance.life;        
        //gameUI.SetCountLifeUI(life);        
    }  
    public void ShieldCount(int shield)
    {
        
        shieldCount += Mathf.Abs(shield);
        shieldCountText.text = shieldCount.ToString();

    }
    private void HpDamage()
    {           
            hpDamageText.enabled = true;
    }
    public void Damage(int damage)
    {
        //hpCurrent-=Mathf.Abs(damage);
        if (damage > shieldCount)
        {
            hpDamageText.text = "- "+(damage - shieldCount).ToString();
            Invoke(nameof(HpDamage), 2f);
            hpDamageText.enabled = false;

        }
        hpCurrent = (hpCurrent+shieldCount)-Mathf.Abs(damage);      
        hpCurrentText.text = hpCurrent.ToString();
        imageHpPlayer.fillAmount = (float)hpCurrent / hpPlayer;
        //GlobalControl.Instance.life = hpPlayer;
        //PlayerPrefs.SetInt("Life", hpPlayer);
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



