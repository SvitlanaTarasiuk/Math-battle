using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;
using Random = UnityEngine.Random;
using static Card;
using UnityEngine.XR;
using UnityEngine.EventSystems;
//using Random = System.Random;

public class Game
{
    public List<Card> PlayerDesk;

    public Game()
    {
        PlayerDesk = GiveDeskCard();
    }
    List<Card> GiveDeskCard()
    {
        List<Card> list = new List<Card>();

        for (int i = 0; i < 24; i++)
            list.Add(CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)]);
        return list;
    }
}

public class GameManagerScript : MonoBehaviour
{
    public Game currentGame;
    public Card selfCard;
    public GameObject cardPref;
    public Button EndTurnBtn;
    public Transform PlayerHand;
    public TextMeshProUGUI countCardPlayerText;//залишок карт в колоді
    public TextMeshProUGUI countCardNotGameText;//відбій карт

    int countCardPlayer = 6;
    public int countCardNotGame = 0;

    public List<CardInfoScript> PlayerHandCards = new List<CardInfoScript>();

    void Start()
    {
        currentGame = new Game();

        StartGame();
        countCardPlayerText.text = countCardPlayer.ToString();
        countCardNotGameText.text = countCardNotGame.ToString();
    }

    public void StartGame()
    {
        GiveHandCards(currentGame.PlayerDesk, PlayerHand);
    }
    public void GiveHandCards(List<Card> desk, Transform hand)
    {
        int i = 0;
        while (i++ < 6)
            GiveCardToHand(desk, hand);
        //countCardPlayerText.text = PlayerHandCards.Count.ToString();
    }
    void GiveCardToHand(List<Card> desk, Transform hand)
    {
        if (desk.Count == 0)
            return;

        Card card = desk[0];

        GameObject cardGo = Instantiate(cardPref, hand, false);

        cardGo.GetComponent<CardInfoScript>().ShowCardInfo(card);
        PlayerHandCards.Add(cardGo.GetComponent<CardInfoScript>());
        countCardPlayer--;

        desk.RemoveAt(0);
    }
    public void GiveNewCards()//додає по дві карти
    {
        int i = 0;
        while (i++ < 2)
            GiveCardToHand(currentGame.PlayerDesk, PlayerHand);
    }

    public void ClearHandCards()////
    {
        if (currentGame.PlayerDesk.Count > 0)
        {
            PlayerHandCards.Remove(GetComponent<CardInfoScript>());
        }

        //currentGame.PlayerDesk.RemoveRange(0, currentGame.PlayerDesk.Count);

        //PlayerHandCards.Remove(card);

        //if (!card.selfCard.IsAlive)
        //if (PlayerFieldCards.Exists(x => x == card))
        //PlayerFieldCards.Remove(card);
        //Destroy(card.gameObject);

        //int count = card.Count == 1 ? 1 : Random.Range(0, cards.Count);
        //    for (int i = 0; i < count; i++)
        //    {
        //        if (EnemyFieldCards.Count > 5)
        //            return;
        //        cards[0].ShowCardInfo(cards[0].selfCard, false);
        //        cards[0].transform.SetParent(EnemyField);
        //        EnemyFieldCards.Add(cards[0]);
        //        EnemyHandCards.Remove(cards[0]);
        //    }

        //List<CardInfoScript> card  //CardInfoScript card

        //GiveHandCards(currentGame.PlayerDesk, PlayerHand);
    }


    //IEnumerator TurnFunc()
    //{
    //    turnTime = 20;
    //    turnTimeText.text = turnTime.ToString();

    //    foreach (var card in PlayerFieldCards)
    //        //card.DeHighlightCard();

    //    if (IsPlayerTurn)
    //    {
    //        ////foreach (var card in PlayerFieldCards)
    //        ////{
    //        ////    card.selfCard.ChangeAttackState(true);
    //        ////    //card.HighlightCard();
    //        ////}

    //        while (turnTime-- > 0)
    //        {
    //            turnTimeText.text = turnTime.ToString();
    //            yield return new WaitForSeconds(1);
    //        }
    //    }
    //    else
    //    {
    //        //////foreach (var card in EnemyFieldCards)
    //        //////{
    //        //////    card.selfCard.ChangeAttackState(true);

    //        //////}
    //        while (turnTime-- > 17)
    //        {
    //            turnTimeText.text = turnTime.ToString();
    //            yield return new WaitForSeconds(1);
    //        }
    //        if (EnemyHandCards.Count > 0)
    //            EnemyTurn(EnemyHandCards);
    //    }
    //    ChangeTurn();
    //}

    //void EnemyTurn(List<CardInfoScript> cards)
    //{
    //    int count = cards.Count == 1 ? 1 : Random.Range(0, cards.Count);

    //    for (int i = 0; i < count; i++)
    //    {
    //        if (EnemyFieldCards.Count > 5)
    //            return;

    //        cards[0].ShowCardInfo(cards[0].selfCard, false);
    //        cards[0].transform.SetParent(EnemyField);

    //        EnemyFieldCards.Add(cards[0]);
    //        EnemyHandCards.Remove(cards[0]);
    //    }
    //foreach (var activeCard in EnemyFieldCards.FindAll(x => x.selfCard.canAttack))
    //{
    //    if (PlayerFieldCards.Count == 0)
    //        return;
    //    var enemy = PlayerFieldCards[Random.Range(0, PlayerFieldCards.Count)];

    //    //Debug.Log(activeCard.selfCard.Name + "(" + activeCard.selfCard.Attack + ";" + activeCard.selfCard.Defense + "--->" +
    //    //    enemy.selfCard.Name + "(" + enemy.selfCard.Attack + ";" + enemy.selfCard.Defense);

    //    //activeCard.selfCard.ChangeAttackState(false);
    //   // CardsFight(enemy, activeCard);
    //}
    //}
    //public void ChangeTurn()
    //{
    //    StopAllCoroutines();

    //    turn++;
    //    EndTurnBtn.interactable = IsPlayerTurn;

    //    if (IsPlayerTurn)
    //        GiveNewCards();

    //    StartCoroutine(TurnFunc());
    //}


    //public void CardsFight(CardInfoScript playerCard, CardInfoScript enemyCard)
    //{


    //    playerCard.selfCard.GetDamage(enemyCard.selfCard.Attack);
    //    enemyCard.selfCard.GetDamage(playerCard.selfCard.Attack);

    //    if (!playerCard.selfCard.IsAlive)
    //        DestroyCard(playerCard);
    //    else
    //        playerCard.RefreshData();

    //    if (!enemyCard.selfCard.IsAlive)
    //        DestroyCard(enemyCard);
    //    else
    //        enemyCard.RefreshData();
    //}


    //void DestroyCard(CardInfoScript card)
    //{
    //    card.GetComponent<CardMovementScript>().OnEndDrag(null);
    //    if (EnemyFieldCards.Exists(x => x == card))
    //        EnemyFieldCards.Remove(card);

    //    if (PlayerFieldCards.Exists(x => x == card))
    //        PlayerFieldCards.Remove(card);

    //    Destroy(card.gameObject);
    //}

}
