using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int Score;

    private string username;
    public string Username
    {
        get => username;
        set
        {
            if (value == "")
            {
                username = "Default";
            } else {
                username = value;
            }
        }
    }

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    public void CompareScore(string username, int score)
    {
        if (score > this.Score)
        {
            this.Username = username;
            this.Score = score;

            SaveScore();
        }
    }


    [System.Serializable]
    class SaveData
    {
        public string Username;
        public int Score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.Username = Username;
        data.Score = Score;

        string json = JsonUtility.ToJson(data);

        string path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Username = data.Username;
            Score = data.Score;
        }
    }
}
