using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalControl : MonoBehaviour
{
    public int currentSceneIndex = 1;
    public int lifePlayer = 20;
    public int lifeEnemy;
    public int lifeEnemyStart;   
    //public 
    public static GlobalControl Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadAllData();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void HpEnemyStart(int hpStart)
    {
        lifeEnemyStart = hpStart;
        lifeEnemy = PlayerPrefs.GetInt("LifeEnemy", lifeEnemyStart);
        if (lifeEnemy <= 0)
        {
            lifeEnemy = lifeEnemyStart;
        }
        Debug.Log($"StartGame /lifeEnemy:{lifeEnemy} /lifeEnemyStart:{lifeEnemyStart}");
    }
    public void LoadAllData()
    {
        lifePlayer = PlayerPrefs.GetInt("LifePlayer", 20);
        Debug.Log("LoadDATA/ Get/ lifePlayer:" + lifePlayer);
    }
    public void ResetDataPlayer()
    {
        lifePlayer = 20;
        PlayerPrefs.SetInt("LifePlayer", lifePlayer);
        Debug.Log($" ResetDATA /Set/ lifePlayer:{lifePlayer}");        
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
