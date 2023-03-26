using System.IO;
using UnityEngine;


public class GlobalJsonController : MonoBehaviour
{
    public void SaveJson()
    {
        var globalJson = new GlobalJson();
        globalJson.AllCards = CardManager.AllCards;
        string json = JsonUtility.ToJson(globalJson);
        //Debug.Log(json);
        File.WriteAllText(Application.persistentDataPath + "/AllCardsGame.txt", json);
        //Debug.Log("Json Save");
    }
    public void LoadJson()
    {
        if (File.Exists(Application.persistentDataPath + "/AllCardsGame.txt"))
        {
            var json = File.ReadAllText(Application.persistentDataPath + "/AllCardsGame.txt");
            var globalJson = JsonUtility.FromJson<GlobalJson>(json);
            CardManager.AllCards = globalJson.AllCards;
            //Debug.Log("Json Load");
        }
    }
    public void DeleteJson()
    {
        File.Delete(Application.persistentDataPath + "/AllCardsGame.txt");
        //Debug.Log("DeleteJson");
        if (File.Exists(Application.persistentDataPath + "/AllCardsGame.txt"))
        {
            var json = File.ReadAllText(Application.persistentDataPath + "/AllCardsGame.txt");
            //Debug.Log(json);
        }
    }
}
