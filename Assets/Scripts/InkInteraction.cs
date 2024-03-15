using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkInteraction : MonoBehaviour
{
    public float inkTimer = 0, inkCooldown = .5f;

    private void Update()
    {
        if (inkTimer > 0)
            inkTimer -= Time.deltaTime;
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("hit" + inkTimer);
        if (inkTimer > 0)
            return;
        inkTimer += inkCooldown;
        if (other.GetComponent<InkParticle>() != null)
            Ink(other.GetComponent<InkParticle>().color);
    }

    public virtual void Ink(int color)
    {

    }
}
