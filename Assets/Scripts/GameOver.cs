using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("Magenta_World");
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}