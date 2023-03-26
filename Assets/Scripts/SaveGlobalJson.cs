//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.IO;
//using UnityEngine;

//public class SaveGlobalJson : MonoBehaviour
//{
//    public List<Card> AllCards;
//    private string savePath;
//    public string saveFileName = "data.json";
//    void Awake()
//    {
//        Debug.Log("Json");

//#if UNITY_ANDROID && !UNITY_EDITOR
//        savePath = Path.Combine(Application.persistentDataPath, saveFileName);
//#else
//        savePath = Path.Combine(Application.dataPath, saveFileName);
//#endif
//        LoadFromFile();
//    }
//    public void SaveToFile()
//    {
//        GlobalJson globalJson = new GlobalJson();
//        globalJson.AllCards = this.AllCards;

//        string json = JsonUtility.ToJson(globalJson, prettyPrint: true);

//        try
//        {
//            File.WriteAllText(savePath, contents: json);
//        }
//        catch (Exception e)
//        {
//            Debug.Log(message: "{SaveGlobalJson}=>[globalJson] - (<color=red>Error</color>)-SaveToFile -> "+ e.Message);
//        }
//    }
//    public void LoadFromFile()
//    {
//        if (!File.Exists(savePath))
//        {
//            Debug.Log(message: "{SaveGlobalJson}=>[globalJson] - LoadFromFile -> File Not Faund!");
//            return;
//        }

//        try
//        {
//            string json = File.ReadAllText(savePath);
//            GlobalJson globalFromJson = JsonUtility.FromJson<GlobalJson>(json);
//            this.AllCards = globalFromJson.AllCards;
//            CardManager.AllCards= this.AllCards;
//        }
//        catch (Exception e)
//        {
//            Debug.Log(message: "{SaveGlobalJson}=>[globalJson] - (<color=red>Error</color>)-LoadFromFile -> " + e.Message);
//        }
//    }
//    private void OnApplicationQuit()
//    {
//        SaveToFile();
//    }
//    private void OnApplicationPause(bool pause)
//    {
//        if (Application.platform == RuntimePlatform.Android)
//        {
//            SaveToFile();
//        }
//    }
//}