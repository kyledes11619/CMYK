using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFuse : MonoBehaviour
{
    public string floatPropertyName = "Transparency"; // Name of the float property in the shader
    public float decreaseRate = 0.5f; // Rate at which the float property decreases per second
    public float minValue = 0.0f; // Minimum value of the float property

    private Renderer objectRenderer;
    private MaterialPropertyBlock propertyBlock;
    private int floatPropertyID;

    void Start()
    {
        // Get the Renderer component of the object
        objectRenderer = GetComponent<Renderer>();

        // Initialize the MaterialPropertyBlock
        propertyBlock = new MaterialPropertyBlock();

        // Get the ID of the float property
        floatPropertyID = Shader.PropertyToID(floatPropertyName);
    }

    void Update()
    {
        // Decrease the float property over time
        DecreaseFloatPropertyOverTime();
    }

    void DecreaseFloatPropertyOverTime()
    {
        // Get the current value of the float property
        float currentValue = objectRenderer.sharedMaterial.GetFloat(floatPropertyID);

        // Calculate the new value of the float property
        float newValue = Mathf.Max(currentValue - decreaseRate * Time.deltaTime, minValue);

        // Set the new value of the float property
        objectRenderer.GetPropertyBlock(propertyBlock);
        propertyBlock.SetFloat(floatPropertyID, newValue);
        objectRenderer.SetPropertyBlock(propertyBlock);
    }
}