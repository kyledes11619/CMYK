using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSwitch : MonoBehaviour
{
    public BlockActivatedPlatform platform;
    PushableBlock block = null;
    public float closeDistance = .5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<PushableBlock>() != null)
        {
            block = collision.collider.gameObject.GetComponent<PushableBlock>();
            platform.CheckForDone();
        }
    }

    public bool Check()
    {
        if (block == null)
            return false;
        if (Vector3.Distance(transform.position, block.transform.position) <= closeDistance)
            return true;
        return false;
    }
}
