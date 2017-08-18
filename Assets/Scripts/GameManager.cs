using UnityEngine;

public enum GameState
{
    menu,
    inGame,
    gameOver
}

//Manages the transition of the states of the game
public class GameManager : MonoBehaviour {
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas inGameCanvas;
    [SerializeField] private Canvas gameOverCanvas;
    private static GameManager instance;
    private GameState currentGameState;
    private int collectedCoins;
    
    //----Métodos API-----
    //Singleton creation
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

    //Initalization in the menu view.
    void Start()
    {
        currentGameState = GameState.menu;
    }

    //------Métodos Custom------
    public void StartGame()
    {
        SetGameState(GameState.inGame);
        PlayerController.Instance.StartGame();
        this.collectedCoins = 0;
        GUIManager.instance.UpdateCoinText();
        GUIManager.instance.UpdateBestScoreText();
    }

    public void GameOver()
    {
        GUIManager.instance.UpdateGameOverScoreText();
        GUIManager.instance.UpdateGameOverCoinText();
        SetGameState(GameState.gameOver);
    }

    public void BackToMenu()
    {
        LevelGenerator.instance.RestartPieces();
        PlayerController.Instance.StartGame();
        SetGameState(GameState.menu);
    }

    //Restart was made to restore the position of the player correctly along with the GUI labels.
    public void RestartGame()
    {
        LevelGenerator.instance.RestartPieces();
        SetGameState(GameState.inGame);
        PlayerController.Instance.StartGame();
        this.collectedCoins = 0;
        GUIManager.instance.UpdateCoinText();
    }

    //Activa y desactiva los canvas necesarios para los estados del juego además de su asignación de variable.
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
