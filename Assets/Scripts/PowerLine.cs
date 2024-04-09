using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLine : MonoBehaviour
{
    public bool powered;
    public bool negateInput;
    public PowerLine[] previousLines;
    public PowerLine[] updateOnChanged;
    public Material onMat, offMat;

    public void UpdatePower()
    {
        bool check = false;
        foreach (PowerLine l in previousLines)
            if (l.powered)
                check = true;
        if(check == (powered == negateInput))
        {
            powered = check == !negateInput;
            this.GetComponent<Renderer>().material = powered ? onMat : offMat;
            foreach (PowerLine l in updateOnChanged)
                l.UpdatePower();
        }
    }

    public void TogglePower() {
        powered = !powered;
        this.GetComponent<Renderer>().material = powered ? onMat : offMat;
        foreach (PowerLine l in updateOnChanged)
            l.UpdatePower();
    }
}
