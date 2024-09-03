using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public GameOverScreen gameOverScreen;

    void Awake()
    {
        currentHealth = maxHealth;
    }
    // Start is called before the first frame update
    public void TakeDamage(int damage) // This function will be called from other scripts
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        gameOverScreen.Death(); // Call the Death function from the GameOverScreen script
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
