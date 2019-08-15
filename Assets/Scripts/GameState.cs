using System;
using UnityEngine;
using UnityEngine.UI;
public class GameState : MonoBehaviour
{
    private int points = 0;
    [SerializeField] Text scoreText;
    private void Awake()
    {
        SetUpSingleton();
    }

    private void Start()
    {
        scoreText.text = points.ToString();
    }

    private void SetUpSingleton()
    {
        var instancesCount = FindObjectsOfType(GetType()).Length;

        if (instancesCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    public void reset()
    {
        points = 0;
    }

    public void addPoints(int points)
    {
        this.points += points;
        scoreText.text = this.points.ToString();
    }
}
