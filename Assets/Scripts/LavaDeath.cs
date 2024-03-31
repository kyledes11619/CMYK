using UnityEngine;

public class LavaDeath : MonoBehaviour
{
    // Reference to the GameOver Canvas
    public GameObject gameOverCanvas;

    void Start()
    {
        // Ensure the GameOver canvas is disabled on start
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {


            
            if (gameOverCanvas != null)
            {
                gameOverCanvas.SetActive(true);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
}