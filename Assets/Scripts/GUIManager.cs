using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public static GUIManager instance;
    [SerializeField] private Text coinText;
    [SerializeField] private Text distanceText;
    [SerializeField] private Text bestScoreText;
    [SerializeField] private Text gameOverScoreText;
    [SerializeField] private Text gameOverCoinText;
    private float timer;

    //-----Métodos API------
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else if(instance!=null)
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameState.inGame)
        {
            timer += Time.deltaTime;
            if (timer >= 0.2)
            {
                timer = 0;
                distanceText.text = PlayerController.Instance.GetDistance().ToString("f0");
            }
        }

    }

    //-----Métodos custom-----
    public void UpdateCoinText()
    {
        coinText.text = GameManager.Instance.CollectedCoins.ToString();
    }

    public void UpdateGameOverCoinText()
    {
        gameOverCoinText.text = GameManager.Instance.CollectedCoins.ToString("f0");
    }

    public void UpdateGameOverScoreText()
    {
        gameOverScoreText.text = PlayerController.Instance.GetDistance().ToString("f0");
    }

    public void UpdateBestScoreText()
    {
        bestScoreText.text = PlayerPrefs.GetFloat("Highscore").ToString("f0");
    }

    
}
