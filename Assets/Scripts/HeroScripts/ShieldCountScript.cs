using TMPro;
using UnityEngine;

public class ShieldCountScript : MonoBehaviour
{
    [SerializeField] private ShieldImageResultScript shieldImageResultScript;
    [SerializeField] private TextMeshProUGUI shieldCountText;
    [SerializeField] private TextMeshProUGUI hpDamageText = null;
    public int shieldCount;
    public void ShieldCountStart()
    {
        shieldCount = 0;
        shieldCountText.text = shieldCount.ToString();
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
    public void HpDamageTextCount(int damage)//кількість нанесеної шкоди,якщо невистачило щита
    {
        hpDamageText.text = "- " + (damage - shieldCount).ToString();
        Invoke(nameof(HpDamage), 0.5f);
    }
    private void HpDamage()
    {
        hpDamageText.text = null;
    }
}
