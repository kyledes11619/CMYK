using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PowerlineText : PowerLine
{
    public TextMeshPro tmp;
    public string onText, offText;

    public new void UpdatePower()
    {
        bool check = false;
        foreach (PowerLine l in previousLines)
            if (l.powered)
                check = true;
        if (check == (powered == negateInput))
        {
            powered = check == !negateInput;
            this.GetComponent<Renderer>().material = powered ? onMat : offMat;
            foreach (PowerLine l in updateOnChanged)
                l.UpdatePower();
        }
        tmp.text = powered ? onText : offText;
    }

    public new void TogglePower()
    {
        powered = !powered;
        this.GetComponent<Renderer>().material = powered ? onMat : offMat;
        foreach (PowerLine l in updateOnChanged)
            l.UpdatePower();
        tmp.text = powered ? onText : offText;
    }
}
