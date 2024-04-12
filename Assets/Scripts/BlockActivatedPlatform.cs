using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockActivatedPlatform : MonoBehaviour
{
    public BlockSwitch[] requiredSwitches;
    public bool activated, moveDir;
    public float moveSpeed;
    public Vector3 point1, point2;

    private void Update()
    {
        if (activated) {
            if(Vector3.Distance(transform.position, moveDir ? point1 : point2) < .01f)
                moveDir = !moveDir;
            transform.position = Vector3.MoveTowards(transform.position, moveDir ? point1 : point2, moveSpeed * Time.deltaTime);
        }
    }

    public void CheckForDone()
    {
        foreach (BlockSwitch sw in requiredSwitches)
            if (!sw.Check())
                return;
        activated = true;
    }
}
