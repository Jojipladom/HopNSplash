using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurvivalTimer : MonoBehaviour
{
    public Text survivalTimeText;
    private float survivalTime = 0f;
    private float fractionOfSecond = 0f;
    
    void Update()
    {
        if (Time.timeScale > 0)
        {
            survivalTime += Time.deltaTime;
            fractionOfSecond += Time.deltaTime;
            
            int milliseconds = (int)(fractionOfSecond * 1000) % 1000;
            UpdateTimerText(milliseconds);
          }
    }
    
    
    void UpdateTimerText(int milliseconds)
    {
        int minutes = (int)(survivalTime/60);
        int seconds = (int)(survivalTime%60);
        survivalTimeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
     }
    
    public void UpdateScore(int time)
    {
        survivalTimeText.text = time.ToString();
    }
}
