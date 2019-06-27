using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] int targetWaypointIndex = 0;

    WaveConfig waveConfig;
    List<Transform> waypoints;

    public void setWaveConfig (WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Start()
    {
        waypoints = waveConfig.getWaypoints();
        transform.position = waypoints[targetWaypointIndex].position; 
    }

    private void Update()
    {
        move();
    }

    private void move()
    {
        Vector2 targetPosition = waypoints[targetWaypointIndex].position;

        if (transform.position.Equals(targetPosition))
        {
            if (targetWaypointIndex == (waypoints.Count - 1))
            {
                Destroy(gameObject);
            }
            else
            {
                targetWaypointIndex++;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, waveConfig.EnemySpeed * Time.deltaTime);
    }
}
