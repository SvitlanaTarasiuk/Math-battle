using TMPro;
using UnityEngine;

public class ShieldCountScript : MonoBehaviour
{
    [SerializeField] private ShieldImageResultScript shieldImageResultScript;
    [SerializeField] private TextMeshProUGUI shieldCountText;
    private int shieldCount;
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

}
