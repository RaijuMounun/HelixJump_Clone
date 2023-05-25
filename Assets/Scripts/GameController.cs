using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    StartScr,
    Playing,
    GameOver,
    GameWin
}
public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject[] screens;
    public GameState gameState;
    public int score;
    public TMPro.TMP_Text scoreText, gameOverScoreText, gameWinScoreText;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        gameState = GameState.StartScr;
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }
        screens[0].SetActive(true);
    }

    #region Button Funcs
    public void StartButton()
    {
        gameState = GameState.Playing;
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }
        screens[1].SetActive(true);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameState = GameState.Playing;
        for (int i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(false);
        }
        screens[1].SetActive(true);

    }

    public void QuitButton()
    {
        Application.Quit();
    }
    #endregion
}
