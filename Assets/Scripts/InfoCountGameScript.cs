using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class InfoCountGameScript : MonoBehaviour
{
    public TextMeshProUGUI countRoundGameText;
    public TextMeshProUGUI infoRoundGameText;
    public TextMeshProUGUI infoDamagePlayerGameText;
    public TextMeshProUGUI infoDamageEnemyText;

    public void CountRoundText(int countRound)
    {
        infoRoundGameText.text = countRound.ToString();
        countRoundGameText.text = countRound.ToString();
    }
    public void CountDamagePlayerText(int countDamagePlayer)
    {
        infoDamagePlayerGameText.text = countDamagePlayer.ToString();
    }
    public void CountDamageEnemyText(int countDamageEnemy)
    {
        infoDamageEnemyText.text = countDamageEnemy.ToString();
    }
}
