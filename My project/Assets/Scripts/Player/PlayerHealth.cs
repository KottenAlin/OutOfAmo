using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public Image hurtEffect;

    public TextMeshProUGUI HealthBar;

    public GameObject TakeDamageEffect;
    
    public GameOverScreen gameOverScreen;

    void Awake()
    {
        currentHealth = maxHealth;
    }
    // Start is called before the first frame update
    public void TakeDamage(int damage) // This function will be called from other scripts
    {
        Debug.Log("Player took damage");
        TakeDamageEffect.SetActive(true);
        hurtEffect.color = new Color(1, 0, 0, 0.5f); // Set the color of the hurt effect to red
        currentHealth -= damage;
        HealthBar.text = currentHealth.ToString(); // Update the health bar text
        if(currentHealth <= 0)
        {
            Die();
        }

    }
    void Die()
    {
        TakeDamageEffect.SetActive(false);
        gameOverScreen.Death(); // Call the Death function from the GameOverScreen script
    }

    // Update is called once per frame
    void Update()
    {
        float opacity = Mathf.Lerp(hurtEffect.color.a, 0, Time.deltaTime * 2);
        hurtEffect.color = new Color(1, 0, 0, opacity);
        
        if (opacity <= 0.05f)
        {
            TakeDamageEffect.SetActive(false);
        }
    }
}
