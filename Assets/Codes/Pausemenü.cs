using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public PlayerInput playerInputActions;
    public PlayerInput menuInputActions;
    public GameObject pauseMenuObject;
    public GameObject resumeButton;
    public GameObject OptionsScreen;

    IDisposable onAnyEvent;

    private void Awake() {
        onAnyEvent = InputSystem.onAnyButtonPress.Call(OnAnyButtonPress);
    }

    private void OnDestroy() {
        onAnyEvent.Dispose();
    }

    private void OnAnyButtonPress(InputControl control) {
        if(control.device.name.Contains("Mouse"))
            return;

        if(pauseMenuObject.activeSelf) {
            GameObject selected = EventSystem.current.currentSelectedGameObject;
            if(selected == null) {
                EventSystem.current.SetSelectedGameObject(resumeButton);
            }
        }
    }

    void OnEnable() {
        menuInputActions.currentActionMap.FindAction("Pause").performed += OnPaused;
    }

    private void OnDisable() {
        menuInputActions.currentActionMap.FindAction("Pause").performed -= OnPaused;
    }

    public void OnPaused(InputAction.CallbackContext context) {
        TogglePause();
    }

    public void TogglePause() 
    {
        bool paused = pauseMenuObject.activeSelf;

        pauseMenuObject.SetActive(!paused); 
    }
    public void ToMenu() 
    {
        TogglePause();
        SceneManager.LoadScene(0);
    }

    public void ToggleOptions()
    {
        bool options = OptionsScreen.activeSelf;
        
        OptionsScreen.SetActive(!options);
    }
}