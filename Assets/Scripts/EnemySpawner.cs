using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] int startWave = 0;
    [SerializeField] bool loopedWaves = true;

    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(startWaves());
        } while (loopedWaves);
    }

    private IEnumerator startWaves ()
    {
        for(var i = 0; i < waveConfigs.Count; i++)
        {
            var currentWave = waveConfigs[i];

            yield return StartCoroutine(spawnEnemies(currentWave));
        }
    }

    private IEnumerator spawnEnemies (WaveConfig wave)
    {
        for (int i = 0; i < wave.EnemiesCount; i++)
        { 
            var newEnemy = Instantiate(wave.EnemyPrefab, wave.getWaypoints()[0].position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPath>().setWaveConfig(wave);

            yield return new WaitForSeconds(wave.TimeBetweenSpawns);
        }
    }
}
