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
        // Check if the colliding object is the Player
        if (other.CompareTag("Player"))
        {


            // Display the GameOver canvas
            if (gameOverCanvas != null)
            {
                gameOverCanvas.SetActive(true);
            }
        }
    }
}