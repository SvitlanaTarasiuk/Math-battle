using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;
using JetBrains.Annotations;

public class OnClickCard : MonoBehaviour, IPointerClickHandler
{
    GameObject cardClick;
    GameObject card1;
    GameObject card2;
    GameObject card3;
    string number1;
    string number2;
    string operator3;
    string nameCard;
    GameObject gameController;
    CardToCalculate cardToCalculate;   
    GameManagerScript gameManagerScript;
    GameUI gameUI;
    //GameObject panelNewCard;
    //GameObject panelHandPlayer;
    Transform panelHandPlayer;
    Transform panelNewCard;
    void Start()
    {
        gameController= GameObject.Find("GameController");
        cardToCalculate = gameController.GetComponent<CardToCalculate>();
        gameManagerScript = gameController.GetComponent<GameManagerScript>();
        gameUI= gameController.GetComponent<GameUI>();
        panelHandPlayer = gameController.GetComponent<GameManagerScript>().PlayerHand;
        panelNewCard = gameController.GetComponent<NewCardScript>().NewCardHand;
        //Debug.Log("panelHandPlayer.activeInHierarchy: "+panelHandPlayer.name);
        //Debug.Log("panelNewCard.activeInHierarchy: "+panelNewCard.name);      
    }

    public void OnPointerClick(PointerEventData eventData)
    {        
        Debug.Log("OnClickTriger");        
        cardClick = eventData.pointerClick.GameObject();    
        nameCard = cardClick.GetComponent<CardInfoScript>().nameCard.text;
        Debug.Log("panelNewCard.transform.name: "+ cardClick.transform.parent.name);

        
         if (panelNewCard!=null && cardClick.transform.parent == panelNewCard)
        {
            Debug.Log("panelNewCard.transform");
            //gameManagerScript.GetComponent<GameManagerScript>().PlayerHandCards.Add(cardClick.GetComponent<CardInfoScript>());
            //Debug.Log("CountNewCard" + gameManagerScript.GetComponent<GameManagerScript>().PlayerHandCards.Count);

            //CardManager.AllCards.Add(new Card(cardClick.GetComponent<Card>().Name, cardClick.GetComponent<Card>().LogoBG.ToString(),
            //                                cardClick.GetComponent<Card>().LogoImage.ToString(), cardClick.GetComponent<Card>().Number));
            
            gameManagerScript.currentGame.PlayerDesk.Add(cardClick.GetComponent<Card>());
            Debug.Log("CardManager.AllCards.count: " + CardManager.AllCards.Count);
           
            //gameManagerScript.GetComponent<GameManagerScript>().currentGame.PlayerDesk.Add(cardClick.GetComponent<Card>());
            Debug.Log("currentGame.PlayerDesk.Count: " + gameManagerScript.currentGame.PlayerDesk.Count);
           
            //game.PlayerDesk.Add(cardClick.GetComponent<Card>());

            //CardManager.NewCard.Add(cardClick.GetComponent<Card>());            
            //Debug.Log("CardManager.NewCard.Add.//CountNewCard" + CardManager.NewCard.Count);

            cardClick.SetActive(false);
            gameUI.NewScene();
        }

        if (panelHandPlayer != null && cardClick.transform.parent==panelHandPlayer)
        {
            if (nameCard == "Number" && cardToCalculate.numberCard1CalculateText.text == "N")
            {
                Debug.Log("name: " + nameCard);
                number1 = cardClick.GetComponent<CardInfoScript>().numberCard.text;
                Debug.Log($"number1:{number1}");
                cardToCalculate.Card1Text(number1);

                card1 = cardClick;
                card1.SetActive(false);
                cardToCalculate.card1Calculate = card1;
            }
            else if (nameCard == "Number" && cardToCalculate.numberCard2CalculateText.text == "N")
            {
                Debug.Log("name: " + nameCard);
                number2 = cardClick.GetComponent<CardInfoScript>().numberCard.text;
                Debug.Log($"number1:{number2}");
                cardToCalculate.Card2Text(number2);

                card2 = cardClick;
                card2.SetActive(false);
                cardToCalculate.card2Calculate = card2;
            }
            else if (nameCard == "Operator" && cardToCalculate.operatorCard3CalculateText.text == "O")
            {
                Debug.Log("name: " + nameCard);
                operator3 = cardClick.GetComponent<CardInfoScript>().operatorCard.text;
                Debug.Log($"operator3: {operator3}");
                cardToCalculate.Card3Text(operator3);

                card3 = cardClick;
                card3.SetActive(false);
                cardToCalculate.card3Calculate = card3;
            }
        }
    }  
}
