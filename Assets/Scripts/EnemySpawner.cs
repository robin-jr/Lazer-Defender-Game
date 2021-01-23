using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = true;
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnEnemies());
        } while (looping);

    }

    private IEnumerator SpawnEnemies()
    {
        foreach (WaveConfig item in waveConfigs)
        {
            yield return StartCoroutine(SpawnAllEnemiesInWave(item));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for (int i = 0; i < waveConfig.GetNumberOfEnemies(); i++)
        {
            Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWayPoints()[0].transform.position, Quaternion.identity).GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetSpawnTime());

        }
    }


}
