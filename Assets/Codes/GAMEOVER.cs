using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverScreenUI;
    public Button retryButton; 
    public Button toMenuButton;

    private PlayerHealth playerHealth; 

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        retryButton.onClick.AddListener(RetryGame);
        toMenuButton.onClick.AddListener(toMenu); 
    }

    void Update()
    {
        
        if (!playerHealth.isAlive || UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            DisableGameInteractions(); 
        }
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

     public void toMenu() 
        {
            
            SceneManager.LoadScene(0);
        }
   
    private void DisableGameInteractions()
    {
       
        playerHealth.canMove = false;

       
        // playerHealth.animator.enabled = false;
    }

    public void ShowGameOverScreen()
    {
        gameOverScreenUI.SetActive(true); 
        Time.timeScale = 0; 
        Debug.Log("Game Ovaaa!");
    }
    
}
