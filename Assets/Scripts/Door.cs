using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public GameObject winCanvas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            winCanvas.SetActive(true);
        }
    }
}