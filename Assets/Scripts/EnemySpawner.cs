using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfig;
    [SerializeField] int waveIndex = 0;
    [SerializeField] bool looping = false;


    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for( int index = waveIndex; index < waveConfig.Count; index++)
        {
            var currentWave = waveConfig[index];
            yield return StartCoroutine(SpawnEnemies(currentWave));
        }
    }

    private IEnumerator SpawnEnemies(WaveConfig currentWave)
    {
        
        for (int enemyCount = 0; enemyCount < currentWave.getNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(currentWave.getEnemyPrefab(), currentWave.getWayPoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().setWaveConfig(currentWave);

            yield return new WaitForSeconds(currentWave.getSpawnsDelay());
        }
    }
}
