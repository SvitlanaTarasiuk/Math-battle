using System.IO;
using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class GlobalJson
{
    public List<Card> AllCardsJson = new List<Card>();
}

public class GlobalJsonController : MonoBehaviour
{
    private string _fileName = "/AllCardsGame.txt";

    public void SaveJson()
    {
        var globalJson = new GlobalJson
        {
            AllCardsJson = CardManager.AllCards
        };
        string json = JsonUtility.ToJson(globalJson);
        File.WriteAllText(Application.persistentDataPath + _fileName, json);
        //Debug.Log("Json Save"+ json);
    }

    public void LoadJson()
    {
        if (File.Exists(Application.persistentDataPath + _fileName))
        {
            string json = File.ReadAllText(Application.persistentDataPath + _fileName);
            var globalJson = JsonUtility.FromJson<GlobalJson>(json);
            CardManager.AllCards = globalJson.AllCardsJson;
            //Debug.Log("Json Load" + json);
            //Debug.Log("LoadJson.Count" + globalJson.AllCardsJson.Count);
        }
    }

    public void DeleteJson()
    {
        File.Delete(Application.persistentDataPath + _fileName);
        //Debug.Log("DeletJson");
    }
}
