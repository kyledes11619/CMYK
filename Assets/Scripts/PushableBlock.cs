using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBlock : InkInteraction
{
    public float pushPower;
    public int color;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public override void Ink(int color)
    {
        Debug.Log(this.color + ":" + color);
        if(inkTimer <= 0 && this.color == color)
        {
            Vector3 t = transform.position - PlayerHealth.Instance.transform.position;
            t.y = 0;
            rb.AddForce(transform.position + (pushPower * Vector3.Normalize(t)));
            inkTimer = inkCooldown;
        }
    }
}
