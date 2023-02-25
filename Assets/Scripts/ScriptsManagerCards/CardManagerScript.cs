 using JetBrains.Annotations;
using System.Collections;
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
}

public class CardManagerScript : MonoBehaviour
{
    public void Awake()
    {
        CardManager.AllCards.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage",1));
        CardManager.AllCards.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage",-1));
        CardManager.AllCards.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage",-1));
        CardManager.AllCards.Add(new Card("Number", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage",-2));
        CardManager.AllCards.Add(new Card("Operator", "Sprites/Cards/CardOperatorBG", "Sprites/Cards/CardOperatorImage",'+'));
        CardManager.AllCards.Add(new Card("Operator", "Sprites/Cards/CardOperatorBG", "Sprites/Cards/CardOperatorImage",'-'));
    }

}
