using System.IO;
using UnityEngine;

public class GlobalJsonController : MonoBehaviour
{
    public void SaveJson()
    {
        var globalJson = new GlobalJson();
        globalJson.AllCards = CardManager.AllCards;
        string json = JsonUtility.ToJson(globalJson);
        File.WriteAllText(Application.persistentDataPath + "/AllCardsGame.txt", json);
        //Debug.Log("Json Save"+ json);
    }

    public void LoadJson()
    {
        if (File.Exists(Application.persistentDataPath + "/AllCardsGame.txt"))
        {
            var json = File.ReadAllText(Application.persistentDataPath + "/AllCardsGame.txt");
            var globalJson = JsonUtility.FromJson<GlobalJson>(json);
            CardManager.AllCards = globalJson.AllCards;
            //Debug.Log("Json Load"+json);
        }
    }

    public void DeleteJson()
    {
        File.Delete(Application.persistentDataPath + "/AllCardsGame.txt");
        //Debug.Log("DeletJson");
    }
}
