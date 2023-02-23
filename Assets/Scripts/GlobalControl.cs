using UnityEngine;
using UnityEngine.SceneManagement;



public class GlobalControl : MonoBehaviour
{
    public int life = 3;
    public int currentSceneIndex;

    public static GlobalControl Instance;


    void Awake()
    {
        print("AwakeGlobalControl");
        if (Instance == null)
        {
            print("DontDestroy");
            DontDestroyOnLoad(gameObject);
            Instance = this;
            LoadAllData();
        }
        else if (Instance != this)
        {
            print("Destroy");
            Destroy(gameObject);
        }
    }
    public void LoadAllData()
    { 
        life = PlayerPrefs.GetInt("Life", 3);
    }
    public void ResetData()
    {
        print("ResetData");
        life = 3;
        PlayerPrefs.SetInt("Life", life);
    }
    public void SaveScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SceneIndex", currentSceneIndex);
    }
    public int GetLastSavedScene()
    {
        currentSceneIndex = PlayerPrefs.GetInt("SceneIndex");
        return currentSceneIndex;
    }
}
