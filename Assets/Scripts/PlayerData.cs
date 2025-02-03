using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Overlays;


public class PlayerData : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static PlayerData Instance;
    public string playerName;
    public InputField playerNameField;
    public int highScore;
    public string HSPlayerName;
    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    [System.Serializable]
    class SaveData
    {
        public string HSPlayerName;
        public int HighScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HSPlayerName = playerName;
        data.HighScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HSPlayerName = data.HSPlayerName;
            highScore = data.HighScore;
        }
    }

}