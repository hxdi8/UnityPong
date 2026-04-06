using System;
using System.Data.Common;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int scorePlayer1, scorePlayer2;
    public System.Action onReset;
    public GameUI gameUI;
    public GameAudio gameAudio;
    public int maxScore = 4;

    private void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            gameUI.onStartGame += OnStartGame;
        }
    }

    private void OnDestroy()
    {
        gameUI.onStartGame -= OnStartGame;
    }

    public void OnScoreZoneReached(int id)
    {

        if (id == 1)
        {
            scorePlayer1++;
        }
        if (id == 2)
        {
            scorePlayer2++;
        }

        gameUI.UpdateScore(scorePlayer1, scorePlayer2);
        gameUI.HighlightScore(id);
        checkWin();
    }

    private void checkWin()
    {
        int winnerID = scorePlayer1 == maxScore ? 1 : scorePlayer2 == maxScore ? 2 : 0;

        // above line is same as:
        // if scorePlayer1 == maxScore ----> then winnerID = 1
        // if scorePlayer2 == maxScore ----> then winnerID = 2

        if (winnerID != 0)
        {
            gameUI.onGameEnds(winnerID);
            gameAudio.PlayWinSound();
        }
        else   
        {
            onReset?.Invoke();
            gameAudio.PlayScoreSound();
        }
    }
    
    private void OnStartGame()
    {
        scorePlayer1 = 0;
        scorePlayer2 = 0;
        gameUI.UpdateScore(scorePlayer1, scorePlayer2);
    }
}
