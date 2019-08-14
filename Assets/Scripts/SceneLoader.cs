using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float gameOverDelay = 1f;
    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");

    }

    public void game()
    {
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
