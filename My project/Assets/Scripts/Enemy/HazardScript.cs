

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardScript : MonoBehaviour
{
    
    public PlayerHealth playerHealth;
    public CapsuleCollider playerCollider;
    public BoxCollider hazardCollider;

    public float damageInterval;

    public int damage = 10;
    private float nextDamageTime = 0f;

    void Awake()
    {
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        playerCollider = GameObject.Find("PlayerCollider").GetComponent<CapsuleCollider>();
        hazardCollider = GetComponent<BoxCollider>();
    }

    void FixedUpdate()
    {
        if (playerCollider.bounds.Intersects(hazardCollider.bounds)) //if the player collides with the hazard, take damage
        {
            
            if (Time.time >= nextDamageTime) //if the player is not invincible (invincibility time is over)
            {
                playerHealth.TakeDamage(damage);
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }

    }
