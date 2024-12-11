using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public PlayerInput menuInputActions;
    public GameObject pauseMenuObject;
    public GameObject resumeButton;
    public GameObject OptionsScreen;
    private PlayerController playerController;
    private HighScore highScore;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        highScore = FindObjectOfType<HighScore>();

        if (playerController == null)
        {
            Debug.LogError("PlayerController not found");
        }

        if (highScore == null)
        {
            Debug.LogError("HighScore not found");
        }

        
        if (menuInputActions != null)
        {
            menuInputActions.currentActionMap.FindAction("Pause").performed += OnPaused;
        }
        else
        {
            Debug.LogError("menuInputActions noh");
        }
  }

    public void OnPaused(InputAction.CallbackContext context)
    {
        TogglePause();
    }

    public void TogglePause()
    {
        bool paused = pauseMenuObject.activeSelf;

        pauseMenuObject.SetActive(!paused);

        if (!paused)
        {
            
            Time.timeScale = 0;

           
            if (playerController != null)
            {
                playerController.CanMove = false;
            }

            
            if (highScore != null)
            {
                highScore.PauseGame(true);
            }
        }
        else
        {
            
            Time.timeScale = 1;

           
            if (playerController != null)
            {
                playerController.CanMove = true;
                
            }

            if (highScore != null)
            {
                highScore.PauseGame(false);
            }
        }


        OptionsScreen.SetActive(false);
    }

    public void ToMenu()
    {
        TogglePause();
        SceneManager.LoadScene(0);
    }

    public void ToggleOptions()
    {
        bool options = OptionsScreen.activeSelf;
        pauseMenuObject.SetActive(!options);

        
        OptionsScreen.SetActive(!options);
    }
}
