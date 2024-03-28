using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Text healthText;
    public Image healthBar;

    float health, maxHealth = 5;
    float lerpSpeed;

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        healthText.text = "Health: " + health + "";
        if (health > maxHealth) health = maxHealth;

        lerpSpeed = 3f * Time.deltaTime;

        HealthBarFiller();
        ColorChanger();
    }

    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
    }

    void ColorChanger()
    {
        // Define cyan, yellow, and magenta colors
        Color cyanColor = new Color(0, 1, 1); // Cyan color
        Color yellowColor = new Color(1, 1, 0); // Yellow color
        Color magentaColor = new Color(1, 0, 1); // Magenta color

        // Determine which color to lerp between based on health percentage
        Color targetColor;
        if (health >= maxHealth * 0.66f)
            targetColor = cyanColor; // Above 66% health, lerp towards cyan
        else if (health >= maxHealth * 0.33f)
            targetColor = yellowColor; // Between 33% and 66% health, lerp towards yellow
        else
            targetColor = magentaColor; // Below 33% health, lerp towards magenta

        // Smoothly lerp the health bar color towards the target color
        healthBar.color = Color.Lerp(healthBar.color, targetColor, lerpSpeed);
    }

    public void Damage(float damagePoints)
    {
        if (health > 0)
            health -= damagePoints;
    }
    public void Heal(float healingPoints)
    {
        if (health < maxHealth)
            health += healingPoints;

    }
}