using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingNumbers : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(Camera.main.transform, Vector3.up);
    }
}
