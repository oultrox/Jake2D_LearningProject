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
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas inGameCanvas;
    [SerializeField] private Canvas gameOverCanvas;
    private static GameManager instance;
    private GameState currentGameState;
    private int collectedCoins;
    

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

    public void StartGame()
    {
        SetGameState(GameState.inGame);
        PlayerController.Instance.StartGame();
    }

    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        LevelGenerator.instance.RestartPieces();
        PlayerController.Instance.StartGame();
        SetGameState(GameState.menu);
    }

    public void RestartGame()
    {
        LevelGenerator.instance.RestartPieces();
        SetGameState(GameState.inGame);
        PlayerController.Instance.StartGame();
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

    public void CollectedCoin()
    {
        collectedCoins++;
        GUIManager.instance.UpdateCoinText();
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

    public int CollectedCoins
    {
        get
        {
            return collectedCoins;
        }

        set
        {
            collectedCoins = value;
        }
    }
    #endregion


}
