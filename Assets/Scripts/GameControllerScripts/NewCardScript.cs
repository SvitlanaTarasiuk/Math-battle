using System.Collections.Generic;
using UnityEngine;

public class NewCardScript : MonoBehaviour
{
    private GameObject cardGo;
    private Game newSceneGame;
    public GameObject cardPref;
    public Transform newCardHand;

    public List<CardInfoScript> NewSceneCards = new List<CardInfoScript>();

    void Start()
    {
        if (newSceneGame == null)
        {
            newSceneGame = new Game();
        }
    }
    public void NewCardPanelStart()
    {
        GiveHandCards(newSceneGame.NewCardDesk, newCardHand);
    }
    void GiveHandCards(List<Card> desk, Transform hand)
    {
        int i = 0;
        while (i++ < 2)
            GiveCardToHand(desk, hand);
    }
    void GiveCardToHand(List<Card> desk, Transform hand)
    {
        if (desk.Count == 0)
            return;

        Card card = desk[0];

        cardGo = Instantiate(cardPref, hand, false);

        cardGo.GetComponent<CardInfoScript>().ShowCardInfo(card);
        NewSceneCards.Add(cardGo.GetComponent<CardInfoScript>());

        desk.RemoveAt(0);
        //Debug.Log("NewDesk.Count " + desk.Count);
    }

}
