using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInfoScript : MonoBehaviour
{
    public Card SelfCard { get; private set; }
   
    [field: SerializeField] public Image LogoCardBG { get; private set; }
   
    [field: SerializeField] public Image LogoCardImage { get; private set; }
   
    [field: SerializeField] public TextMeshProUGUI NameCard { get; private set; }
   
    [field: SerializeField] public TextMeshProUGUI OperatorCard { get; private set; }
   
    [field: SerializeField] public TextMeshProUGUI NumberCard { get; private set; }

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

