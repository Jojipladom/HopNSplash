using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapSpawner : MonoBehaviour
{
    public int number;
    public GameObject prefab;
    public List<GameObject> TileList = new List<GameObject>(new GameObject[10]);

    
    void Start()
    {
        TileList[Random.Range(0, 9)].gameObject.SetActive(true); 
    } 
    
}
