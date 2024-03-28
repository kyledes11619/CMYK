using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkSystem : MonoBehaviour
{
    public int color = 3;
    public Material[] colorMats;
    public MeshRenderer[] coloredMeshes;

    public Transform inkPoint;
    public float inkingRadius;
    public GameObject[] inkParticles;

    

    void Start()
    {
        SetColor(color);
    }

    void Update()
    {
        if (Input.GetAxis("DPadX") != 0)
            SetColor(Input.GetAxis("DPadX") == 1 ? 2 : 0);
        else if (Input.GetAxis("DPadY") != 0)
            SetColor(Input.GetAxis("DPadY") == 1 ? 1 : 3);
        if (Input.GetButtonDown("Fire1"))
        {
            Destroy(Instantiate(inkParticles[color], inkPoint), 1);
        }
    }

    void SetColor(int i)
    {
        color = i;
        foreach (MeshRenderer m in coloredMeshes)
            m.material = colorMats[color];

            
    }
}
