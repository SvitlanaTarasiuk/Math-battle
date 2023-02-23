//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.EventSystems;//��������� �������� 

//public class CardMovementScript : MonoBehaviour//, IBeginDragHandler, IEndDragHandler, IDragHandler//����������� ����������
//{
//    Camera mainCamera;
//    Vector3 offset;//���������� �������� �� ������ ����� �� ����,�� ��� ��� �����
//    public Transform defoultParent;
//    public Transform defoultTempCardParent;//��������� ������
//    GameObject tempCardGo;
//    public GameManagerScript gameManager;
//    public bool isDraggable;
//    private void Awake()
//    {
//        mainCamera = Camera.allCameras[0];//���� ������ ���� �� ����� ��� ������ ������� ������
//        tempCardGo = GameObject.Find("tempCardGo");
//        gameManager = FindObjectOfType<GameManagerScript>();
//    }
//    public void OnBeginDrag(PointerEventData eventData)//��� ���������� ���� ���,���� �� ������� ������������ ��"���
//    {
//        offset = transform.position - mainCamera.ScreenToWorldPoint(eventData.position);

//        defoultParent = defoultTempCardParent = transform.parent;//������ �����

//        //isDraggable = (defoultParent.GetComponent<DropPlaceScript>().fieldType == FieldType.SelfHand|| 
//        //    defoultParent.GetComponent<DropPlaceScript>().fieldType == FieldType.SelfField)&&
//        //    gameManager.IsPlayerTurn;

//        if (!isDraggable)
//            return;

//        tempCardGo.transform.SetParent(defoultParent);
//        tempCardGo.transform.SetSiblingIndex(transform.GetSiblingIndex());

//        transform.SetParent(defoultParent.parent);
//        GetComponent<CanvasGroup>().blocksRaycasts = false;//����� ������� ��������� � ������
//    }

//    public void OnDrag(PointerEventData eventData)//��� ���� ������������ ����� ���� ���� ������ ������� ��"���
//    {
//        if (!isDraggable)
//            return;

//        Vector3 newPos = mainCamera.ScreenToWorldPoint(eventData.position);// ������� ����� �������� ����������� ���������� ����
//        transform.position = newPos + offset;

//        if (tempCardGo.transform.parent != defoultTempCardParent)
//            tempCardGo.transform.SetParent(defoultTempCardParent);

//        if (defoultParent.GetComponent<DropPlaceScript>().fieldType != FieldType.SelfField)
//            CheckPosition();
//    }

//    public void OnEndDrag(PointerEventData eventData)//��� ��������� ���� ���,���� �� �������� ��"���
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
