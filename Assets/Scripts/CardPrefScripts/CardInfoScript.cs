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

    public void ShowCardInfo(Card card)
    {
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
}

