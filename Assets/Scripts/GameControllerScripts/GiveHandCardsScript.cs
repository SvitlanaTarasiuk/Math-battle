using System.Collections.Generic;
using UnityEngine;

public class GiveHandCardsScript : MonoBehaviour
{
    [SerializeField] private GameObject cardPref;
    private GameObject cardGo;

    public void GiveHandCards(List<Card> desk, Transform hand, int countCardsHand, List<CardInfoScript> handWithCards)
    {
        int i = 0;
        while (i++ < countCardsHand)
            GiveCardToHand(desk, hand, handWithCards);
    }
    
    private void GiveCardToHand(List<Card> desk, Transform hand, List<CardInfoScript> handWithCards)
    {
        if (desk.Count == 0)
            return;

        Card card = desk[0];

        cardGo = Instantiate(cardPref, hand, false);

        var cardInfo = cardGo.GetComponent<CardInfoScript>();

        cardInfo.ShowCardInfo(card);

        handWithCards.Add(cardInfo);

        desk.RemoveAt(0);
    }
}
