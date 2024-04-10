using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void RetryGame()
    {
        //CleanupScene();
         Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        Time.timeScale = 1.0f;
    }

    public void QuitGame()
    {
        //CleanupScene();
        SceneManager.LoadScene("Menu");
    }

    //private void CleanupScene()
        //foreach (var explosion in GameObject.FindGameObjectsWithTag("Explosion"))
        //{
            //Destroy(explosion);
        //}

}