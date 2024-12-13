using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public GameObject gameOverScreenUI;
    public Button retryButton; 
    public Button toMenuButton;

    private PlayerHealth playerHealth; 

    private void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
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
        MusicManager.Instance.SetVolume(1);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

     public void toMenu() 
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0);
            MusicManager.Instance.SetVolume(1);
        }
   
    private void DisableGameInteractions()
    {
       
        playerHealth.canMove = false;

       
       
    }

    public void ShowGameOverScreen()
    {
        MusicManager.Instance.SetVolume(0);
        ShowCursor();
        gameOverScreenUI.SetActive(true); 
        Time.timeScale = 0; 
        Debug.Log("Game Ovaaa!");
    }
    
}
