using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startWave = 0;
    int currentWaveIndex;
    Coroutine spawnCoroutine = null;
    // Start is called before the first frame update
    void Start()
    {
        currentWaveIndex = startWave;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(spawnEnemies());
        }
    }

    private IEnumerator spawnEnemies ()
    {
        var currentWave = waveConfigs[currentWaveIndex];

        for (int i = 0; i < currentWave.EnemiesCount; i++)
        { 
            var newEnemy = Instantiate(currentWave.EnemyPrefab, currentWave.getWaypoints()[0].position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPath>().setWaveConfig(currentWave);

            yield return new WaitForSeconds(currentWave.TimeBetweenSpawns);
        }

        currentWaveIndex = (currentWaveIndex == waveConfigs.Count - 1) ? 0 : currentWaveIndex + 1;

        StopCoroutine(spawnCoroutine);
        spawnCoroutine = null;
    }
}
