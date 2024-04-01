using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }

    public void PlayButton()
    {
        SceneManager.LoadScene( "Magenta_World");
        Time.timeScale = 1.0f;

    }

    public void GoToMenu() {
        SceneManager.LoadScene( "Menu");
    }

    public void Retry() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}