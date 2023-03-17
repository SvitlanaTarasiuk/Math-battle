using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardToCalculate : MonoBehaviour
{
    private GameManagerScript gameManager;
    public GameObject card1Calculate;
    public GameObject card2Calculate;
    public GameObject card3Calculate;
    public TextMeshProUGUI numberCard1CalculateText;
    public TextMeshProUGUI numberCard2CalculateText;
    public TextMeshProUGUI operatorCard3CalculateText;
    public Button calculateBtn;
    public Button resetBtn;
    public PlayerScript player;
    public EnemyScript enemy;
    public OnClickCard clickCard;   
    public Image shieldImage;
    public Image swordImage;
    public TempCardGoScript tempCardGoScript;
    public GameMusicController gameMusicController;
    int countCardCalculate = 0;
    private int card1;
    private int card2;
    private char card3;
    private int summaCard = 0;
    

    private void Start()
    {
        gameManager = GetComponent<GameManagerScript>();
        CardCalculateText();
        NotActiveImageResultCalculate();
        StartCoroutine(ActiveButonCoroutine());
    }
    //private void Update()
    //{
    //    //ButtonCalculateActive();     // замінити на coroutine       
    //}
    IEnumerator ActiveButonCoroutine()
    {
        while (true)
        {
            ButtonCalculateActive();
            yield return new WaitForSeconds(1);
        }
    }
    private void CardCalculateText()
    {
        numberCard1CalculateText.text = "N";
        numberCard2CalculateText.text = "N";
        operatorCard3CalculateText.text = "O";        
    }
    private void NotActiveImageResultCalculate()
    {
        shieldImage.color = new Color(shieldImage.color.r, shieldImage.color.g, shieldImage.color.b, 0.5f);
        swordImage.color = new Color(swordImage.color.r, swordImage.color.g, swordImage.color.b, 0.5f);
    }
    private void ButtonCalculateActive()
    {
        if (countCardCalculate == 3)
        {
            calculateBtn.interactable = true;
            summaCard = CalculateCard(card1, card2, card3);
            ActiveImageResultCalculate();
            Debug.Log("button true");
        }
        else
            calculateBtn.interactable = false;
        Debug.Log("button false");
    }
    public void ActiveImageResultCalculate()
    {
        if (summaCard == 0)
        {
            NotActiveImageResultCalculate();
        }
        else if (summaCard > 0)//>0 меч активний
        {
            swordImage.color = new Color(swordImage.color.r, swordImage.color.g, swordImage.color.b, 1f);
        }
        else if (summaCard < 0)//<0 щит активний
        {
            shieldImage.color = new Color(shieldImage.color.r, shieldImage.color.g, shieldImage.color.b, 1f);
        }
    }
    public void Card1Text(string number1)

    {   gameMusicController.OneCardMusic();
        tempCardGoScript.CardGoMove();
        numberCard1CalculateText.text = number1;
        Debug.Log($"CardText:{numberCard1CalculateText.text}");
        countCardCalculate++;
        card1 = int.Parse(numberCard1CalculateText.text);
        Debug.Log("countCardCalculate: "+countCardCalculate);
    }
    public void Card2Text(string number2)
    {
        gameMusicController.OneCardMusic();
        numberCard2CalculateText.text = number2;
        Debug.Log($"CardText:{numberCard2CalculateText.text}");
        countCardCalculate++;
        card2 = int.Parse(numberCard2CalculateText.text);

        Debug.Log("countCardCalculate: "+countCardCalculate);
    }
    public void Card3Text(string operator3)
    {
        gameMusicController.OneCardMusic();
        operatorCard3CalculateText.text = operator3;
        Debug.Log($"CardText:{operatorCard3CalculateText.text}");
        countCardCalculate++;
        card3 = Convert.ToChar(operatorCard3CalculateText.text);
        Debug.Log("countCardCalculate: "+countCardCalculate);
    }
    private int CalculateCard(int card1, int card2, char sign)
    {
        int summa;
        if (sign == '+')
        {
            summa = card1 + card2;
            Debug.Log($"{card1},+, {card2},=, {summa}");
                       
            return summa;
        }
        else if (sign == '-')
        {
            summa = card1 - card2;
            Debug.Log($"{card1},, {card2},=, {summa}");
            
            return summa;
        }
        return 0;
    }
    public void CleanerCalculate()
    {
            CardCalculateText();
            NotActiveImageResultCalculate();
            countCardCalculate = 0;
            summaCard=0;
            Debug.Log(summaCard);
    }
    public void BattleResultCalculate()
    {
        if (summaCard == 0)//скидаються карти
        {
            CleanerCalculate();            
            gameManager.CountCardNotGame(3);

        }
        else if (summaCard > 0)//>0 удар ворогу
        {
            gameMusicController.DamageEffectMusic();
            enemy.Damage(Mathf.Abs(summaCard));           
            CleanerCalculate();            
            gameManager.CountCardNotGame(3);

            //DestroyCard();//знищити карти
        }
        else if (summaCard < 0)//<0 отримано захист
        {
            gameMusicController.ShieldEffectMusic();
            player.ShieldCount(Mathf.Abs(summaCard));
            CleanerCalculate();
            gameManager.CountCardNotGame(3);

            //DestroyCard();//знищити карти
        }
    }
    public void ResetCard()//повернути кари з калькулятора на поле
    {
        if (countCardCalculate > 0)
        {
            gameMusicController.Invoke("CardToDeskMusic", 0.2f);
            card1Calculate.SetActive(true);
            card2Calculate.SetActive(true);
            card3Calculate.SetActive(true);
            CleanerCalculate();
            Debug.Log("ResetCard");
        }
    }  
    public void DestroyCard()//знищити карти,що пройшли калькулятор
    {
        Destroy(card1Calculate);
        Destroy(card2Calculate);
        Destroy(card3Calculate);
    }

}
