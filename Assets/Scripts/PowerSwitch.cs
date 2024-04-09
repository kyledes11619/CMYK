using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSwitch : InkInteraction
{
    public int color;
    public PowerLine line;

    public override void Ink(int color)
    {
        Debug.Log(this.color + ":" + color);
        if (inkTimer <= 0 && this.color == color)
        {
            line.TogglePower();
            inkTimer = inkCooldown;
        }
    }
}
