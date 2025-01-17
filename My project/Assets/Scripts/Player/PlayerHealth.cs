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
       
        HealthBar = GameObject.Find("HealthBar").GetComponent<TextMeshProUGUI>();
        hurtEffect = GameObject.Find("Hurt").GetComponent<Image>();
        TakeDamageEffect = GameObject.Find("Hurt");
        //gameOverScreen = GameObject.Find("Canvas_TimerAndDeath").GetComponent<GameOverScreen>();
        
       
    }
    // Start is called before the first frame update
    public void TakeDamage(int damage) // This function will be called from other scripts
    {
        Debug.Log("Player took damage");
        TakeDamageEffect.SetActive(true);
        hurtEffect.color = new Color(1, 0, 0, 0.5f); // Set the color of the hurt effect to red
        currentHealth -= damage;
        if (currentHealth < 0) // If the health is less than 0, set it to 0
        {
            currentHealth = 0;
        }
        if(currentHealth <= 0)
        {
            Die();
        }
        HealthBar.text = currentHealth.ToString(); // Update the health bar text
        

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
