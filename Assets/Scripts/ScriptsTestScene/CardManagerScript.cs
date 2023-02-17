using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Card
{
    public string Name;
    public Sprite Logo;
    public int Attack;
    public int Defense;

    public Card(string name,string logoPath, int attack, int defense)
    {
        Name = name;
        Logo = Resources.Load<Sprite>(logoPath);
        Attack = attack;
        Defense = defense;
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
        CardManager.AllCards.Add(new Card("operator +", "Sprites/Cards/1", 1, 6));
        CardManager.AllCards.Add(new Card("operator -", "Sprites/Cards/2", 2, 5));
        CardManager.AllCards.Add(new Card("number 1", "Sprites/Cards/3", -3, 4));
        CardManager.AllCards.Add(new Card("number 2", "Sprites/Cards/4", 4, 3));
        CardManager.AllCards.Add(new Card("number 3", "Sprites/Cards/5", -5, 2));
        CardManager.AllCards.Add(new Card("number 4", "Sprites/Cards/6", 6, 1));
    }

}
