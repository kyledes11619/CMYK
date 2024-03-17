using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;

public class Torch : InkInteraction
{
    public bool lit;
    public float timer = 10;
    public TextMesh text;
    public GameObject particles, disableOnFinish;
    float timerLength;

    private void Start()
    {
        timerLength = timer;
    }
    public override bool canInk() {
        return !lit;
    }

    public override void Ink(int color)
    {
        if (color != 1)
            return;
        text.gameObject.SetActive(true);
        particles.SetActive(true);
        lit = true;
        Enemy[] enemies = GameObject.FindObjectsOfType<Enemy>();
        foreach (Enemy enemy in enemies)
        {
            enemy.AttractToTarget(transform);
        }
    }

    private void Update()
    {
        if(lit && timer > 0)
        {
            timer -= Time.deltaTime;
            text.text = "" + ((int)timer + 1);
            if (timer <= 0)
            {
                text.gameObject.SetActive(false);
                disableOnFinish.SetActive(false);
            }
        }
    }

    public void Snuff()
    {
        lit = false;
        timer = timerLength;
        particles.SetActive(false);
        text.gameObject.SetActive(false);
        text.text = "" + (int)timer;
    }
}
