using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //Gegner PREFABS(!!)
    public GameObject enemyPrefab;
    
    //Wo die spawnen werden
    public Transform spawnPoint;
    
    //Respawn Zeit
    public float spawnInterval = 2f;
    
    
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, spawnInterval);
    }

    
    void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnPoint == null)
        {
            Debug.LogError("Missing prefab oder spawn point.");
            return;
        }
        Vector3 randomOffset = new Vector3(Random.Range(-2f, 2f), 0, 0);
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

}
