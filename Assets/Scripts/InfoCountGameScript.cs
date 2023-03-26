using TMPro;
using UnityEngine;


public class InfoCountGameScript : MonoBehaviour
{
    [SerializeField] private GameObject panelInfoGame;
    [SerializeField] private TextMeshProUGUI countLevelText;
    [SerializeField] private TextMeshProUGUI infoRoundLevelText;
    [SerializeField] private TextMeshProUGUI infoAllRoundGameText;
    [SerializeField] private TextMeshProUGUI lifePlayerText;
    [SerializeField] private TextMeshProUGUI lifeEnemyText;
    [SerializeField] private int countAllRoundGame;
    [SerializeField] private int countRoundLevel;
    [SerializeField] private int lifePlayer;
    [SerializeField] private int lifeEnemy;
    [SerializeField] private int countLevel;


    public void InfoGame()
    {
        panelInfoGame.SetActive(true);

        lifePlayer = GlobalControl.Instance.lifePlayer;
        lifeEnemy = GlobalControl.Instance.lifeEnemy;
        countLevel = GlobalControl.Instance.currentSceneIndex;
        countRoundLevel = GlobalControl.Instance.countRound;
        countAllRoundGame = GlobalControl.Instance.countAllRound;

        lifePlayerText.text = lifePlayer.ToString();
        lifeEnemyText.text = lifeEnemy.ToString();
        infoRoundLevelText.text = countRoundLevel.ToString();
        infoAllRoundGameText.text= countAllRoundGame.ToString();
        countLevelText.text = countLevel.ToString();
    }

}
