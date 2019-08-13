using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{ 
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
        SceneManager.LoadScene("Game Over");
    }

    public void quit()
    {
        Application.Quit();
    }
}
