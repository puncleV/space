using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath : MonoBehaviour
{
    [SerializeField] List<GameObject> waypoints;
    [SerializeField] float speed = 1f;

    [SerializeField]  int targetWaypointIndex = 0;

    private void Start()
    {
        transform.position = waypoints[targetWaypointIndex].transform.position; 
    }

    private void Update()
    {
        Vector2 targetPosition = waypoints[targetWaypointIndex].transform.position;

        if (Vector2.Distance(transform.position, targetPosition) < 0.05)
        {
            if (targetWaypointIndex == (waypoints.Count - 1))
            {
                Destroy(gameObject);
            } else
            {
                targetWaypointIndex++;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
