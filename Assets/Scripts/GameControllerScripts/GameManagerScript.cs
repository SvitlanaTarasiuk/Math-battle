using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game
{
    private RandomChanceArrayScript randomChanceArray = new RandomChanceArrayScript();
    public List<Card> PlayerDesk;//the main deck of cards
    public List<Card> NewCardDesk;//a list of cards to choose from at the end of the level

    public Game()
    {
        PlayerDesk = GiveDeskCard();
        NewCardDesk = GiveDeskNewCard();
    }

    List<Card> GiveDeskCard()// method of forming a deck of playing cards
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < CardManager.AllCards.Count; i++)
            list.Add(CardManager.AllCards[randomChanceArray.RandomChance(CardManager.AllCards.Count)]);
        //Debug.Log("listPlayer.Count " + CardManager.AllCards.Count);
        return list;
    }

    List<Card> GiveDeskNewCard()//method of creating a deck of cards to choose from for a new level
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
    [SerializeField] private GiveHandCardsScript giveHandCardsScript;
    [SerializeField] private GameUI gameUI;
    [SerializeField] private ShieldCountScript shieldCountPlayerScript;
    [SerializeField] private ShieldCountScript shieldCountEnemyScript;
    [SerializeField] private CountRoundScript countRoundScript;
    [SerializeField] private CardToCalculate cardToCalculate;
    [SerializeField] private EnemyScript enemy;
    [SerializeField] private GameMusicController gameMusicController;
    [SerializeField] private TextMeshProUGUI countCardPlayerText;//remaining cards in the deck (-6 dealt)
    [SerializeField] private TextMeshProUGUI countCardNotGameText;//card rejection
    private Game currentGame;
    private int countCardsHand = 6;
    private int countCardPlayer = 0;
    public Transform PlayerHand;
    public int countCardNotGame = 0;
    public List<CardInfoScript> playerHandCards = new List<CardInfoScript>();

    void Start()
    {
        GlobalControl.Instance.SaveScene();

        currentGame = new Game();
        //Debug.Log("currentGameStart " + currentGame.PlayerDesk.Count);

        GivePlayerHandCards();

        countCardPlayer = currentGame.PlayerDesk.Count;
        countCardPlayerText.text = countCardPlayer.ToString();
        countCardNotGameText.text = countCardNotGame.ToString();
    }
    private void GivePlayerHandCards()
    {
        gameMusicController.CardFromDescMusic();
        giveHandCardsScript.GiveHandCards(currentGame.PlayerDesk, PlayerHand, countCardsHand, playerHandCards);
        //Debug.Log("currentGame.PlayerDesk.Count " + currentGame.PlayerDesk.Count);
    }
   
    public void CountCardNotGame(int inactiveCards)
    {
        countCardNotGame += inactiveCards;
        countCardNotGameText.text = countCardNotGame.ToString();
    }

    public void EndTurn()//check if there are cards/clear them and give out new ones
    {
        countRoundScript.CountRound();
        cardToCalculate.CleanerCalculate();
        ClearHandCards();
        shieldCountEnemyScript.ShieldCountStart();

        enemy.StartAttackOrDefenseEnemyInvoke();
        shieldCountPlayerScript.ShieldCountStartInvoke();
        Invoke(nameof(Start), 1.5f);
        gameUI.RoundGameActiveInvoke();

        //Debug.Log("EndTurn/ PlayerHand.childCount " + PlayerHand.childCount);
        //Debug.Log("EndTurn/ PlayerHandCards.Count " + playerHandCards.Count);
    }

    public void ClearHandCards()
    {
        foreach (Transform child in PlayerHand)
        {
            Destroy(child.gameObject);
            playerHandCards.RemoveAt(0);
            countCardNotGame = 0;
            countCardNotGameText.text = countCardNotGame.ToString();
        }
    }

}
