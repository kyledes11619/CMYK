using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBlock : InkInteraction
{
    public float pushPower;
    public int color;
    Vector3 goal;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (inkTimer > 0)
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, goal, pushPower * Time.deltaTime * inkCooldown));
            inkTimer -= Time.deltaTime;
        }
    }

    public override void Ink(int color)
    {
        Debug.Log(this.color + ":" + color);
        if(inkTimer <= 0 && this.color == color)
        {
            Vector3 t = transform.position - PlayerHealth.Instance.transform.position;
            t.y = 0;
            goal = transform.position + (pushPower * Vector3.Normalize(t));
            inkTimer = inkCooldown;
        }
    }
}
