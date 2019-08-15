using UnityEngine;
public class GameState : MonoBehaviour
{
    private int points;
    private void Awake()
    {
        SetUpSingleton();
    }

    private void Start()
    {
        points = 0;
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
        Destroy(gameObject);
    }

    public void addPoints(int points)
    {
        this.points += points;
    }

    public int getScore()
    {
        return points;
    }
}
