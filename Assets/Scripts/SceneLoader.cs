using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float gameOverDelay = 1f;
    public void mainMenu()
    {
        FindObjectOfType<GameState>().reset();
        SceneManager.LoadScene("Main Menu");
    }

    public void game()
    {
        var gameState = FindObjectOfType<GameState>();
        if (gameState)
        {
            gameState.reset();
        }
        SceneManager.LoadScene("Game");
    }
    
    public void gameOver()
    {
        StartCoroutine(loadGameOver());
    }

    private IEnumerator loadGameOver()
    {
        yield return new WaitForSeconds(gameOverDelay);
        SceneManager.LoadScene("Game Over");
    }

    public void quit()
    {
        Application.Quit();
    }
}
