 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FieldType
{
    SelfHand,
    SelfField,
    EnemyHand,
    EnemyField,
}
public class DropPlaceScript : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public FieldType fieldType;
    public void OnDrop(PointerEventData eventData)
    {
        if (fieldType != FieldType.SelfField)
            return;
        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();
        if (card)
            card.defoultParent = transform;
    }

    public void OnPointerEnter(PointerEventData eventData)//відстежують наведення миші до границі об"єкта
    {
        if (eventData.pointerDrag == null||fieldType==FieldType.EnemyField||fieldType==FieldType.EnemyHand)
            return;
        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();
        if(card)
            card.defoultTempCardParent = transform;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        CardMovementScript card = eventData.pointerDrag.GetComponent<CardMovementScript>();
        if (card && card.defoultTempCardParent==transform)
            card.defoultTempCardParent = card.defoultParent;//після відпускання карта повернеться на місце
    }
}
