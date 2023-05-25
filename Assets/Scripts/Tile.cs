using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    GameController gameController;

    private void Awake()
    {
        gameController = GameController.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        gameController.score++;
        gameController.scoreText.text = gameController.score.ToString();
        gameController.gameOverScoreText.text = gameController.gameWinScoreText.text = "Score: " + gameController.score.ToString();
    }
}
