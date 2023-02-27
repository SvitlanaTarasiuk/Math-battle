using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInfoScript : MonoBehaviour
{
    public Card selfCard;
    public Image logoCard1;
    public Image logoCard2;
    public TextMeshProUGUI nameCard;
    public TextMeshProUGUI numberCard;
    public TextMeshProUGUI operatorCard;
    //public bool isPlayer;
    //public GameObject hideobj;//рубашка карти
    //public GameObject highliteobj;//підсвітка карти

    //public void HideCardInfo(Card card)
    //{       
    //    selfCard = card;     
    //    hideobj.SetActive(true); 
    //    isPlayer= false;

    //ShowCardInfo(card);
    //selfCard = card;
    //logoCard.sprite = null;
    //nameCard.text = "";
    //}
    public void ShowCardInfo(Card card)    //,bool is_Player)
    {
        //isPlayer = is_Player;
        // hideobj.SetActive(false);
        selfCard = card;
        logoCard1.sprite = card.LogoBG;
        logoCard1.preserveAspect = true;
        logoCard2.sprite = card.LogoImage;
        logoCard2.preserveAspect = true;
        nameCard.text = card.Name;

        RefreshData();
    }

    public void RefreshData()
    {
        if (selfCard.Number != 0)
            numberCard.text = selfCard.Number.ToString();
        else
            operatorCard.text = selfCard.Operator.ToString();
    }

         
        //public void HighlightCard()
        //{
        //    highliteobj.SetActive(true );
        //}
        //public void DeHighlightCard()
        //{
        //    highliteobj.SetActive(false );  
        //}

    
}

