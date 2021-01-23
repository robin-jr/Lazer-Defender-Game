using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float spawnTime = 1f;
    [SerializeField] float spawnRandomness = 0.3f;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }
    public List<Transform> GetWayPoints()
    {
        var wayPoints = new List<Transform>();
        foreach (Transform item in pathPrefab.transform)
        {
            wayPoints.Add(item);
        }
        return wayPoints;
    }
    public int GetNumberOfEnemies() { return numberOfEnemies; }
    public float GetMoveSpeed() { return moveSpeed; }
    public float GetSpawnTime() { return spawnTime; }
    public float GetSpawnRandomness() { return spawnRandomness; }


}
