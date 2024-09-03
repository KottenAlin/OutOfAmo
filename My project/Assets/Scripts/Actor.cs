
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    int currentHealth;
    public int maxHealth = 10;

    public Rigidbody rb;

    public float speed = 10f;
    

    void Awake()
    {
        maxHealth = 10;
        speed = 10f;
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        
    }

    public void TakeDamage(int amount, Vector3 direction)
    {
        currentHealth -= amount;

        Debug.Log("Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Death();
        }
        else
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
            rb.velocity = speed * direction;
            }
        }

        if(currentHealth <= 0)
        { Death(); }
    }

    void Death()
    {
        // Death function
        // TEMPORARY: Destroy Object
        Destroy(gameObject);
    }
}
