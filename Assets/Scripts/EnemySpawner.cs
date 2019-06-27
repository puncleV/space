using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startWave = 0;
    int currentWaveIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentWaveIndex = startWave;
        StartCoroutine(startWaves());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator startWaves ()
    {
        while(true)
        {
            var currentWave = waveConfigs[currentWaveIndex];

            yield return StartCoroutine(spawnEnemies(currentWave));

            currentWaveIndex = (currentWaveIndex == waveConfigs.Count - 1) ? 0 : currentWaveIndex + 1;
        }
    }

    private IEnumerator spawnEnemies (WaveConfig wave)
    {
        var currentWave = waveConfigs[currentWaveIndex];

        for (int i = 0; i < wave.EnemiesCount; i++)
        { 
            var newEnemy = Instantiate(wave.EnemyPrefab, wave.getWaypoints()[0].position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPath>().setWaveConfig(currentWave);

            yield return new WaitForSeconds(wave.TimeBetweenSpawns);
        }
    }
}
