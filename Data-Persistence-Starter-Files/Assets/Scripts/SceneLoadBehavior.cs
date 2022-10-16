using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneLoadBehavior : MonoBehaviour
{
    public static SceneLoadBehavior Instance;
    public TMP_InputField nameInputField;
    public TextMeshProUGUI playerHighScoreText;
    [HideInInspector] public string playerName;

    private int highScore;
    private string highScorePlayerName;

    private void Start()
    {
        LoadScore();
        playerHighScoreText.text = "High Score Owner: " + highScorePlayerName + " High Score: " + highScore;
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
    }
    public void LoadGameScene()
    {
        playerName = nameInputField.text;
        SceneManager.LoadScene(1);
    }
    class SaveData
    {
        public string highScorePlayerName;
        public int highScore;
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            highScorePlayerName = data.highScorePlayerName;
            playerHighScoreText.text = "High Score Owner: " + highScorePlayerName + " High Score: " + highScore.ToString();
        }
    }
}
