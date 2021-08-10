using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    
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
        public string playerName;
    }

    public void SaveGameData()
    {
        GameData data = new GameData();
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(savegamePath, json);
    }

    public void LoadGameData()
    {
        if (File.Exists(savegamePath))
        {
            string json = File.ReadAllText(savegamePath);
            GameData data = JsonUtility.FromJson<GameData>(json);
            playerName = data.playerName;
        }
    }
}
