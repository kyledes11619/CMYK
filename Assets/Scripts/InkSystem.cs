using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InkSystem : MonoBehaviour
{
    public static bool[] unlockedColors = { false, false, false, true };
    public static bool invincible, hard;

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
        if (Input.GetAxis("DPadX") > 0)
            SetColor(2);
        else if (Input.GetAxis("DPadX") < 0)
            SetColor(0);
        else if (Input.GetAxis("DPadY") > 0)
            SetColor(1);
        else if (Input.GetAxis("DPadY") < 0)
            SetColor(3);
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
        {
            UnlockColor(i);
            colorIcons[i].SetActive(true);
        }
    }

    public void ResetAllColors()
    {
        for (int i = 0; i < 3; i++)
        {
            unlockedColors[i] = false;
            if (freeColorForLevel != i)
                colorIcons[i].SetActive(false);
        }
    }

    public void UnlockLevelColor()
    {
        UnlockColor(freeColorForLevel);
    }

    public void SetHard(bool b)
    {
        hard = b;
    }

    public void SetInvincible(bool b)
    {
        invincible = b;
    }
}
