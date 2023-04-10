using TMPro;
using UnityEngine;

public class CountRoundScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countRoundGameText;
    private int countRound;

    private void Start()
    {
        countRound = PlayerPrefs.GetInt("CountRound");
    }

    public void CountRound()
    {
        countRound++;
        countRoundGameText.text = countRound.ToString();

        GlobalControl.Instance.CountRound = countRound;
        PlayerPrefs.SetInt("CountRound", countRound);

        GlobalControl.Instance.CountAllRoundAndSave();

    }    
}

