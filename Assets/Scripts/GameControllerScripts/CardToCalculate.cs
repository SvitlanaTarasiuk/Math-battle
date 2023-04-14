using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardToCalculate : MonoBehaviour
{
    [SerializeField] private ShieldCountScript shieldCountPlayerScript;
    [SerializeField] private EnemyScript enemy;
    [SerializeField] private GameManagerScript gameManager;
    [SerializeField] private Button calculateBtn;
    [SerializeField] private Image shieldImage;
    [SerializeField] private Image swordImage;
    //[SerializeField] private GameMusicController gameMusicController;
    private AudioManagerMixer audioManagerMixer = AudioManagerMixer.Instance;
    private int countCardCalculate = 0;
    private int card1;
    private int card2;
    private char card3;
    private int summaCard = 0;
    private string textNumberCardCalculateStart = "N";
    private string textOperatorCardCalculateStart = "O";
    private int maxNumberCardCalculate = 3;
    private float timerCoroutineButtonCalculateActive = 0.3f;
    private float alphaColorNotActiveImage = 0.5f;
    private float alphaColorActiveImage = 1.0f;
    
    [field: SerializeField] public TextMeshProUGUI NumberCard1CalculateText { get; set; }
    
    [field: SerializeField] public TextMeshProUGUI NumberCard2CalculateText { get; set; }
    
    [field: SerializeField] public TextMeshProUGUI OperatorCard3CalculateText { get; set; }
    
    [field: SerializeField] public GameObject Card1Calculate { get; set; }
   
    [field: SerializeField] public GameObject Card2Calculate { get; set; }
   
    [field: SerializeField] public GameObject Card3Calculate { get; set; }
    
    private void Start()
    {
        //gameManager = GetComponent<GameManagerScript>();
        CardCalculateText();
        NotActiveImageResultCalculate();
        StartCoroutine(ActiveButonCoroutine());
    }
    
    IEnumerator ActiveButonCoroutine()
    {
        while (true)
        {
            ButtonCalculateActive();
            yield return new WaitForSeconds(timerCoroutineButtonCalculateActive);
        }
    }

    private void CardCalculateText()
    {
        NumberCard1CalculateText.text = textNumberCardCalculateStart;
        NumberCard2CalculateText.text = textNumberCardCalculateStart;
        OperatorCard3CalculateText.text = textOperatorCardCalculateStart;
    }

    private void NotActiveImageResultCalculate()
    {
        shieldImage.color = new Color(shieldImage.color.r, shieldImage.color.g, shieldImage.color.b, alphaColorNotActiveImage);
        swordImage.color = new Color(swordImage.color.r, swordImage.color.g, swordImage.color.b, alphaColorNotActiveImage);
    }

    private void ButtonCalculateActive()
    {
        if (countCardCalculate == maxNumberCardCalculate)
        {
            calculateBtn.interactable = true;
            summaCard = CalculateCard(card1, card2, card3);
            ActiveImageResultCalculate();
            //Debug.Log("button true");
        }
        else
            calculateBtn.interactable = false;
        //Debug.Log("button false");
    }

    public void ActiveImageResultCalculate()
    {
        if (summaCard == 0)
        {
            NotActiveImageResultCalculate();
        }
        else if (summaCard > 0)//>0 active sword
        {
            swordImage.color = new Color(swordImage.color.r, swordImage.color.g, swordImage.color.b, alphaColorActiveImage);
        }
        else if (summaCard < 0)//<0 active shield
        {
            shieldImage.color = new Color(shieldImage.color.r, shieldImage.color.g, shieldImage.color.b, alphaColorActiveImage);
        }
    }

    public void Card1Text(string number1)
    {
        audioManagerMixer.OneCard();
        //gameMusicController.OneCardMusic();
        NumberCard1CalculateText.text = number1;
        //Debug.Log($"CardText:{numberCard1CalculateText.text}");
        countCardCalculate++;
        card1 = int.Parse(NumberCard1CalculateText.text);
        //Debug.Log("countCardCalculate: " + countCardCalculate);
    }

    public void Card2Text(string number2)
    {
        audioManagerMixer.OneCard();
        //gameMusicController.OneCardMusic();
        NumberCard2CalculateText.text = number2;
        //Debug.Log($"CardText:{numberCard2CalculateText.text}");
        countCardCalculate++;
        card2 = int.Parse(NumberCard2CalculateText.text);
        //Debug.Log("countCardCalculate: " + countCardCalculate);
    }

    public void Card3Text(string operator3)
    {
        audioManagerMixer.OneCard();
        //gameMusicController.OneCardMusic();
        OperatorCard3CalculateText.text = operator3;
        //Debug.Log($"CardText:{operatorCard3CalculateText.text}");
        countCardCalculate++;
        card3 = Convert.ToChar(OperatorCard3CalculateText.text);
        //Debug.Log("countCardCalculate: " + countCardCalculate);
    }

    private int CalculateCard(int card1, int card2, char sign)
    {
        int summa;
        if (sign == '+')
        {
            summa = card1 + card2;
            //Debug.Log($"{card1},+, {card2},=, {summa}");
            return summa;
        }
        else if (sign == '-')
        {
            summa = card1 - card2;
            //Debug.Log($"{card1},, {card2},=, {summa}");
            return summa;
        }
        return 0;
    }

    public void CleanerCalculate()
    {
        CardCalculateText();
        NotActiveImageResultCalculate();
        countCardCalculate = 0;
        summaCard = 0;
        //Debug.Log("summaCard:"+ summaCard);
    }

    public void BattleResultCalculate()
    {
        if (summaCard == 0)//discard cards
        {
            gameManager.CountCardNotGame(countCardCalculate);
            CleanerCalculate();
        }
        else if (summaCard > 0)//>0 sword strike
        {
            audioManagerMixer.DamageEffect();
            //gameMusicController.DamageEffectMusic();
            enemy.Damage(Mathf.Abs(summaCard));
            gameManager.CountCardNotGame(countCardCalculate);
            CleanerCalculate();
        }
        else if (summaCard < 0)//<0 protection received
        {
            audioManagerMixer.ShieldEffect();
            //gameMusicController.ShieldEffectMusic();
            shieldCountPlayerScript.ShieldCountGame(Mathf.Abs(summaCard));
            gameManager.CountCardNotGame(countCardCalculate);
            CleanerCalculate();
        }
    }

    public void ResetCard()//return penalties from the calculator to the field
    {
        if (NumberCard1CalculateText.text != textNumberCardCalculateStart)
        {
            Card1Calculate.SetActive(true);
        }
        if (NumberCard2CalculateText.text != textNumberCardCalculateStart)
        {
            Card2Calculate.SetActive(true);
        }
        if (OperatorCard3CalculateText.text != textOperatorCardCalculateStart)
        {
            Card3Calculate.SetActive(true);
        }
        CleanerCalculate();

    }
    public void DestroyCard()//destroy the cards that passed the calculator
    {
        if (countCardCalculate > 0)
        {
            Destroy(Card1Calculate);
            Destroy(Card2Calculate);
            Destroy(Card3Calculate);
        }

    }

}
