using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    public int health, maxHealth;
    public Text healthText;
    public Image healthBar;
    public GameObject gameOverScreen;
    

    
    
    
    private void Awake()
    {
        Instance = this;
    }

   

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthText.text = "Health " + health + "/" + maxHealth;

        if (health <= 0)
    {
       GameOver();// Call the GameOver method when health reaches 0 or below
    }

     HealthBarFiller(damage);
    
    }
    


    private void GameOver()
    {
      
        // Show the game over screen
        gameOverScreen.SetActive(true);
        // Optionally, you may want to freeze the game or take other actions
        Time.timeScale = 0f; // This freezes the game
    }

    
    //testing health bar
    
    float lerpSpeed;

   

    private void Update()
    {
       

        lerpSpeed = 3f * Time.deltaTime;

        
        ColorChanger();
    }

    void HealthBarFiller(int damage)
{
    // Define the amount by which the fill amount decreases for each point of damage (1/5 ratio)
    float decreasePerDamage = 0.2f;

    // Calculate the target fill amount after taking damage
    float targetFillAmount = Mathf.Clamp(healthBar.fillAmount - (decreasePerDamage * damage), 0f, 1f);

    // Smoothly interpolate towards the target fill amount
    healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, targetFillAmount, lerpSpeed * Time.deltaTime);
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

   
    
}
