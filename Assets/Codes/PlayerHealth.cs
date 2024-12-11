using UnityEngine;
using UnityEngine.UI;
using System.Collections; 
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    private int currentHealth;

    public Image[] frogIcons;
    public Sprite healthyFrogSprite; 
    public Sprite damagedFrogSprite; 

    public Animator animator; 
    
    public bool canMove = true; 
    public bool isAlive = true;
    public GameOverScreen gameOverScreen;

    private bool isInvulnerable = false; 
    private float damageCooldown = 0.5f; 
    private float invulnerabilityDuration = 1f; 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateFrogs();
         
    }

    public void TakeDamage(int damage)
    {
        if (isInvulnerable || !canMove || !isAlive) return; 

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player took Blehg. Current health: " + currentHealth);
        UpdateFrogs();

        if (currentHealth <= 0)
        {
            Die();
        }

        StartCoroutine(ResetDamageFlag());
        StartCoroutine(Invulnerability());
    }

    private IEnumerator ResetDamageFlag()
    {
        yield return new WaitForSeconds(damageCooldown);
        canMove = true; 
    }

    private IEnumerator Invulnerability()
    {
        isInvulnerable = true; 
        yield return new WaitForSeconds(invulnerabilityDuration); 
        isInvulnerable = false; 
    }

    private void UpdateFrogs()
    {
        for (int i = 0; i < frogIcons.Length; i++)
        {
            if (i < currentHealth)
            {
                frogIcons[i].sprite = healthyFrogSprite;
            }
            else
            {
                frogIcons[i].sprite = damagedFrogSprite;
            }
        }
    }

    private void Die()
    {
        isAlive = false;
        Debug.Log("Player has bleh.");
        //animator.SetTrigger("Die");
        gameOverScreen.ShowGameOverScreen();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger detected with: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Enemy")) // || collision.gameObject.CompareTag("Killbox"))
        {
            Debug.Log("Taking ouchie...");
            TakeDamage(1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // || collision.gameObject.CompareTag("Killbox"))
        {
            canMove = true; 
        }
    }
     
    
}
