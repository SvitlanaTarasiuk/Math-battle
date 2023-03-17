using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game
{
    public List<Card> PlayerDesk;//������� ������ ����
    public List<Card> NewCardDesk;//������ ���� ��� ������ � ���� ����
    RandomChanceArrayScript randomChanceArray = new RandomChanceArrayScript();
    public Game()
    {
        PlayerDesk = GiveDeskCard();
        NewCardDesk = GiveDeskNewCard();
    }
    List<Card> GiveDeskCard()// ����� ��������� ������ ����
    {
        List<Card> list = new List<Card>();
        for (int i = 0; i < CardManager.AllCards.Count; i++)
                                                            // list.Add(CardManager.AllCards[RandomCard(CardManager.AllCards.Count)]);// ���� �������� %
            list.Add(CardManager.AllCards[randomChanceArray.RandomChance(CardManager.AllCards.Count)]);
        Debug.Log("listPlayer.Count " + CardManager.AllCards.Count);
        return list;
    }
    List<Card> GiveDeskNewCard()// ����� ��������� ������ ����
    {
        List<Card> listNewCard = new List<Card>();
        for (int i = 0; i < CardManager.NewCard.Count; i++)//������� ������
                                                           //listNewCard.Add(CardManager.NewCard[Random.Range(0, CardManager.NewCard.Count)]);//��������� ������
            listNewCard.Add(CardManager.NewCard[randomChanceArray.RandomNewCard(CardManager.NewCard.Count)]);
        Debug.Log("listNewCard.Count " + CardManager.NewCard.Count);
        return listNewCard;
    }   
}

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameUI gameUI;
    GameObject cardGo;
    public Game currentGame;
    public GameObject cardPref;
    public EnemyScript enemy;
    public PlayerScript player;
    public Transform PlayerHand;
    public TextMeshProUGUI countCardPlayerText;//������� ���� � �����(-6 ��������)
    public TextMeshProUGUI countCardNotGameText;//���� ����
    public GameMusicController gameMusicController;
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
        gameMusicController.CardFromDescMusic();

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

    public void EndTurn()//��������� �� � �����/�������� � ������� ��� ��� ������ �����
    {
        countRound++;
        GetComponent<InfoCountGameScript>().CountRoundText(countRound);
        GetComponent<CardToCalculate>().CleanerCalculate();
        ClearHandCards();

        enemy.ShieldCountStart();
        enemy.StartAttackOrDefenseEnemy();
       
        player.ShieldCountStart();

        Invoke("Start", 1f);
        gameUI.Invoke("RoundGameActive",1.5f);
                     
        Debug.Log("PlayerHand.childCount1 " + PlayerHand.childCount);
        Debug.Log("PlayerHandCards.Count " + PlayerHandCards.Count);                  
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
    
    public void GiveNewCardsNewScene()//������ �� ����� � ���� ����
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

}
