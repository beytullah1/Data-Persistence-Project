using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneLoadBehavior : MonoBehaviour
{
    public static SceneLoadBehavior Instance;
    public TMP_InputField nameInputField;

    public string playerName;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void LoadGameScene()
    {
        playerName = nameInputField.text;
        SceneManager.LoadScene(1);
    }
}
