using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingNumbers : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(transform.position + transform.position - Camera.main.transform.position, Vector3.up);
    }
}
