using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameObject winCanvas;
    public static bool GameIsPaused = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            winCanvas.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void ToggleCursorVisibility(bool visible)
    {
        Cursor.lockState = visible ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = visible;
    }
    
   }

