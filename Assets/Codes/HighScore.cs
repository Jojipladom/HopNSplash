using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;
    private float elapsedTime = 0f;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        elapsedTime += Time.deltaTime;
       
        scoreText.text = "Score: " + score;
       
    }
    
    public void IncreaseScore(int amount)
        {
            score+= amount;
         }   
        
    public void PauseGame(bool pause)
    {
        
        if (pause)
        {
            
        }
        else
        {
           
        }
    }

}
