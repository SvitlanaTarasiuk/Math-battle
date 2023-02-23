//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;

//public class AttackedCard : MonoBehaviour,IDropHandler

//{
//    public void OnDrop(PointerEventData eventData)
//    {
//       CardInfoScript card = eventData.pointerDrag.GetComponent<CardInfoScript>();
//        if (card && card.selfCard.canAttack &&
//            transform.parent == GetComponent<CardMovementScript>().gameManager.EnemyField)
//        {
//            card.selfCard.ChangeAttackState(false);

//            if (card.isPlayer)
//                card.DeHighlightCard();

//            GetComponent<CardMovementScript>().gameManager.CardsFight(card, GetComponent<CardInfoScript>());

//        }
//    }
//    GetComponent<CardMovementScript>().gameManager.SummaCard(card1, card2, card3);


//}
