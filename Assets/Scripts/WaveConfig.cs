using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy wave cofig")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    [SerializeField] float spawnRandomFactor = 0.5f;
    [SerializeField] int enemiesCount = 6;
    [SerializeField] float enemySpeed = 2f;

    public GameObject EnemyPrefab { get => enemyPrefab;}
    public float TimeBetweenSpawns { get => timeBetweenSpawns;}
    public float SpawnRandomFactor { get => spawnRandomFactor;}
    public int EnemiesCount { get => enemiesCount;}
    public float EnemySpeed { get => enemySpeed;}

    public List<Transform> getWaypoints()
    {
        var waypoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }
}
