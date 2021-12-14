using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public GameObject homeGUI;
    public GameObject gameGUI;
    public GameObject gameOver;
    public Text scoreCountingText;
    public override void Awake()
    {
        MakeSingleton(false);
    }
    public void ShowGameGui(bool isShow)
    {
        if (gameGUI)
            gameGUI.SetActive(isShow);
        if (homeGUI)
            homeGUI.SetActive(!isShow);
    }
    public void ShowGameOver(bool isShow)
    {
        if (gameOver)
            gameOver.SetActive(isShow);
    }
    public void UpdateScoreCounting(int score)
    {
        if (scoreCountingText)
            scoreCountingText.text = "SCORE : x" + score.ToString("00");
    }
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Home()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Application.Quit();
    }
}
