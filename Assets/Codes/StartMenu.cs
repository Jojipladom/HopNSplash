using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
   
    public void StartGame()
    {
        SceneManager.LoadScene("Level");
    }
    
    
    public void Quit()
    {
        Debug.Log("Quitting");
        Application.Quit();
    }
    
    
    public void LoadOptionsMenu()
        {
        SceneManager.LoadScene("Optionsmenu");
        }
    
    private void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    private void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}


