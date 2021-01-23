using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    List<Transform> wayPoints;
    WaveConfig waveConfig;
    int wayPointIndex = 0;
    void Start()
    {
        wayPoints = waveConfig.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }
    private void Move()
    {
        if (wayPoints.Count < 1) { return; }
        if (wayPointIndex <= wayPoints.Count - 1)
        {
            var targetPosition = wayPoints[wayPointIndex].transform.position;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, waveConfig.GetMoveSpeed() * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                ++wayPointIndex;
            }
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
