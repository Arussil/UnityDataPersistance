using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public int score;
    public string highestScorePlayerName;
    public int? highestScore;
    
    private string savegamePath;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        savegamePath = Application.persistentDataPath + "/savefile.json";
        LoadGameData();
    }

    [System.Serializable]
    class GameData
    {
        public string highestScorePlayerName;
        public int highestScore;
    }

    public void SaveGameData()
    {
        GameData data = new GameData();

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(savegamePath, json);
    }

    public void LoadGameData()
    {
        if (File.Exists(savegamePath))
        {
            string json = File.ReadAllText(savegamePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            highestScorePlayerName = data.highestScorePlayerName;
            highestScore = data.highestScore;
        }
    }
}
