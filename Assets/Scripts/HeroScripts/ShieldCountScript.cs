using TMPro;
using UnityEngine;

public class ShieldCountScript : MonoBehaviour
{
    [SerializeField] private ShieldImageResultScript shieldImageResultScript;
    [SerializeField] private TextMeshProUGUI shieldCountText;
    [SerializeField] private TextMeshProUGUI hpDamageText = null;
    private float timerInvokeHpDamage = 0.5f;
    private float timerInvokeShieldCountStart = 1.0f;
    public int shieldCount { get; private set; }

    public void ShieldCountStart()
    {
        shieldCount = 0;
        shieldCountText.text = shieldCount.ToString();
    }

    public void ShieldCountStartInvoke()
    {
        Invoke(nameof(ShieldCountStart),timerInvokeShieldCountStart);
    }

    public void ShieldCountGame(int shield)
    {
        shieldImageResultScript.StartCoroutineShieldImage();
        shieldCount += shield;
        shieldCountText.text = shieldCount.ToString();
    }

    public void ShieldCountAfterDamage(int damage)
    {
        shieldCount -= damage;
        shieldCountText.text = shieldCount.ToString();
    }

    public void HpDamageTextCount(int damage)//the amount of damage dealt if there was not enough shield
    {
        hpDamageText.text = "- " + (damage - shieldCount).ToString();
        Invoke(nameof(HpDamage), timerInvokeHpDamage);
    }

    private void HpDamage()
    {
        hpDamageText.text = null;
    }
}
