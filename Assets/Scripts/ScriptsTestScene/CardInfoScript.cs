using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInfoScript : MonoBehaviour
{
    public Card selfCard;
    public Image logoCard;
    public TextMeshProUGUI nameCard;
    
    public void HideCardInfo(Card card)
    {
        ShowCardInfo(card);
        //selfCard = card;
        //logoCard.sprite = null;
        //nameCard.text = "";
    }
    public void ShowCardInfo(Card card)
    {
        selfCard = card;
        logoCard.sprite = card.Logo;
        logoCard.preserveAspect = true;
        nameCard.text = card.Name;
    }
    
    private void Start()
    {
       // ShowCardInfo(CardManager.AllCards[transform.GetSiblingIndex()]);
    }

}
