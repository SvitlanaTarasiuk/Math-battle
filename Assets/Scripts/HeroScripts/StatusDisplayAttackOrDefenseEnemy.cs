using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusDisplayAttackOrDefenseEnemy : MonoBehaviour
{
    [SerializeField] private Image defenseImage;
    [SerializeField] private Image attackImage;
    [SerializeField] private TextMeshProUGUI defenseCountText;
    [SerializeField] private TextMeshProUGUI attackCountText;

    public void StatusDisplayAttack(int attackCount)
    {
        attackImage.gameObject.SetActive(true);
        defenseImage.gameObject.SetActive(false);
        attackCountText.text = attackCount.ToString();
    }
   
    public void StatusDisplayDefense(int defenseCount)
    {
        defenseImage.gameObject.SetActive(true);
        attackImage.gameObject.SetActive(false);
        defenseCountText.text = defenseCount.ToString();
    }
}
