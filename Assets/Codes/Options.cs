using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider musicVolumeSlider;
    //Dropdown resolutionDropdown;
    
    void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
        
        
        masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
        sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    
    public void SetMasterVolume (float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
    }
  public void SetSFXVolume (float volume)
     {
        // musicAudioSource.volume = volume;
         AudioListener.volume = volume;
         PlayerPrefs.SetFloat("SFXVolume", volume);
     }
     
   public void SetMusicVolume (float volume)
      {
         // musicAudioSource.volume = volume;
          AudioListener.volume = volume;
          PlayerPrefs.SetFloat("MusicVolume", volume);
      }
    
    public void SaveSettings()
        {
            
            PlayerPrefs.Save();
        }
        
    public void CancelSettings()
            {
                
                masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
                sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1.0f);
                musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1.0f);
                
            }
            
    public void LoadMainMenu()
       { 
        SceneManager.LoadScene("StartMenu");
        }
}
