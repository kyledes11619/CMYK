using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform startPoint; // Starting point of the movement
    public Transform endPoint; // Ending point of the movement
    public float speed = 2.0f; // Movement speed

    private float startTime; // Time when movement started
    private float journeyLength; // Total distance between start and end points

    void Start()
    {
        // Calculate the total distance between start and end points
        journeyLength = Vector3.Distance(startPoint.position, endPoint.position);
        startTime = Time.time; // Record the start time
    }

    void Update()
    {
        // Calculate the fraction of journey completed
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;

        // Move the platform using a sinusoidal motion (back and forth)
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, Mathf.PingPong(fracJourney, 1));
    }
}

