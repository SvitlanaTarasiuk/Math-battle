using System.Collections.Generic;
using UnityEngine;

public class NewCardScript : MonoBehaviour
{
    [SerializeField] private GiveHandCardsScript giveHandCardsScript;
    private Game newSceneGame;
    private int countCardsHand = 2;
    private List<CardInfoScript> newSceneCards = new List<CardInfoScript>();
    public Transform newCardHand;

    void Start()
    {
        if (newSceneGame == null)
        {
            newSceneGame = new Game();
        }
    }
    
    public void NewCardPanelStart()
    {
        giveHandCardsScript.GiveHandCards(newSceneGame.NewCardDesk, newCardHand, countCardsHand, newSceneCards);
    }
}
