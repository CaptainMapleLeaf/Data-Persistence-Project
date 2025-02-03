using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public string playerName;
    public TextMeshProUGUI playerNameField;
    public TextMeshProUGUI highScoreText;

    public void Start()
    {
        playerNameField = GameObject.Find("PlayerNameText").GetComponent<TextMeshProUGUI>();
        highScoreText = GameObject.Find("HighScoreText").GetComponent<TextMeshProUGUI>();
        PlayerData.Instance.LoadHighScore();
        SetHighScoreText();
    }
    public void SetPlayerName()
    {
        playerName = playerNameField.text;
        PlayerData.Instance.playerName = playerName;
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit(); // original code to quit Unity player
        #endif
    }
    public void SetHighScoreText()
    {
        highScoreText.text = "High Score: " + PlayerData.Instance.HSPlayerName + " : " + PlayerData.Instance.highScore;
    }


}
