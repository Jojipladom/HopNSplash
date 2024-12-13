using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //Gegner PREFABS(!!)
    public GameObject enemyPrefab;

    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 5f;

    private float nextSpawnTime;

    void ScheduleNextSpawn()
    {
        float interval = Random.Range(minSpawnInterval, maxSpawnInterval);
        nextSpawnTime = Time.time + interval;
    }
    void Start()
    {
        ScheduleNextSpawn();
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            ScheduleNextSpawn();
        }
    }
    
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

}
