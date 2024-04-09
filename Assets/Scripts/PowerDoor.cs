using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDoor : PowerLine
{
    public Vector3 openPosition, closePosition;
    public float doorSpeed;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, powered ? openPosition : closePosition, Time.deltaTime * doorSpeed);
    }
}
