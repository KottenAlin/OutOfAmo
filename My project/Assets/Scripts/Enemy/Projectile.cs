using System.Threading;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileLifetime = 5f;
    public int damage = 10;

    public PlayerHealth playerHealth;


    // Start is called before the first frame update

    public SphereCollider projectileCollider;
    public CapsuleCollider playerCollider;

     void Awake()
    {
        projectileCollider = GetComponent<SphereCollider>();
        playerCollider = GameObject.Find("PlayerCollider").GetComponent<CapsuleCollider>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }


    // Update is called once per frame
    void Update()
    {
        if (playerCollider.bounds.Intersects(projectileCollider.bounds)) //if the player collides with the hazard, take damage
        {
            playerHealth.TakeDamage(damage);
            Destroy(gameObject);
        }
        
        /*if (Time.time > projectileLifetime)
        {
            Destroy(gameObject);
        } */
    }
}
