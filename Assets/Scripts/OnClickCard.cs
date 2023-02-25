using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using TMPro;

public class OnClickCard : MonoBehaviour, IPointerClickHandler
{
    GameObject cardClick;
    public string number1;
    public string number2;
    public string operator3;
    GameObject cardToCalculete;
    string nameCard;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnClickTriger");
        cardToCalculete = GameObject.Find("GameController");       
        cardClick = eventData.pointerClick.GameObject();
        nameCard = cardClick.GetComponent<CardInfoScript>().nameCard.text;

        if (nameCard == "Number" && cardToCalculete.GetComponent<CardToCalculete>().numberCard1CalculeteText.text == "N")
        {
            Debug.Log("name: " + nameCard);
            number1 = cardClick.GetComponent<CardInfoScript>().numberCard.text;
            Debug.Log($"number1:{number1}");
            cardToCalculete.GetComponent<CardToCalculete>().Card1Text(number1);            
        }
        else if (nameCard == "Number"&& cardToCalculete.GetComponent<CardToCalculete>().numberCard2CalculeteText.text == "N")
        {
            Debug.Log("name: " + nameCard);
            number2 = cardClick.GetComponent<CardInfoScript>().numberCard.text;
            Debug.Log($"number1:{number1}");
            cardToCalculete.GetComponent<CardToCalculete>().Card2Text(number2);
        }
        else if (nameCard == "Operator"&& cardToCalculete.GetComponent<CardToCalculete>().operatorCard3CalculeteText.text == "O")
        {
            Debug.Log("name: " + nameCard);
            operator3 = cardClick.GetComponent<CardInfoScript>().operatorCard.text;
            Debug.Log($"operator3: {operator3}");
            cardToCalculete.GetComponent<CardToCalculete>().Card3Text(operator3);
        }
         
        //cardClick.SetActive(false);
        //GetComponent<GameManagerScript>().countCardNotGame++;
        // GetComponent<CardToCalculete>().SelectedCardToCalculete();
        //GetComponent<CanvasGroup>().blocksRaycasts = false;//карта перестає взаємодіяти з мишкою
    }

}
