//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.EventSystems;//п≥дключили б≥бл≥отеку 

//public class CardMovementScript : MonoBehaviour//, IBeginDragHandler, IEndDragHandler, IDragHandler//унасл≥дували ≥нтерфейси
//{
//    Camera mainCamera;
//    Vector3 offset;//збер≥гатиме значенн€ в≥д центра карти до м≥сц€,де був кл≥к мишою
//    public Transform defoultParent;
//    public Transform defoultTempCardParent;//тимчасова картка
//    GameObject tempCardGo;
//    public GameManagerScript gameManager;
//    public bool isDraggable;
//    private void Awake()
//    {
//        mainCamera = Camera.allCameras[0];//€кщо камера одна то можна так задати позиц≥ю камери
//        tempCardGo = GameObject.Find("tempCardGo");
//        gameManager = FindObjectOfType<GameManagerScript>();
//    }
//    public void OnBeginDrag(PointerEventData eventData)//код виконаЇтьс€ один раз,коли ми почнемо перет€гувати об"Їкт
//    {
//        offset = transform.position - mainCamera.ScreenToWorldPoint(eventData.position);

//        defoultParent = defoultTempCardParent = transform.parent;//батько карти

//        //isDraggable = (defoultParent.GetComponent<DropPlaceScript>().fieldType == FieldType.SelfHand|| 
//        //    defoultParent.GetComponent<DropPlaceScript>().fieldType == FieldType.SelfField)&&
//        //    gameManager.IsPlayerTurn;

//        if (!isDraggable)
//            return;

//        tempCardGo.transform.SetParent(defoultParent);
//        tempCardGo.transform.SetSiblingIndex(transform.GetSiblingIndex());

//        transform.SetParent(defoultParent.parent);
//        GetComponent<CanvasGroup>().blocksRaycasts = false;//карта перестаЇ взаЇмод≥€ти з мишкою
//    }

//    public void OnDrag(PointerEventData eventData)//код буде виконуватис€ кожен кадр поки будемо т€гнути об"Їкт
//    {
//        if (!isDraggable)
//            return;

//        Vector3 newPos = mainCamera.ScreenToWorldPoint(eventData.position);// позиц≥њ карти присвоњли конвертован≥ координати миш≥
//        transform.position = newPos + offset;

//        if (tempCardGo.transform.parent != defoultTempCardParent)
//            tempCardGo.transform.SetParent(defoultTempCardParent);

//        if (defoultParent.GetComponent<DropPlaceScript>().fieldType != FieldType.SelfField)
//            CheckPosition();
//    }

//    public void OnEndDrag(PointerEventData eventData)//код виконаЇть€ один раз,коли ми в≥дпустим об"Їкт
//    {
//        if (!isDraggable)
//            return;

//        transform.SetParent(defoultParent);
//        GetComponent<CanvasGroup>().blocksRaycasts = true;
//        transform.SetSiblingIndex(tempCardGo.transform.GetSiblingIndex());
//        tempCardGo.transform.SetParent(GameObject.Find("Canvas").transform);
//        tempCardGo.transform.localPosition = new Vector3(2340, 0);
//    }
//    void CheckPosition()
//    {
//        int newIndex = defoultTempCardParent.childCount;
//        for (int i = 0; i < defoultTempCardParent.childCount; i++)
//        {
//            if (transform.position.x < defoultTempCardParent.GetChild(i).position.x)
//            {
//                newIndex = i;

//                if (tempCardGo.transform.GetSiblingIndex() < newIndex)
//                    newIndex--;
//                break;
//            }
//        }
//        tempCardGo.transform.SetSiblingIndex(newIndex);
//    }
//}
