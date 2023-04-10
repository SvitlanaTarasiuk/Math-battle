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
    private GlobalControl globalControl = GlobalControl.Instance;
    private int countAllRoundGame;
    private int countRoundLevel;
    private int lifePlayer;
    private int lifeEnemy;
    private int countLevel;
   
    public void InfoGame()
    {
        panelInfoGame.SetActive(true);

        lifePlayer = globalControl.LifePlayer;
        lifeEnemy = globalControl.LifeEnemy;
        countLevel = globalControl.CurrentSceneIndex;
        countRoundLevel = globalControl.CountRound;
        countAllRoundGame = globalControl.CountAllRound;

        lifePlayerText.text = lifePlayer.ToString();
        lifeEnemyText.text = lifeEnemy.ToString();
        infoRoundLevelText.text = countRoundLevel.ToString();
        infoAllRoundGameText.text= countAllRoundGame.ToString();
        countLevelText.text = countLevel.ToString();
    }

}
