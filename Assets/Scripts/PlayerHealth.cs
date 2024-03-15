using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    private void Awake()
    {
        Instance = this;
    }

    public int health, maxHealth;
    public Text healthText;

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = "Health " + health + "/" + maxHealth;
    }
}
