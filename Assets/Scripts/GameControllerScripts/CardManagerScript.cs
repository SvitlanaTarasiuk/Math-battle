using System.Collections.Generic;
using UnityEngine;

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
    public void Awake()
    {
        CreateAllCards();
        CreateNewCards();
    }
    void CreateAllCards()
    {
        CardManager.AllCards.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", 1));
        CardManager.AllCards.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", -1));
        CardManager.AllCards.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", -1));
        CardManager.AllCards.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", -2));
        CardManager.AllCards.Add(new Card("Operator", "Sprites/Cards/CardOperatorBG", "Sprites/Cards/CardOperatorImage", '+'));
        CardManager.AllCards.Add(new Card("Operator", "Sprites/Cards/CardOperatorBG", "Sprites/Cards/CardOperatorImage", '-'));
    }
    void CreateNewCards()
    {
        CardManager.NewCard.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", -4));
        CardManager.NewCard.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", -3));
        CardManager.NewCard.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", -2));
        CardManager.NewCard.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", -1));
        CardManager.NewCard.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", 1));
        CardManager.NewCard.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", 2));
        CardManager.NewCard.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", 3));
        CardManager.NewCard.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", 4));
        CardManager.NewCard.Add(new Card("Operator", "Sprites/Cards/CardOperatorBG", "Sprites/Cards/CardOperatorImage", '+'));
        CardManager.NewCard.Add(new Card("Operator", "Sprites/Cards/CardOperatorBG", "Sprites/Cards/CardOperatorImage", '-'));
    }
    public void AddAllCards(Card card)
    {
        CardManager.AllCards.Add(card);
    }
}