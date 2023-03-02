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
    GameObject cardToCalculate;   

    void Start()
    {
        cardToCalculate = GameObject.Find("GameController");
    }

    public void OnPointerClick(PointerEventData eventData)
    {        
        Debug.Log("OnClickTriger");        
        cardClick = eventData.pointerClick.GameObject();
        nameCard = cardClick.GetComponent<CardInfoScript>().nameCard.text;

        if (nameCard == "Number" && cardToCalculate.GetComponent<CardToCalculate>().numberCard1CalculateText.text == "N")
        {         
            Debug.Log("name: " + nameCard);
            number1 = cardClick.GetComponent<CardInfoScript>().numberCard.text;
            Debug.Log($"number1:{number1}");
            cardToCalculate.GetComponent<CardToCalculate>().Card1Text(number1);

            card1 = cardClick;
            card1.SetActive(false);
            cardToCalculate.GetComponent<CardToCalculate>().card1Calculate=card1;
 
        }
        else if (nameCard == "Number"&& cardToCalculate.GetComponent<CardToCalculate>().numberCard2CalculateText.text == "N")
        {            
            Debug.Log("name: " + nameCard);
            number2 = cardClick.GetComponent<CardInfoScript>().numberCard.text;
            Debug.Log($"number1:{number2}");
            cardToCalculate.GetComponent<CardToCalculate>().Card2Text(number2);

            card2 = cardClick;
            card2.SetActive(false);
            cardToCalculate.GetComponent<CardToCalculate>().card2Calculate = card2;
        }
        else if (nameCard == "Operator"&& cardToCalculate.GetComponent<CardToCalculate>().operatorCard3CalculateText.text == "O")
        {            
            Debug.Log("name: " + nameCard);
            operator3 = cardClick.GetComponent<CardInfoScript>().operatorCard.text;
            Debug.Log($"operator3: {operator3}");
            cardToCalculate.GetComponent<CardToCalculate>().Card3Text(operator3);

            card3 = cardClick;
            card3.SetActive(false);
            cardToCalculate.GetComponent<CardToCalculate>().card3Calculate = card3;
        }     
        //Destroy(cardClick);
        //GetComponent<CanvasGroup>().blocksRaycasts = false;//карта перестає взаємодіяти з мишкою
    }  
}
