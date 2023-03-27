using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    List<Card> GiveDeskCard()// метод утворення колоди ігрових карт
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < CardManager.AllCards.Count; i++)
            list.Add(CardManager.AllCards[randomChanceArray.RandomChance(CardManager.AllCards.Count)]);
        //Debug.Log("listPlayer.Count " + CardManager.AllCards.Count);
        return list;
    }
    List<Card> GiveDeskNewCard()//метод утворення колоди карт на вибір для нового рівня
    {
        List<Card> listNewCard = new List<Card>();
        for (int i = 0; i < CardManager.NewCard.Count; i++)
            listNewCard.Add(CardManager.NewCard[randomChanceArray.RandomNewCard(CardManager.NewCard.Count)]);
        //Debug.Log("listNewCard.Count " + CardManager.NewCard.Count);
        return listNewCard;
    }
}

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject cardPref;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private ShieldCountScript shieldCountPlayerScript;
    [SerializeField] private ShieldCountScript shieldCountEnemyScript;
    [SerializeField] private CountRoundScript countRoundScript;
    [SerializeField] private CardToCalculate cardToCalculate;
    [SerializeField] private EnemyScript enemy;
    [SerializeField] private GameMusicController gameMusicController;
    [SerializeField] private TextMeshProUGUI countCardPlayerText;//залишок карт в колоді(-6 розданих)
    [SerializeField] private TextMeshProUGUI countCardNotGameText;//відбій карт
    private Game currentGame;
    private GameObject cardGo;
    public Transform PlayerHand;
    private int countCardPlayer = 0;
    public int countCardNotGame = 0;

    public List<CardInfoScript> PlayerHandCards = new List<CardInfoScript>();

    void Start()
    {
        GlobalControl.Instance.SaveScene();

        currentGame = new Game();
        //Debug.Log("currentGameStart " + currentGame.PlayerDesk.Count);

        GiveHandCards(currentGame.PlayerDesk, PlayerHand);

        countCardPlayer = currentGame.PlayerDesk.Count;
        countCardPlayerText.text = countCardPlayer.ToString();
        countCardNotGameText.text = countCardNotGame.ToString();
    }
    public void GiveHandCards(List<Card> desk, Transform hand)
    {
        gameMusicController.CardFromDescMusic();
        //AudioManagerMixer.instance.MusicCardFromDesk();
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
        countCardNotGameText.text = countCardNotGame.ToString();
        //Debug.Log("countNot; " + countCardNotGame);
    }

    public void EndTurn()//перевірити чи є карти/очистити і роздати нові
    {
        countRoundScript.CountRound();
        cardToCalculate.CleanerCalculate();

        ClearHandCards();
        shieldCountEnemyScript.ShieldCountStart();
        enemy.Invoke("StartAttackOrDefenseEnemy", 0.5f);

        shieldCountPlayerScript.Invoke("ShieldCountStart", 1f);

        Invoke(nameof(Start), 1.5f);

        gameUI.Invoke("RoundGameActive", 1.7f);

        //Debug.Log("EndTurn/ PlayerHand.childCount " + PlayerHand.childCount);
        //Debug.Log("EndTurn/ PlayerHandCards.Count " + PlayerHandCards.Count);
    }

    public void ClearHandCards()
    {
        foreach (Transform child in PlayerHand)
        {
            Destroy(child.gameObject);
            PlayerHandCards.RemoveAt(0);
            countCardNotGame = 0;
            countCardNotGameText.text = countCardNotGame.ToString();
        }
    }

}
