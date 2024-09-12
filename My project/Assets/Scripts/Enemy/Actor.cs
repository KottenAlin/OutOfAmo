
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    int currentHealth;
    public int maxHealth = 10;
    public string TriggerName = "";
    public Rigidbody rb;
    private Animator mAnimator;
    public float speed = 10f;
    

    void Awake()
    {
        mAnimator = GetComponent<Animator>();
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
        if(TriggerName != ""){
            if(mAnimator != null){
                mAnimator.SetTrigger(TriggerName); // activates death-animation for Gameobject
            }
        }
        else{
            Destroy(gameObject);
        }
    }
}
