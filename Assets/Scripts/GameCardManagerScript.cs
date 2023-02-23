using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//public struct CardInfoOperator
//{
//    public string Name;
//    public Sprite LogoBG;
//    public Sprite LogoImage;
//    public char Sign;
 

//    public CardInfoOperator(string name, string logoBG, string logoImage, char sign)
//    {
//        Name = name;
//        LogoBG = Resources.Load<Sprite>(logoBG);
//        LogoImage = Resources.Load<Sprite>(logoImage);
//        Sign = sign;
//    }
  
//}
public struct CardInfoNumber
{
    public string Name;
    public Sprite LogoBG;
    public Sprite LogoImage;
    public int Number;

    public CardInfoNumber(string name, string logoBG, string logoImage, int number)
    {
        Name = name;
        LogoBG = Resources.Load<Sprite>(logoBG);
        LogoImage = Resources.Load<Sprite>(logoImage);
        Number = number;
    }
}
public static class GameCardManager
    {
        //public static List<CardInfoOperator> AllCardsOperator = new List<CardInfoOperator>();
        public static List<CardInfoNumber> AllCardsNumber = new List<CardInfoNumber>();
      
    }

public class GameCardManagerScript : MonoBehaviour
{
    public void Awake()
    {
        //GameCardManager.AllCardsOperator.Add(new CardInfoOperator("OPERATOR", "Sprites/Cards/CardOperatorBG", "Sprites/Cards/CardOperatorImage", '-'));
       // GameCardManager.AllCardsOperator.Add(new CardInfoOperator("OPERATOR", "Sprites/Cards/CardOperatorBG", "Sprites/Cards/CardOperatorImage", '+'));
        GameCardManager.AllCardsNumber.Add(new CardInfoNumber("NUMBER", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", -1));
        GameCardManager.AllCardsNumber.Add(new CardInfoNumber("NUMBER", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", -1));
        GameCardManager.AllCardsNumber.Add(new CardInfoNumber("NUMBER", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", 1));
        GameCardManager.AllCardsNumber.Add(new CardInfoNumber("NUMBER", "Sprites/Cards/CardNumberBG", "Sprites/Cards/CardNumberImage", -2));

    }
}
