using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WayPointsSO wayPointSO;

    List<Transform> wayPoints;

    int wayPointIndex = 0;

    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        wayPointSO = enemySpawner.GetCurrentWave();
        wayPoints = wayPointSO.GetWayPoints();
        transform.position = wayPoints[wayPointIndex].position;
    }

    void Update()
    {
        FollowWaypoint();
    }

    void FollowWaypoint()
    {
        if(wayPointIndex < wayPoints.Count) //havent reached the end
        {
            Vector3 targetPosition = wayPoints[wayPointIndex].position;//where we want to go
            float moveSpeed = wayPointSO.GetMoveSpeed() * Time.deltaTime;//speed with which we'll movw

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed);
            if(transform.position == targetPosition )//when we reach the target position we increase wayPoint Index
            {
                wayPointIndex++;
            }
        }

        else //when we reach the end
        {
            Destroy(gameObject);
        }
    }
}
