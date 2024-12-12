using System;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{

    public GameObject groundPrefab;
    private Vector3 nextTileSpawnPos;
    public GameObject player;
    private float targetposition = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        nextTileSpawnPos = new Vector3(-57.82f, -4.28f, 0f);
        SpawnTile();
    }


    private void Update()
    
    {
        if (player.transform.position.x > targetposition)
        {
            targetposition += 120f;
            SpawnTile();
        }
    }


    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundPrefab, nextTileSpawnPos, Quaternion.identity);
        nextTileSpawnPos += new Vector3(120f, 0f, 0f);
    }
}
