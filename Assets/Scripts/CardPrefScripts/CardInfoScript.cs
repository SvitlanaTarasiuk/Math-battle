using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInfoScript : MonoBehaviour
{
    public Card SelfCard;

    public Image LogoCardBG;

    public Image LogoCardImage;

    public TextMeshProUGUI NameCard;
    
    public TextMeshProUGUI NumberCard;
    
    public TextMeshProUGUI OperatorCard;

    public void ShowCardInfo(Card card)
    {
        SelfCard = card;
        LogoCardBG.sprite = card.LogoBG;
        LogoCardBG.preserveAspect = true;
        LogoCardImage.sprite = card.LogoImage;
        LogoCardImage.preserveAspect = true;
        NameCard.text = card.Name;

        RefreshData();
    }

    public void RefreshData()
    {
        if (SelfCard.Number != 0)
            NumberCard.text = SelfCard.Number.ToString();
        else
            OperatorCard.text = SelfCard.Operator.ToString();
    }
}

