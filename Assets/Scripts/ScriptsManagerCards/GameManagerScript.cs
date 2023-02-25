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

public class GameManagerScript : MonoBehaviour//, IPointerClickHandler

{
    public Game currentGame;
    public Card selfCard;
    public GameObject cardPref;   
    public Button EndTurnBtn;
    public Transform EnemyHand;
    public Transform PlayerHand;    
    public TextMeshProUGUI countCardPlayerText;//залишок карт в колоді
    public TextMeshProUGUI countCardNotGameText;//відбій карт
    //public TextMeshProUGUI numberCard1CalculeteText;
    //public TextMeshProUGUI numberCard2CalculeteText;
    //public TextMeshProUGUI operatorCard3CalculeteText;   
    int countCardPlayer = 6;
    public int countCardNotGame = 0;

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

        //GiveHandCards(currentGame.EnemyDesk, EnemyHand);
        //GiveHandCards(currentGame.PlayerDesk, PlayerHand);
        StartGame();
        countCardPlayerText.text = countCardPlayer.ToString();
        countCardNotGameText.text = countCardNotGame.ToString();    
        //StartCoroutine(TurnFunc());
    }

    public void StartGame()
    {

        GiveHandCards(currentGame.EnemyDesk, EnemyHand);
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
    public void GiveNewCards()//додає по одній карті
    {
        GiveCardToHand(currentGame.EnemyDesk, EnemyHand);
        GiveCardToHand(currentGame.PlayerDesk, PlayerHand);
    }

    public void ClearHandCards()////
    {
        if (currentGame.PlayerDesk.Count > 0)
        {
             PlayerHandCards.Remove( GetComponent<CardInfoScript>());
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

    
    //public int CalculateCard()
    //{      
    //    int summa=0;
    //    int card1 = int.Parse(numberCard1CalculeteText.text);
    //    int card2 = int.Parse(numberCard2CalculeteText.text);
    //    char sign = Convert.ToChar(operatorCard3CalculeteText.text);
     
    //    if (sign == '+')
    //    {
    //        summa = card1 + card2;
    //        Debug.Log($"{card1},+, {card2},=, {summa}");
    //    }
    //    else if (sign == '-')
    //    {
    //        summa = card1 + card2;
    //        Debug.Log($"{card1},+, {card2},=, {summa}");
    //    }
    //    return summa;        
         
    //}
  

        //public void SelectedCardToCalculete(CardInfoScript numberCard1, CardInfoScript numberCard2, CardInfoScript operatorCard)
    //public void SelectedCardToCalculete()
    //{
    //    numberCard1CalculeteText.text = GetComponent<OnClickCard>().cardClick.GetComponent<Card>().Number.ToString();
    //    Debug.Log(numberCard1CalculeteText.text);

    //    //CardInfoScript Card1=;

    //    //numberCard1CalculeteText.text = selfCard.Number.ToString();
    //    //numberCard2Text.text = numberCard2.numberCard.text;
    //    //operatorCard3Text.text = operatorCard.numberCard.text;
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
