

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileLifetime = 5f;
    public int damage = 10;
    public bool canBeDestroyed = false;

    public PlayerHealth playerHealth;

    public float totalTime = 0;


    // Start is called before the first frame update

    public SphereCollider projectileCollider;
    public CapsuleCollider playerCollider;

    void Awake()
    {
        projectileCollider = GetComponent<SphereCollider>();
        playerCollider = GameObject.Find("PlayerCollider").GetComponent<CapsuleCollider>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();

    }

    void Start()
    {
       damage = 8;



    }




    // Update is called once per frame
    void Update()
    {
       totalTime += Time.deltaTime;

    }

        void OnTriggerEnter(Collider other) // When the projectile collides with something
        {
            if (other == playerCollider)
            {
                playerHealth.TakeDamage(damage);
                Destroy(gameObject);
            }
            else if (totalTime >= 1f)
            {
                Debug.Log("Projectile hit something");
                Debug.Log("Time.time: " + totalTime + other.name);
                Destroy(gameObject);
            }
        } 

}

