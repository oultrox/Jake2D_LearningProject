using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {
    public static GUIManager instance;
    [SerializeField] private Text coinText;
    [SerializeField] private Text distanceText;
    private float timer;
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

    public void UpdateCoinText()
    {
        coinText.text = GameManager.Instance.CollectedCoins.ToString();
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
}
