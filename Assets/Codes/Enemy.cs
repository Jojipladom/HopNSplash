using UnityEngine;

public class Enemy : MonoBehaviour
{
   private float movementSpeed = 2f;
   
   
   private void MoveEnemy()
   {
       transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
   }
   
    void Update()
      {
          //wie schnell die enemies laufen & links
         MoveEnemy();
       }
      
    
    private void OnTriggerEnter2D(Collider2D collision)
         {
             if (collision.CompareTag("Bubbles")) 
             {
                 //wenn von den bubbles.. oder bullets getroffen -> Punkte & Verschwinden vom Game
                  Destroy(gameObject);
                  Destroy(collision.gameObject);
                  Debug.Log("enemy bleh");
                  
                  //10Punkte für Score
                  FindObjectOfType<HighScore>().IncreaseScore(10);
                  
             }
             
         }
    
}
