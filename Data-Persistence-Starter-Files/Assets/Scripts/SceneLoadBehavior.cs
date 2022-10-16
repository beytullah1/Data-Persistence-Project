using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneLoadBehavior : MonoBehaviour
{
    public static SceneLoadBehavior Instance;
    public TMP_InputField nameInputField;
    public TextMeshProUGUI highScoreText;
    [HideInInspector] public string playerName;

    private void Start()
    {
        highScoreText.text = "High Score Owner: " + MainManager.highScorePlayerName + " High Score: " + MainManager.highScore;
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
}
