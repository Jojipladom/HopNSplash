using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
   public float scrollSpeed = 0.5f;
   private Vector2 startPos;
   
    void Start()
    {
        startPos = transform.position;
    }

    
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, transform.localScale.x);
        transform.position = startPos + Vector2.left * newPos;
    }
}
