using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}
public class GameManager : MonoBehaviour {

    private static GameManager instance;
    private GameState currentGameState;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentGameState = GameState.menu;
    }

    private void Update()
    {
        if (Input.GetKeyDown(0))
        {
            StartGame();

        }
    }
    public void StartGame()
    {
        SetGameState(GameState.inGame);
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    private void SetGameState(GameState state)
    {
        switch (state)
        {
            case GameState.menu:
                break;
            case GameState.inGame:
                break;
            case GameState.gameOver:
                break;
            default:
                break;
        }
        currentGameState = state;
    }

    #region Properties
    public GameState CurrentGameState
    {
        get
        {
            return currentGameState;
        }

        set
        {
            currentGameState = value;
        }
    }

    public static GameManager Instance
    {
        get
        {
            return instance;
        }

        set
        {
            instance = value;
        }
    }
    #endregion


}
