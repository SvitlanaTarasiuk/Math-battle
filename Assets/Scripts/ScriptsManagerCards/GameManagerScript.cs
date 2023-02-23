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
//using Random = System.Random;

public class Game
{
    public List<Card> EnemyDesk, PlayerDesk;

    public Game()
    {
        EnemyDesk = GiveDeskCard();
        PlayerDesk = GiveDeskCard();
    }
    List<Card>GiveDeskCard()
    {
        List<Card> list = new List<Card>();

        for (int i = 0; i < 18; i++)
            list.Add(CardManager.AllCards[Random.Range(0,CardManager.AllCards.Count)]);
        return list;
    }
}

public class GameManagerScript : MonoBehaviour
{
    public Game currentGame;
    public Transform EnemyHand;
    public Transform PlayerHand;
    public GameObject cardPref;   
    public Button EndTurnBtn;
    public TextMeshProUGUI countCardPlayerText;
    public TextMeshProUGUI numberCard1Text;
    public TextMeshProUGUI numberCard2Text;
    public TextMeshProUGUI operatorCard3Text;
    public Card selfCard;
    int countCardPlayer = 6;
   
    //int turn = 30;
    //int turnTime = 30;
    //public TextMeshProUGUI turnTimeText;

    public List<CardInfoScript> PlayerHandCards = new List<CardInfoScript>(),
                                EnemyHandCards = new List<CardInfoScript>();

    //public bool IsPlayerTurn
    //{
    //    get
    //    {
    //        return turn % 2 == 0;
    //    }
    //}
    void Start()
    {
        //turn = 0;

        currentGame = new Game();
        
        GiveHandCards(currentGame.EnemyDesk, EnemyHand);
        GiveHandCards(currentGame.PlayerDesk, PlayerHand);

        countCardPlayerText.text = countCardPlayer.ToString();

        //StartCoroutine(TurnFunc());
    }


    public void GiveHandCards(List<Card> desk, Transform hand)
    {

        int i = 0;
        while (i++ < 6)            
            GiveCardToHand(desk, hand);
        //countCardPlayerText.text = PlayerHandCards.Count.ToString();
        
    }  
    
    public void GiveNewCards()
    {
        GiveCardToHand(currentGame.EnemyDesk, EnemyHand);
        GiveCardToHand(currentGame.PlayerDesk, PlayerHand);
    }
    public void ClearHandCards()////
    {
         //CardInfoScript card;
        if (currentGame.PlayerDesk.Count > 0)
        {
            
            PlayerHandCards.Remove(GetComponent<CardInfoScript>());
            //currentGame.PlayerDesk.RemoveRange(0, currentGame.PlayerDesk.Count);
            //PlayerHandCards.Remove(card);
            //Destroy(card.gameObject);
        }      
        //GiveHandCards(currentGame.PlayerDesk, PlayerHand);
    }

    void GiveCardToHand(List<Card> desk, Transform hand)
    {

        if (desk.Count == 0)
            return;

        Card card = desk[0];

        GameObject cardGo = Instantiate(cardPref, hand, false);

        if (hand == EnemyHand)
        {
            //cardGo.GetComponent<CardInfoScript>().HideCardInfo(card);
            cardGo.GetComponent<CardInfoScript>().ShowCardInfo(card, true);
            EnemyHandCards.Add(cardGo.GetComponent<CardInfoScript>());
        }
        else
        {
            cardGo.GetComponent<CardInfoScript>().ShowCardInfo(card,true);
            PlayerHandCards.Add(cardGo.GetComponent<CardInfoScript>());
           //cardGo.GetComponent<AttackedCard>().enabled = false;
            countCardPlayer--;
        }
        desk.RemoveAt(0);
    }

    //public int CalculateCard(CardInfoScript numberCard1, CardInfoScript numberCard2, CardInfoScript operatorCard)
   
    //public void SelectedCardToCalculete(CardInfoScript numberCard1, CardInfoScript numberCard2, CardInfoScript operatorCard)
    public void SelectedCardToCalculete()
    {
        //CardInfoScript Card1=;
        
        numberCard1Text.text = selfCard.Number.ToString();
        //numberCard2Text.text = numberCard2.numberCard.text;
        //operatorCard3Text.text = operatorCard.numberCard.text;
    }
    public int CalculateCard()
    {      
        int summa=0;
        int card1 = int.Parse(numberCard1Text.text);
        int card2 = int.Parse(numberCard2Text.text);
        char sign = Convert.ToChar(operatorCard3Text.text);
     
        if (sign == '+')
        {
            summa = card1 + card2;
            Debug.Log($"{card1},+, {card2},=, {summa}");
        }
        else if (sign == '-')
        {
            summa = card1 + card2;
            Debug.Log($"{card1},+, {card2},=, {summa}");
        }
        return summa;        
         
    }
    //public void SetCountCard()
    //{
    //    countCardPlayerText.text = countCardPlayer.ToString();
    //}


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
