using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using TMPro;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public TMP_InputField inputField;
    public Text BestScoreText;

    private void Start()
    {
        BestScoreText.text = "Best Score: " + SaveScore.instance.BestscorePlayerName + " : " + SaveScore.instance.Highscore;
    }

    public void ReadName()
    {
        string name;
        name = inputField.text;
        Debug.Log("ReadName: " + name);
        SaveScore.instance.PlayerName = name;
    }
    public void StartB()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitEditor()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
