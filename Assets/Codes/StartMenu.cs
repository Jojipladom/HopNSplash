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
}
