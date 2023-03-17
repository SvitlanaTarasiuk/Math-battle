using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    [SerializeField] private Image imageHpPlayer;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private ShieldImageResultScript shieldImageResultScript;
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
        ShieldCountStart();
        hpCurrentText.text = hpCurrent.ToString();
        //audioSource = GetComponent<AudioSource>(); //audioSource.PlayOneShot(audioClip);
        //animator = GetComponent<Animator>();   
    }
    void Start()
    {
        // GlobalControl.Instance.SaveScene();
        // hpPlayer = GlobalControl.Instance.life;        
        //gameUI.SetCountLifeUI(life);        
    }
    public void ShieldCountStart()//Start
    {
        shieldCount = 0;
        shieldCountText.text = shieldCount.ToString();
    }
    public void ShieldCount(int shield)
    {
        shieldImageResultScript.StartCoroutineShieldImage();
        shieldCount += shield;
        shieldCountText.text = shieldCount.ToString();
    }
    private void HpDamage()
    {           
            hpDamageText.enabled = false;
    }
    public void Damage(int damage)
    {
        if (shieldCount > 0 && damage >= shieldCount)//удар більше щита
        {
            hpCurrent = (hpCurrent + shieldCount) - damage;
            hpDamageText.text = "- " + (damage - shieldCount).ToString();
            hpDamageText.enabled = true;
            Invoke("HpDamage", 2f);
            shieldCount = 0;
            shieldCountText.text = shieldCount.ToString();
        }
        else if (shieldCount > 0 && damage < shieldCount)//удар менше щита
        {
            shieldCount -= damage;
            shieldCountText.text = shieldCount.ToString();        
        }
        else
        {
            hpCurrent = hpCurrent - damage;
        }

        hpCurrentText.text = hpCurrent.ToString();
        imageHpPlayer.fillAmount = (float)hpCurrent / hpPlayer;
        //GlobalControl.Instance.life = hpPlayer;
        //PlayerPrefs.SetInt("Life", hpPlayer);
        sprRend.color = colorDamage;

        if (hpCurrent <= 0) 
        {          
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



