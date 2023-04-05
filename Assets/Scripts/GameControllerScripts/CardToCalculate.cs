using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardToCalculate : MonoBehaviour
{
    [SerializeField] private ShieldCountScript shieldCountPlayerScript;
    [SerializeField] private GameMusicController gameMusicController;
    [SerializeField] private EnemyScript enemy;
    [SerializeField] private OnClickCard clickCard;
    [SerializeField] private GameManagerScript gameManager;
    [SerializeField] private Button calculateBtn;
    [SerializeField] private Image shieldImage;
    [SerializeField] private Image swordImage;
    private int countCardCalculate = 0;
    private int card1;
    private int card2;
    private char card3;
    private int summaCard = 0;
    public TextMeshProUGUI numberCard1CalculateText;
    public TextMeshProUGUI numberCard2CalculateText;
    public TextMeshProUGUI operatorCard3CalculateText;
    public GameObject card1Calculate;
    public GameObject card2Calculate;
    public GameObject card3Calculate;

    private void Start()
    {
        gameManager = GetComponent<GameManagerScript>();
        CardCalculateText();
        NotActiveImageResultCalculate();
        StartCoroutine(ActiveButonCoroutine());
    }

    IEnumerator ActiveButonCoroutine()
    {
        while (true)
        {
            ButtonCalculateActive();
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void CardCalculateText()
    {
        numberCard1CalculateText.text = "N";
        numberCard2CalculateText.text = "N";
        operatorCard3CalculateText.text = "O";
    }

    private void NotActiveImageResultCalculate()
    {
        shieldImage.color = new Color(shieldImage.color.r, shieldImage.color.g, shieldImage.color.b, 0.5f);
        swordImage.color = new Color(swordImage.color.r, swordImage.color.g, swordImage.color.b, 0.5f);
    }

    private void ButtonCalculateActive()
    {
        if (countCardCalculate == 3)
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
            swordImage.color = new Color(swordImage.color.r, swordImage.color.g, swordImage.color.b, 1f);
        }
        else if (summaCard < 0)//<0 active shield
        {
            shieldImage.color = new Color(shieldImage.color.r, shieldImage.color.g, shieldImage.color.b, 1f);
        }
    }

    public void Card1Text(string number1)
    {
        //AudioManagerMixer.instance.OneCard();
        gameMusicController.OneCardMusic();
        numberCard1CalculateText.text = number1;
        //Debug.Log($"CardText:{numberCard1CalculateText.text}");
        countCardCalculate++;
        card1 = int.Parse(numberCard1CalculateText.text);
        //Debug.Log("countCardCalculate: " + countCardCalculate);
    }

    public void Card2Text(string number2)
    {
        //AudioManagerMixer.instance.OneCard();
        gameMusicController.OneCardMusic();
        numberCard2CalculateText.text = number2;
        //Debug.Log($"CardText:{numberCard2CalculateText.text}");
        countCardCalculate++;
        card2 = int.Parse(numberCard2CalculateText.text);
        //Debug.Log("countCardCalculate: " + countCardCalculate);
    }

    public void Card3Text(string operator3)
    {
        //AudioManagerMixer.instance.OneCard();
        gameMusicController.OneCardMusic();
        operatorCard3CalculateText.text = operator3;
        //Debug.Log($"CardText:{operatorCard3CalculateText.text}");
        countCardCalculate++;
        card3 = Convert.ToChar(operatorCard3CalculateText.text);
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
            //AudioManagerMixer.instance.DamageEffect();
            gameMusicController.DamageEffectMusic();
            enemy.Damage(Mathf.Abs(summaCard));
            gameManager.CountCardNotGame(countCardCalculate);
            CleanerCalculate();
        }
        else if (summaCard < 0)//<0 protection received
        {
            //AudioManagerMixer.instance.ShieldEffect();
            gameMusicController.ShieldEffectMusic();
            shieldCountPlayerScript.ShieldCountGame(Mathf.Abs(summaCard));
            gameManager.CountCardNotGame(countCardCalculate);
            CleanerCalculate();
        }
    }

    public void ResetCard()//return penalties from the calculator to the field
    {
        if (numberCard1CalculateText.text != "N")
        {
            card1Calculate.SetActive(true);
        }
        if (numberCard2CalculateText.text != "N")
        {
            card2Calculate.SetActive(true);
        }
        if (operatorCard3CalculateText.text != "O")
        {
            card3Calculate.SetActive(true);
        }
        CleanerCalculate();

    }
    public void DestroyCard()//destroy the cards that passed the calculator
    {
        if (countCardCalculate > 0)
        {
            Destroy(card1Calculate);
            Destroy(card2Calculate);
            Destroy(card3Calculate);
        }

    }

}
