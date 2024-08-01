using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{

    public static MenuManager Instance;
    public string highName;
    public int highScore;
    public string currName;
    public int currScore;

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    class SaveData {
        public string highName;
        public int highScore;
    }
    
    public void SaveScore() {
        SaveData data = new SaveData();
        
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);

            if (data.highScore < currScore) {
                data.highScore = currScore;
                data.highName = currName;
            }
        }
        else {
            data.highScore = currScore;
            data.highName = currName;
        }

        string newjson = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", newjson);
    }

    public void LoadScore() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highName = data.highName;
            highScore = data.highScore;
        }
        else {
            highName = "-";
            highScore = 0;
        }
    }
}
