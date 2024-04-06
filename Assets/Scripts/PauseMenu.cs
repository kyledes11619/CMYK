using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioSource musicSource;

    private void Update()
    {
        // Check for the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Options") )
        {
            if (GameIsPaused)
            {    
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void ToggleCursorVisibility(bool visible)
    {
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = visible;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        ToggleCursorVisibility(true);
        // Pause the music
        if (musicSource != null)
        {
            musicSource.Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        ToggleCursorVisibility(false);
        // Resume the music
        if (musicSource != null)
        {
            musicSource.Play();
        }
    }

    public void LoadMenu()
    {
    Time.timeScale = 1f; // Set time scale back to normal before loading the menu
    GameIsPaused = false; // Reset the pause state
    ToggleCursorVisibility(true); // Unlock the cursor and make it visible
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}