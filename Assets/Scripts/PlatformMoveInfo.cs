using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoveInfo : MonoBehaviour
{
    Vector3 lastPos;

    public void becomeParented()
    {
        lastPos = transform.position;
    }

    public Vector3 getPosDiff()
    {
        Vector3 diff = transform.position - lastPos;
        lastPos = transform.position;
        return diff;
    }
}
