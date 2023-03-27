using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalControl : MonoBehaviour
{
    public int currentSceneIndex = 1;
    public int countRound= 1;
    public int countAllRound= 1;
    public int lifePlayer = 20;
    public int lifeEnemy;
    public int lifeEnemyStart;
    public GlobalJsonController jsonController;

    public static GlobalControl Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadData();
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        //Debug.Log("Awake GlobalControl");
    }

    public void HpEnemyStart(int hpStart)
    {
        lifeEnemyStart = hpStart;
        lifeEnemy = PlayerPrefs.GetInt("LifeEnemy", lifeEnemyStart);
        if (lifeEnemy <= 0)
        {
            lifeEnemy = lifeEnemyStart;
        }
                 
        //Debug.Log($"Awake/HpEnemyStart/lifeEnemy:{lifeEnemy} /lifeEnemyStart:{lifeEnemyStart}");
    }
    public void LoadData()
    {
        lifePlayer = PlayerPrefs.GetInt("LifePlayer", 20);
        countRound = PlayerPrefs.GetInt("CountRound", 1);
        countAllRound = PlayerPrefs.GetInt("CountAllRound", 1);
    }

    public void ResetData()
    {
        lifePlayer = 20;
        PlayerPrefs.SetInt("LifePlayer", lifePlayer);

        countRound = 1;
        PlayerPrefs.SetInt("CountRound", countRound);

        lifeEnemy = 0;
        PlayerPrefs.SetInt("LifeEnemy", lifeEnemy);

        countAllRound = 1;
        PlayerPrefs.SetInt("CountAllRound", countRound);

        jsonController.DeleteJson();
        CardManager.AllCards.Clear();
       
        //Debug.Log($"ResetData/ AllCards: {CardManager.AllCards.Count}");
        //Debug.Log($" ResetDATA /Set/ lifePlayer:{lifePlayer}");
    }
    public void CountAllRound()
    {
        countAllRound++;
        PlayerPrefs.SetInt("CountAllRound", countRound);
    }
    public void SaveScene()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SceneIndex", currentSceneIndex);
    }
    public int GetLastSavedScene()
    {
        currentSceneIndex = PlayerPrefs.GetInt("SceneIndex",1);
        return currentSceneIndex;
    }

}
