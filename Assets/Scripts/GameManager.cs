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
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas inGameCanvas;
    [SerializeField] private Canvas gameOverCanvas;

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
        if (Input.GetKeyDown("s"))
        {
            StartGame();
        }
    }
    public void StartGame()
    {
        SetGameState(GameState.inGame);
        PlayerController.instance.StartGame();
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        SetGameState(GameState.menu);
    }

    public void RestartGame()
    {
        LevelGenerator.instance.RestartPieces();
        SetGameState(GameState.inGame);
        PlayerController.instance.StartGame();
    }
    private void SetGameState(GameState state)
    {
        switch (state)
        {
            case GameState.menu:
                menuCanvas.enabled = true;
                inGameCanvas.enabled = false;
                gameOverCanvas.enabled = false;
                break;
            case GameState.inGame:
                menuCanvas.enabled = false;
                inGameCanvas.enabled = true;
                gameOverCanvas.enabled = false;
                break;
            case GameState.gameOver:
                gameOverCanvas.enabled = true;
                menuCanvas.enabled = false;
                inGameCanvas.enabled = false;
                
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
