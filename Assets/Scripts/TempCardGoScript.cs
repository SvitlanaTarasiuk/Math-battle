using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempCardGoScript : MonoBehaviour
{
    public GameObject tempCardGo;
    Vector3 offset;
    float speed = 3f;
    public Transform TempCardGoStart;
    public Transform TempCardGoFinish;

    private void Start()
    {
        // transform.position = TempCardGoStart.position;
    }
    public void CardGoMove()
    {

        //offset = new Vector3(0,100,0);
        //tempCardGo.SetActive(true);
        //transform.position = new Vector2(transform.position.x, transform.transform.position.y + speed * Time.deltaTime);

        //transform.position = transform.position+new Vector3(0,50*speed*Time.deltaTime,0);

        //tempCardGo.transform.position = TempCardGoFinish.position * speed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        //transform.position = TempCardGoStart.position;
        Debug.Log("CardGoMove");
        
        //tempCardGo.transform.Translate(offset, Time.deltaTime, speed);
        //tempCardGo.transform.position = offset;

    }
   
    //        defoultParent = defoultTempCardParent = transform.parent;//батько карти

    //        tempCardGo.transform.SetParent(defoultParent);
    //        tempCardGo.transform.SetSiblingIndex(transform.GetSiblingIndex());
    //        transform.SetParent(defoultParent.parent);
    // 

    //        Vector3 newPos = mainCamera.ScreenToWorldPoint(eventData.position);// позиції карти присвоїли конвертовані координати миші
    //        transform.position = newPos + offset;

    //        if (tempCardGo.transform.parent != defoultTempCardParent)
    //            tempCardGo.transform.SetParent(defoultTempCardParent);

    //        transform.SetSiblingIndex(tempCardGo.transform.GetSiblingIndex());
    //        tempCardGo.transform.SetParent(GameObject.Find("Canvas").transform);
    //        tempCardGo.transform.localPosition = new Vector3(2340, 0);
 

   

}
