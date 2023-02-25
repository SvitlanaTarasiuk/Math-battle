using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//public class CardCalculete
//{
//    public TextMeshProUGUI numberCard1CalculeteText;
//    public TextMeshProUGUI numberCard2CalculeteText;
//    public TextMeshProUGUI operatorCard3CalculeteText;
//    public CardCalculete()
//    {
//        numberCard1CalculeteText.text = "N";
//        numberCard2CalculeteText.text = "N";
//        operatorCard3CalculeteText.text = "O";
//    }

//}
public class CardToCalculete : MonoBehaviour
{
    public TextMeshProUGUI numberCard1CalculeteText;
    public TextMeshProUGUI numberCard2CalculeteText;
    public TextMeshProUGUI operatorCard3CalculeteText;
    public Button calculeteBtn;
    public GameObject objClick;
    int countCardCalculete=0;

    private void Start()
    {
        Debug.Log("Start");
        objClick = GameObject.Find("CardPref");

        if (countCardCalculete == 3)
            calculeteBtn.interactable = false;
        //else if (countCardCalculete < 3)
        //    calculeteBtn.interactable = false;

        //public Button[] buttonsLevel;

        //    for (int i = 0; i < buttonsLevel.Length; i++)
        //    {
        //        buttonsLevel[i].interactable = false;
        //    }
        //    for (int i = 0; i < levelUnlock; i++)
        //    {
        //        buttonsLevel[i].interactable = true;
        //    }

    }
    //public void SelectedCardToCalculete()
    //{
    //    Debug.Log("SelectCard");

    //    Debug.Log($"SelectFinish: {numberCard1CalculeteText.text}");


    //number1 = objClick.number1;
    //Debug.Log($"{number1}");

    //number2=objClick.GetComponent<OnClickCard>().number1;       
    //Debug.Log($"{number2}");

    //number3 = objClick.operator3;
    //Debug.Log($"{number2}");

    //numberCard1CalculeteText.text = GetComponent<OnClickCard>().number1;
    //    //GetComponent<CardInfoScript>().numberCard.text;      
    //Debug.Log("SelectCard: ");


    //numberCard1CalculeteText.text = selfCard.Number.ToString();
    //numberCard2Text.text = numberCard2.numberCard.text;
    //operatorCard3Text.text = operatorCard.numberCard.text;


    //GetComponent<OnClickCard>().cardClick.
    //    numberCard1CalculeteText.text = cardClick.GetComponent<CardInfoScript>().numberCard.ToString;
    //numberCard1CalculeteText.text = selfCard.Number.ToString();
    //numberCard2Text.text = numberCard2.numberCard.text;
    //operatorCard3Text.text = operatorCard.numberCard.text;
    //}
    public void Card1Text(string number1)
    {
        numberCard1CalculeteText.text = number1;
        Debug.Log($"CardText:{numberCard1CalculeteText.text}");
        countCardCalculete++;
        Debug.Log(countCardCalculete);
    }
    public void Card2Text(string number2)
    {
        numberCard2CalculeteText.text = number2;
        Debug.Log($"CardText:{numberCard2CalculeteText.text}");
        countCardCalculete++;
        Debug.Log(countCardCalculete);
    }
    public void Card3Text(string operator3)
    {
        operatorCard3CalculeteText.text = operator3;
        Debug.Log($"CardText:{operatorCard3CalculeteText.text}");
        countCardCalculete++;
        Debug.Log(countCardCalculete);
    }

    public void BattleCalculate()
    {
        int card1 = int.Parse(numberCard1CalculeteText.text);
        int card2 = int.Parse(numberCard2CalculeteText.text);
        char sign = Convert.ToChar(operatorCard3CalculeteText.text);
        int result = CalculateCard(card1, card2, sign);
        Debug.Log(result);
        //if(result == 0)//скидаються карти
        //{

        //}
        //else if (result > 0)//>0 удар ворогу
        //{

        //}
        //else if(result < 0)//<0 отримано захист
        //{

        //}


    


}
    public int CalculateCard(int card1, int card2, char sign)
        {
            int summa;
            //int card1 = int.Parse(numberCard1CalculeteText.text);
            //int card2 = int.Parse(numberCard2CalculeteText.text);
            //char sign = Convert.ToChar(operatorCard3CalculeteText.text);

            if (sign == '+')
            {
                summa = card1 + card2;
                Debug.Log($"{card1},+, {card2},=, {summa}");
                return summa;
            }
            else if (sign == '-')
            {
                summa = card1 + card2;
                Debug.Log($"{card1},+, {card2},=, {summa}");
                return summa;
            }
            return 0;
        }
    
}
