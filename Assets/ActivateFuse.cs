using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFuse : MonoBehaviour
{
    public float lowerSpeed = 0.1f;
    public float lowerValueLimit = 0f;
    public float delayBeforeActivatingFuse = 1f;
    public string floatPropertyName = "Transparency";
    public string boolPropertyName = "IsFuseActive";
    private float currentValue;

    private Material material;
    
    private bool isFuseActive = false;

    private void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
            currentValue = material.GetFloat(floatPropertyName);
        }
        else
        {
            Debug.LogError("Renderer component not found.");
        }
    }

    private void Update()
    {
        // Lower the value gradually if the fuse is not yet activated and the value is above the limit
        if (!isFuseActive && currentValue > lowerValueLimit)
        {
            currentValue -= lowerSpeed * Time.deltaTime;
            // You may want to clamp the value to the lower limit here if necessary
            // currentValue = Mathf.Max(currentValue, lowerValueLimit);
            material.SetFloat(floatPropertyName, currentValue);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the same object
        if (collision.gameObject == gameObject)
        {
            // Activate the fuse after a delay
            Invoke("ActivateFuse", delayBeforeActivatingFuse);
        }
    }

    private void ActivateFuse()
    {
        isFuseActive = true;
        material.SetFloat(boolPropertyName, isFuseActive ? 1.0f : 0.0f);
    }

}