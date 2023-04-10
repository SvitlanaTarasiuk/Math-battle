using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Card
{
    public string Name;

    public Sprite LogoBG;
    
    public Sprite LogoImage;

    public int Number;
    
    public char Operator;

    public Card(string name, string logoBG, string logoImage, int numberCard)
    {
        Name = name;
        LogoBG = Resources.Load<Sprite>(logoBG);
        LogoImage = Resources.Load<Sprite>(logoImage);
        Number = numberCard;
    }

    public Card(string name, string logoBG, string logoImage, char operatorCard)
    { 
        Name = name;
        LogoBG = Resources.Load<Sprite>(logoBG);
        LogoImage = Resources.Load<Sprite>(logoImage);
        Operator = operatorCard;
    }
}

public static class CardManager
{
    public static List<Card> AllCards = new List<Card>();
    
    public static List<Card> NewCard = new List<Card>();
}

public class CardManagerScript : MonoBehaviour
{
    private string nameCardNumber = "Number";
    private string nameCardOperator = "Operator";
    private string bgNumberCard = "Sprites/Cards/CardNumberBG";
    private string imageNumberCard = "Sprites/Cards/CardNumberImage";
    private string bgOperatorCard = "Sprites/Cards/CardOperatorBG";
    private string imageOperatorCard = "Sprites/Cards/CardOperatorImage";
    private int[] numberAllCardArray = { 1, -1, -1, -2 };
    private int[] numberNewCardsArray = { -4, -3, -2, -1, 1, 2, 3, 4 };
    private char[] operatorCardsArray = { '+', '-' };
    private int numberCard;
    private char operatorCard;

    public void Awake()
    {
        GlobalControl.Instance.JsonController.LoadJson();

        if (CardManager.AllCards.Count == 0)
        {
            CreateAllCards();
            GlobalControl.Instance.JsonController.SaveJson();
        }
        if (CardManager.NewCard.Count == 0)
        {
            CreateNewCards();
        }
        //Debug.Log("AwakeCardManagerScript/ AllCards.Count:" + CardManager.AllCards.Count);
    }
   
    private void CreateAllCards()
    {
        CreateCardsNumber(numberAllCardArray, CardManager.AllCards);
        CreateCardsOperator(operatorCardsArray, CardManager.AllCards);
    }
   
    private void CreateNewCards()
    {
        CreateCardsNumber(numberNewCardsArray, CardManager.NewCard);
        CreateCardsOperator(operatorCardsArray, CardManager.NewCard);
    }

    private void CreateCardsNumber(int[] numberArray, List<Card> list)
    {
        int i = 0;
        while (i < numberArray.Length)
        {
            numberCard = numberArray[i];
            list.Add(new Card(nameCardNumber, bgNumberCard, imageNumberCard, numberCard));
            i++;
        }
    }

    private void CreateCardsOperator(char[] operatorArray, List<Card> list)
    {
        int i = 0;
        while (i < operatorArray.Length)
        {
            operatorCard = operatorArray[i];
            list.Add(new Card(nameCardOperator, bgOperatorCard, imageOperatorCard, operatorCard));
            i++;
        }
    }

    public void AddAllCards(Card card)
    {
        CardManager.AllCards.Add(card);
        GlobalControl.Instance.JsonController.SaveJson();
    }
}