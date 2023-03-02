using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using static Card;
using UnityEditor.SceneManagement;
//using Random = System.Random;

public class Game
{
    public List<Card> PlayerDesk;//головна колода карт
    //public List<Card> NewSceneDesk;//список карт для вибору в кінці рівня

    public Game()
    {
        PlayerDesk = GiveDeskCard();
        //NewSceneDesk = GiveDeskCard();
    }
    List<Card> GiveDeskCard()// метод утворення колоди карт
    {   
        RandomCardScript randomCardScript=new RandomCardScript();
        List<Card> list = new List<Card>();
       
        for (int i = 0; i < CardManager.AllCards.Count; i++)
        Debug.Log("list.Count "+ CardManager.AllCards.Count);
        //list.Add(CardManager.AllCards[RandomCard()]);
        list.Add(CardManager.AllCards[randomCardScript.RandomCard(CardManager.AllCards.Count)]);

        //for (int i = 0; i < 20; i++)
        //list.Add(CardManager.AllCards[Random.Range(0, CardManager.AllCards.Count)]);//звичайний рандом
        return list;
    }
    public int RandomCard()//передавати довжину колоди і вибирати відповідний масив//винести в окремий скрипт
    { 

        float[] chanceArray = new float[6]
        {0.25f,0.1f,0.1f,0.20f,0.15f,0.15f};
        int result = (int)Chance(chanceArray);

        float Chance(float[]percent)
        {
            float total = 0;
            foreach (float elem in percent)
            {
                total += elem;
            }
            float randomPoint = Random.value * total;
            for (int i = 0; i < percent.Length; i++)
            {
                if (randomPoint < percent[i])
                {
                    return i;  
                }
                else
                {
                    randomPoint -= percent[i];
                }
            }
            return percent.Length - 1;
        }
        return result;
    }
}

public class GameManagerScript : MonoBehaviour
{
    public Game currentGame;
    public Card selfCard;
    public GameObject cardPref;
    public EnemyScript enemy;
    public Transform PlayerHand;
    public TextMeshProUGUI countCardPlayerText;//залишок карт в колоді(-6 розданих)
    public TextMeshProUGUI countCardNotGameText;//відбій карт

    int countCardPlayer = 0;
    public int countCardNotGame = 0;

    public List<CardInfoScript> PlayerHandCards = new List<CardInfoScript>();

    void Start()
    {
        currentGame = new Game();
        Debug.Log("currentGameStart " + currentGame.PlayerDesk.Count);
        StartGame();
        countCardPlayer = currentGame.PlayerDesk.Count;      
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
        Debug.Log("currentGame.PlayerDesk.Count " + currentGame.PlayerDesk.Count);
        Debug.Log("Desk.Count " + desk.Count);

    }
    public void GiveNewCardsNewScene()//додати дві карти в кінці рівня
    {
        int i = 0;
        while (i++ < 2)
        {
            GiveCardToHand(currentGame.PlayerDesk, PlayerHand);
        }
        Debug.Log("PlayerHand.childCount "+ PlayerHand.childCount);
        Debug.Log("currentGame.PlayerDesk.Count "+ currentGame.PlayerDesk.Count);
        Debug.Log("PlayerHandCards.Count " + PlayerHandCards.Count);
        enemy.StartAttackOrDefenseEnemy();
    }
    public void CountCardNotGame(int inactiveCards)
    {
        countCardNotGame += inactiveCards;
        Debug.Log("countNot; " + countCardNotGame);
        countCardNotGameText.text=countCardNotGame.ToString();
    }

    public void EndTurn()
    {
        //перевірити чи є карти і роздати нові або додати карту
       // ClearHandCards();
        int i = 0;
        while (i++ < 2)
        {
            GiveCardToHand(currentGame.PlayerDesk, PlayerHand);
        }
        Debug.Log("PlayerHand.childCount " + PlayerHand.childCount);
        Debug.Log("currentGame.PlayerDesk.Count " + currentGame.PlayerDesk.Count);
        Debug.Log("PlayerHandCards.Count " + PlayerHandCards.Count);
        //countCardNotGame =0;
        //countCardNotGameText.text = countCardNotGame.ToString();
        enemy.StartAttackOrDefenseEnemy(); // ? coroutine
    }

    public void ClearHandCards()////?????
    {
        if(PlayerHand.childCount>0)
        {
            currentGame.PlayerDesk.RemoveRange(0, currentGame.PlayerDesk.Count);
        }
        //if (currentGame.PlayerDesk.Count > 0)
        //{
        //    currentGame.PlayerDesk.RemoveRange(0, currentGame.PlayerDesk.Count);
       
        //}
    
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
