using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float movementSpeed = 2f;
    private HighScore scoreManager;

    void Start()
    {
    
        scoreManager = FindObjectOfType<HighScore>();
    }

    void Update()
    {
        
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            
            Destroy(gameObject);
            Destroy(collision.gameObject); 

            if (scoreManager != null)
            {
                scoreManager.IncreaseScore(10); 
            }
            else
            {
                Debug.LogError("HighScore manager is null.");
            }
        }
    }
}
