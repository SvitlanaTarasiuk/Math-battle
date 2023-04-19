using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalControl : MonoBehaviour
{
    [SerializeField] private int lifeEnemyStart;

    [field: SerializeField] public int LifeEnemy { get; set; }

    [field: SerializeField] public int LifePlayer { get; set; } = 20;

    [field: SerializeField] public int CurrentSceneIndex { get; set; } = 1;

    [field: SerializeField] public int CountRound { get; set; } = 1;

    [field: SerializeField] public int CountAllRound { get; set; } = 1;

    public GlobalJsonController JsonController { get; set; }

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
        LifeEnemy = PlayerPrefs.GetInt("LifeEnemy", lifeEnemyStart);

        if (LifeEnemy <= 0)
        {
            LifeEnemy = lifeEnemyStart;
        }
        //Debug.Log($"Awake/HpEnemyStart/lifeEnemy:{lifeEnemy} /lifeEnemyStart:{lifeEnemyStart}");
    }

    public void LoadData()
    {
        JsonController = GetComponent<GlobalJsonController>();      
        JsonController.LoadJson();
        LifePlayer = PlayerPrefs.GetInt("LifePlayer", 20);
        CountRound = PlayerPrefs.GetInt("CountRound", 1);
        CountAllRound = PlayerPrefs.GetInt("CountAllRound", 1);
        //Debug.Log("Global/Load");
    }

    public void ResetData()
    {
        LifePlayer = 20;
        PlayerPrefs.SetInt("LifePlayer", LifePlayer);

        CountRound = 1;
        PlayerPrefs.SetInt("CountRound", CountRound);

        LifeEnemy = 0;
        PlayerPrefs.SetInt("LifeEnemy", LifeEnemy);

        CountAllRound = 1;
        PlayerPrefs.SetInt("CountAllRound", CountRound);

        JsonController.DeleteJson();
        CardManager.AllCards.Clear();

        //Debug.Log($"ResetData/ AllCards: {CardManager.AllCards.Count}");
    }

    public void CountAllRoundAndSave()
    {
        CountAllRound++;
        PlayerPrefs.SetInt("CountAllRound", CountRound);
    }

    public void SaveScene()
    {
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("SceneIndex", CurrentSceneIndex);
    }

    public int GetLastSavedScene()
    {
        CurrentSceneIndex = PlayerPrefs.GetInt("SceneIndex", 1);
        return CurrentSceneIndex;
    }

}
