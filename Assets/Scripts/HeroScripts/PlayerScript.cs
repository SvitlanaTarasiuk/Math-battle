using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Color colorDamage;
    [SerializeField] private Image imageHpPlayer;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private ShieldCountScript shieldCountScript;
    [SerializeField] private TextMeshProUGUI hpCurrentText;
    private Image imagePlayer;
    private int shieldCount = 0;
    private int hpPlayer = 20;
    private int hpCurrent;
    private float timerInvokeResetMaterial = 0.5f;

    private void Start()
    {
        imagePlayer = GetComponent<Image>();
        shieldCountScript.ShieldCountStart();
        hpCurrent = GlobalControl.Instance.LifePlayer;
        ImageAndTextHpCurrent();
    }

    private void ImageAndTextHpCurrent()
    {
        hpCurrentText.text = hpCurrent.ToString();
        imageHpPlayer.fillAmount = (float)hpCurrent / hpPlayer;
    }

    public void Damage(int damage)
    {
        shieldCount = shieldCountScript.ShieldCount;

        if (shieldCount > 0 && damage > shieldCount)//hit more shield
        {
            hpCurrent = (hpCurrent + shieldCount) - damage;

            shieldCountScript.HpDamageTextCount(damage);
            shieldCountScript.ShieldCountStart();
        }
        else if (shieldCount > 0 && damage <= shieldCount)//hit less shield
        {
            shieldCountScript.ShieldCountAfterDamage(damage);
        }
        else
        {
            hpCurrent = hpCurrent - damage;
        }
        GlobalControl.Instance.LifePlayer = hpCurrent;
        PlayerPrefs.SetInt("LifePlayer", hpCurrent);

        ImageAndTextHpCurrent();

        imagePlayer.color = colorDamage;

        if (hpCurrent <= 0)
        {
            gameUI.GameOver();
        }
        else
        {
            Invoke(nameof(ResetMaterial), timerInvokeResetMaterial);
        }
    }

    private void ResetMaterial() => imagePlayer.color = Color.white;
}



