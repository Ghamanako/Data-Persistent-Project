using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveScore : MonoBehaviour
{
    public static SaveScore instance;
    public int Highscore;
    public string PlayerName;
    public string BestscorePlayerName;
   [System.Serializable]
   class SaveData
    {
        public string BestScorePlayerName;
        public int HighScore;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void SaveHighscore()
    {
        SaveData data = new SaveData();
        data.HighScore = Highscore;
        data.BestScorePlayerName = BestscorePlayerName; 

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        Debug.Log("File:" + path);
        if (File.Exists(path))
        {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        Highscore = data.HighScore;
        BestscorePlayerName = data.BestScorePlayerName;

        }
    }
}
