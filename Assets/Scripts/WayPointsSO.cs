using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New WayPoint", menuName ="Waypoint")]
public class WayPointsSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] float moveSpeed;

    [SerializeField] Transform wayPointsPrefab;

    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float timeVariance = 0.5f;
    [SerializeField] float minTime = 0.2f;


    public Transform GetStartingWaypoint()
    {
        return wayPointsPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        List<Transform> wayPoints = new List<Transform>();

        foreach (Transform child in wayPointsPrefab)
        {
            wayPoints.Add(child);
        }

        return wayPoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public int GetEnemyCount()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public float GetRandomSpawnTime()
    {
        float minSpawnTime = timeBetweenSpawns - timeVariance;
        float maxSpawnTime = timeBetweenSpawns + timeVariance;
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

        Mathf.Clamp(spawnTime, minTime, maxSpawnTime);

        return spawnTime;
    }
}
