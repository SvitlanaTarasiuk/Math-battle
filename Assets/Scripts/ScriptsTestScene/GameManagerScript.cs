using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game
{
    public List<Card> EnemyDesk, PlayerDesk, EnemyHand, PlayerHand, EnemyField, PlayerField;

    public Game()
    {
        EnemyDesk = GiveDeskCard();
        PlayerDesk = GiveDeskCard();

        EnemyHand = new List<Card>();
        PlayerHand = new List<Card>();

        EnemyField = new List<Card>();
        PlayerField = new List<Card>();
    }
    List<Card>GiveDeskCard()
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < 10; i++)
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
    int turn = 30;
    int turnTime = 30;
    public TextMeshProUGUI turnTimeText;
    public Button EndTurnBtn;

    public bool IsPlayerTurn
    {
        get
        {
            return turn %2 == 0;
        }
    }
    void Start()
    {
        turn = 0;

        currentGame = new Game();

        GiveHandCards(currentGame.EnemyDesk,EnemyHand);
        GiveHandCards(currentGame.PlayerDesk,PlayerHand);

        StartCoroutine(TurnFunc()); 
    }

    void GiveHandCards(List<Card> desk, Transform hand)
    {
        int i = 0;
        while (i++ < 4)
            GiveCardToHand(desk, hand);
    }
    void GiveCardToHand(List<Card> desk, Transform hand)
    {
        if (desk.Count == 0)
            return;

        Card card = desk[0];

        GameObject cardGo = Instantiate(cardPref, hand, false);

        if (hand == EnemyHand)
            cardGo.GetComponent<CardInfoScript>().HideCardInfo(card);
        else
            cardGo.GetComponent<CardInfoScript>().ShowCardInfo(card);
       
        desk.RemoveAt(0);
    }

    IEnumerator TurnFunc()
    {
        turnTime = 30;
        turnTimeText.text = turnTime.ToString();

        if(IsPlayerTurn)
        {
            while (turnTime-- > 0)
            {
                turnTimeText.text = turnTime.ToString();
                yield return new WaitForSeconds(1);
            }
        }
        else
        {
            while (turnTime-- > 27)
            {
                turnTimeText.text = turnTime.ToString();
                yield return new WaitForSeconds(1);
            }
        }
        ChangeTurn();
    }
    public void ChangeTurn()
    {
        StopAllCoroutines();

        turn++;
        EndTurnBtn.interactable = IsPlayerTurn;

        if(IsPlayerTurn)       
            GiveNewCards();

        StartCoroutine(TurnFunc());
    }
    void GiveNewCards()
    {
        GiveCardToHand(currentGame.EnemyDesk, EnemyHand);
        GiveCardToHand(currentGame.PlayerDesk,PlayerHand);
    }
}
