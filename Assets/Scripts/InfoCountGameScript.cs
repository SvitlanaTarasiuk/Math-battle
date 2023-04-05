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
    private int countAllRoundGame;
    private int countRoundLevel;
    private int lifePlayer;
    private int lifeEnemy;
    private int countLevel;
    private GlobalControl globalControl = GlobalControl.Instance;
   
    public void InfoGame()
    {
        panelInfoGame.SetActive(true);

        lifePlayer = globalControl.lifePlayer;
        lifeEnemy = globalControl.lifeEnemy;
        countLevel = globalControl.currentSceneIndex;
        countRoundLevel = globalControl.countRound;
        countAllRoundGame = globalControl.countAllRound;

        lifePlayerText.text = lifePlayer.ToString();
        lifeEnemyText.text = lifeEnemy.ToString();
        infoRoundLevelText.text = countRoundLevel.ToString();
        infoAllRoundGameText.text= countAllRoundGame.ToString();
        countLevelText.text = countLevel.ToString();
    }

}
