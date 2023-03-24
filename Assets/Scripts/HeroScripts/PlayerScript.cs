using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    [SerializeField] private Image imageHpPlayer;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private ShieldCountScript shieldCountScript;
    public TextMeshProUGUI shieldCountText;
    public TextMeshProUGUI hpCurrentText;
    public TextMeshProUGUI hpDamageText;
    private Image imagePlayer;
    private int shieldCount = 0;
    private int hpPlayer = 20;
    private int hpCurrent;

    void Awake()
    {
        imagePlayer = GetComponent<Image>();
        shieldCountScript.ShieldCountStart();
    }
    void Start()
    {
        hpCurrent = GlobalControl.Instance.lifePlayer;
        hpCurrentText.text = hpCurrent.ToString();
        imageHpPlayer.fillAmount = (float)hpCurrent / hpPlayer;
    }

    private void HpDamage()
    {
        hpDamageText.text = null;
    }
    public void Damage(int damage)
    {
        if (shieldCount > 0 && damage >= shieldCount)//удар більше щита
        {
            hpCurrent = (hpCurrent + shieldCount) - damage;

            hpDamageText.text = "- " + (damage - shieldCount).ToString();          
            Invoke(nameof(HpDamage), 1f);

            shieldCountScript.ShieldCountStart();
        }
        else if (shieldCount > 0 && damage < shieldCount)//удар менше щита
        {
            shieldCountScript.ShieldCountAfterDamage(damage);
        }
        else
        {
            hpCurrent = hpCurrent - damage;
        }
        GlobalControl.Instance.lifePlayer = hpCurrent;
        PlayerPrefs.SetInt("LifePlayer", hpCurrent);

        hpCurrentText.text = hpCurrent.ToString();
        imageHpPlayer.fillAmount = (float)hpCurrent / hpPlayer;

        imagePlayer.color = colorDamage;

        if (hpCurrent <= 0)
        {
            gameUI.GameOver();
        }
        else
        {
            Invoke(nameof(ResetMaterial), 0.5f);
        }
    }

    void ResetMaterial()
    {
        imagePlayer.color = Color.white;
    }

}



