using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP_DebugGetInk : MonoBehaviour
{
    public InkSystem other;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("0"))
        {
            other.UnlockAllColors();
        }
    }
}
