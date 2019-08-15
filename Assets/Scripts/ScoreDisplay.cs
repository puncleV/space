using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private Text scoreText; 
    private GameState gameState; 
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        gameState = FindObjectOfType<GameState>();
        scoreText.text = gameState.getScore().ToString();
    }

    private void Update()
    {
        scoreText.text = gameState.getScore().ToString();
    }
}
