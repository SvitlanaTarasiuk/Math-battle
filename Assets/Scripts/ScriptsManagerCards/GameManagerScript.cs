using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
using static Card;
using UnityEditor.SceneManagement;
using Unity.VisualScripting;
//using Random = System.Random;

public class Game
{
    public List<Card> PlayerDesk;//головна колода карт
    public List<Card> NewCardDesk;//список карт для вибору в кінці рівня
    RandomChanceArrayScript randomChanceArray = new RandomChanceArrayScript();
    public Game()
    {
        PlayerDesk = GiveDeskCard();
        NewCardDesk = GiveDeskNewCard();
    }
    List<Card> GiveDeskCard()// метод утворення колоди карт
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < CardManager.AllCards.Count; i++)
                                                            // list.Add(CardManager.AllCards[RandomCard(CardManager.AllCards.Count)]);// шанс випадіння %
            list.Add(CardManager.AllCards[randomChanceArray.RandomChance(CardManager.AllCards.Count)]);
        Debug.Log("listPlayer.Count " + CardManager.AllCards.Count);
        return list;
    }
    List<Card> GiveDeskNewCard()// метод утворення колоди карт
    {
        List<Card> listNewCard = new List<Card>();
        for (int i = 0; i < CardManager.NewCard.Count; i++)//довжинв колоди
                                                           //listNewCard.Add(CardManager.NewCard[Random.Range(0, CardManager.NewCard.Count)]);//звичайний рандом
            listNewCard.Add(CardManager.NewCard[randomChanceArray.RandomShuffleNewCard(CardManager.NewCard.Count)]);
        Debug.Log("listNewCard.Count " + CardManager.NewCard.Count);
        return listNewCard;
    }
    public void AddNewCard(Card card)
    {
        PlayerDesk.Add(card);
        
        //CardManager.AllCards.Add(card);
        //gameUI.NewScene();

    }
    //public int RandomCard(int count)//передавати довжину колоди і вибирати відповідний масив
    //{
    //RandomChanceArrayScript randomChanceArray = new RandomChanceArrayScript();
    //    int result = randomChanceArray.RandomChance(count);       
    //    return result;
    //}
}

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameUI gameUI;
    GameObject cardGo;
    public Game currentGame;
    //public Card selfCard;
    public GameObject cardPref;
    public EnemyScript enemy;
    public Transform PlayerHand;
    public TextMeshProUGUI countCardPlayerText;//залишок карт в колоді(-6 розданих)
    public TextMeshProUGUI countCardNotGameText;//відбій карт
    int countRound = 1;
    int countCardPlayer = 0;
    public int countCardNotGame = 0;

    public List<CardInfoScript> PlayerHandCards = new List<CardInfoScript>();

    void Start()
    {
        currentGame = new Game();
        Debug.Log("currentGameStart " + currentGame.PlayerDesk.Count);
        GiveHandCards(currentGame.PlayerDesk, PlayerHand);

        countCardPlayer = currentGame.PlayerDesk.Count;
        countCardPlayerText.text = countCardPlayer.ToString();
        countCardNotGameText.text = countCardNotGame.ToString();
    }
    public void GiveHandCards(List<Card> desk, Transform hand)
    {
        int i = 0;
        while (i++ < 6)
            GiveCardToHand(desk, hand);
    }
    void GiveCardToHand(List<Card> desk, Transform hand)
    {
        if (desk.Count == 0)
            return;

        Card card = desk[0];

        cardGo = Instantiate(cardPref, hand, false);

        cardGo.GetComponent<CardInfoScript>().ShowCardInfo(card);
        PlayerHandCards.Add(cardGo.GetComponent<CardInfoScript>());

        countCardPlayer--;

        desk.RemoveAt(0);
        //Debug.Log("currentGame.PlayerDesk.Count " + currentGame.PlayerDesk.Count);
        //Debug.Log("Desk.Count " + desk.Count);

    }

    public void CountCardNotGame(int inactiveCards)
    {
        countCardNotGame += inactiveCards;
        Debug.Log("countNot; " + countCardNotGame);
        countCardNotGameText.text = countCardNotGame.ToString();
        
    }

    public void EndTurn()//перевірити чи є карти/очистити і роздати нові або додати карту
    {
        countRound++;
        GetComponent<InfoCountGameScript>().CountRoundText(countRound);
        gameUI.RoundGameActive();
        GetComponent<CardToCalculate>().CleanerCalculate();
        ClearHandCards();
        Debug.Log("PlayerHand.childCount1 " + PlayerHand.childCount);
        Debug.Log("PlayerHandCards.Count " + PlayerHandCards.Count);

        Invoke("Start", 0.5f);

        enemy.Invoke("StartAttackOrDefenseEnemy", 1.5f); // ? coroutine
    }

    public void ClearHandCards()////?????
    {
        foreach (Transform child in PlayerHand)
        {
            Destroy(child.gameObject);
            PlayerHandCards.RemoveAt(0);
            countCardNotGame = 0;
            countCardNotGameText.text = countCardNotGame.ToString();
        }
    }
    
    public void GiveNewCardsNewScene()//додати дві карти в кінці рівня
    {
        int i = 0;
        while (i++ < 2)
        {
            GiveCardToHand(currentGame.PlayerDesk, PlayerHand);
        }
        Debug.Log("PlayerHand.childCount " + PlayerHand.childCount);
        Debug.Log("currentGame.PlayerDesk.Count " + currentGame.PlayerDesk.Count);
        Debug.Log("PlayerHandCards.Count " + PlayerHandCards.Count);
    }

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
