using System.IO;
using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class GlobalJson
{
    public List<Card> AllCardsJson { get; set; } = new List<Card>();
}

public class GlobalJsonController : MonoBehaviour
{
    public void SaveJson()
    {
        var globalJson = new GlobalJson();
        string json = JsonUtility.ToJson(globalJson);
        File.WriteAllText(Application.persistentDataPath + "/AllCardsGame.txt", json);
        //Debug.Log("Json Save"+ json);
    }

    public void LoadJson()
    {
        if (File.Exists(Application.persistentDataPath + "/AllCardsGame.txt"))
        {
            string json = File.ReadAllText(Application.persistentDataPath + "/AllCardsGame.txt");
            var globalJson = JsonUtility.FromJson<GlobalJson>(json);
            CardManager.AllCards = globalJson.AllCardsJson;
            //Debug.Log("Json Load" + json);
            //Debug.Log("Json.Count/Load" + globalJson.AllCardsJson.Count);
        }
    }

    public void DeleteJson()
    {
        File.Delete(Application.persistentDataPath + "/AllCardsGame.txt");
        //Debug.Log("DeletJson");
    }
}
