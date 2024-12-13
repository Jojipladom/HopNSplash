using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameSpeedManager : MonoBehaviour
{
    public float speedIncreaseInterval = 240f;

    public float speedMultiplier = 0.1f;

    public float maxSpeedMultiplier = 3f;

    private float nextIncreaseTime;

    void Awake()
    {
        Time.timeScale = 1.0f;
    }
    void Start()
    {
        Time.timeScale = 1f;
        nextIncreaseTime = Time.time + speedIncreaseInterval;
    }

    void IncreaseGameSpeed()
    {
        Time.timeScale = Mathf.Min(Time.timeScale + speedMultiplier, maxSpeedMultiplier);
        Debug.Log("Geht danke");
    }
    void Update()
    {
        if (Time.time >= nextIncreaseTime)
        {
            IncreaseGameSpeed();
            nextIncreaseTime = Time.time + speedIncreaseInterval;
        }
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
