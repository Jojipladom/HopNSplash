using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public float speed = 2f;
   
   
    void Update()
      {
       transform.Translate(Vector2.left * speed * Time.deltaTime);
       }
      
    
    private void OnTriggerEnter2D(Collider2D collision)
         {
             if (collision.CompareTag("Bullet"))
              {
                  Destroy(gameObject);
                  Destroy(collision.gameObject);
                  FindObjectOfType<HighScore>().IncreaseScore(10);
                  }
         }
}
