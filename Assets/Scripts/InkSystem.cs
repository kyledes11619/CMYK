using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkSystem : MonoBehaviour
{
    public static bool[] unlockedColors = { false, false, false, true };

    public int color = 3;
    public Material[] colorMats;
    public SkinnedMeshRenderer[] coloredMeshes;
    public Transform inkPoint;
    public float inkingRadius;
    public GameObject[] inkParticles;
    public int freeColorForLevel = 3;
    public GameObject[] colorIcons;

    void Start()
    {
        SetColor(color);
        for (int i = 0; i < 3; i++)
        {
            colorIcons[i].SetActive(i == freeColorForLevel || unlockedColors[i]);
        }
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
        if (!unlockedColors[i] && freeColorForLevel != i)
            return;
        color = i;
        foreach (SkinnedMeshRenderer m in coloredMeshes)
            m.material = colorMats[color];       
    }

    public void UnlockColor(int i)
    {
        unlockedColors[i] = true;
    }

    public void UnlockAllColors()
    {
        for (int i = 0; i < 3; i++)
            UnlockColor(i);
    }

    public void ResetAllColors()
    {
        for (int i = 0; i < 3; i++)
            UnlockColor(i);
    }

    public void UnlockLevelColor()
    {
        UnlockColor(freeColorForLevel);
    }
}
