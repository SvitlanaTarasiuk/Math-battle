using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardToCalculate : MonoBehaviour
{
    public TextMeshProUGUI numberCard1CalculateText;
    public TextMeshProUGUI numberCard2CalculateText;
    public TextMeshProUGUI operatorCard3CalculateText;
    public Button calculateBtn;
    public GameObject objClick;
    int countCardCalculate = 0;
    public Image shieldImage;
    public Image swordImage;
    public PlayerScript player;
    public EnemyScript enemy;
    private int card1;
    private int card2;
    private char card3;
    private int summaCard = 0;

    private void Start()
    {
        objClick = GameObject.Find("CardPref");
        CardCalculateText();
        NotActiveImageResultCalculate();
    }
    private void Update()
    {
        ButtonCalculateActive();
        ActiveImageResultCalculate();
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
        }
        else
            calculateBtn.interactable = false;
    }
    public void ActiveImageResultCalculate()
    {
        if (summaCard == 0)
        {
            NotActiveImageResultCalculate();
        }
        else if (summaCard > 0)//>0 меч активний
        {
            swordImage.color = new Color(swordImage.color.r, swordImage.color.g, swordImage.color.b, 1f);
        }
        else if (summaCard < 0)//<0 щит активний
        {
            shieldImage.color = new Color(shieldImage.color.r, shieldImage.color.g, shieldImage.color.b, 1f);
        }
    }
    public void Card1Text(string number1)
    {
        numberCard1CalculateText.text = number1;
        Debug.Log($"CardText:{numberCard1CalculateText.text}");
        countCardCalculate++;
        card1 = int.Parse(numberCard1CalculateText.text);
        Debug.Log(countCardCalculate);
    }
    public void Card2Text(string number2)
    {
        numberCard2CalculateText.text = number2;
        Debug.Log($"CardText:{numberCard2CalculateText.text}");
        countCardCalculate++;
        card2 = int.Parse(numberCard2CalculateText.text);
        Debug.Log(countCardCalculate);
    }
    public void Card3Text(string operator3)
    {
        operatorCard3CalculateText.text = operator3;
        Debug.Log($"CardText:{operatorCard3CalculateText.text}");
        countCardCalculate++;
        card3 = Convert.ToChar(operatorCard3CalculateText.text);
        Debug.Log(countCardCalculate);
    }
    private int CalculateCard(int card1, int card2, char sign)
    {
        int summa;
        if (sign == '+')
        {
            summa = card1 + card2;
            Debug.Log($"{card1},+, {card2},=, {summa}");
            return summa;
        }
        else if (sign == '-')
        {
            summa = card1 - card2;
            Debug.Log($"{card1},, {card2},=, {summa}");
            return summa;
        }
        return 0;
    }
    private void CleanerCalculate()
    {
            CardCalculateText();
            NotActiveImageResultCalculate();
            countCardCalculate = 0;
            summaCard=0;
            Debug.Log(summaCard);
    }
    public void BattleResult()
    {
        if (summaCard == 0)//скидаються карти
        {

            CleanerCalculate();            
        }
        else if (summaCard > 0)//>0 удар ворогу
        {
            enemy.Damage(summaCard);
            CleanerCalculate();
            NotActiveImageResultCalculate();
            enemy.StartAttackOrDefenseEnemy();
        }
        else if (summaCard < 0)//<0 отримано захист
        {
            player.ShieldCount(summaCard);
            CleanerCalculate();
            NotActiveImageResultCalculate();
            enemy.StartAttackOrDefenseEnemy();
        }

    }
}
