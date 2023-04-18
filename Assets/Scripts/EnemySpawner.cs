using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WayPointsSO> wayPoints;
    WayPointsSO currentWave;
    [SerializeField] float timeForNextWave = 1f;

    [SerializeField] bool islooping = true;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WayPointsSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WayPointsSO wayPoint in wayPoints)
            {
                currentWave = wayPoint;

                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStartingWaypoint().position, Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeForNextWave);

            }
        }
        while(islooping);
        
    }
    
}
