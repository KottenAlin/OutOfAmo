
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour
{
    int currentHealth;
    public int maxHealth = 10;
    public string DeadName = "";
    public Rigidbody rb;
    private Animator mAnimator;
    private AnimatorStateInfo stateInfo;
    public float speed = 10f;

    [Header("Colliders")]
    public MeshCollider[] Colliders;
    
    public GameOverScreen gameOverScreen;


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

        if (currentHealth <= 0)
        { Death(); }
    }

    void Death()
    {
        // Death function
        if(DeadName != ""){
            if(mAnimator != null){
                mAnimator.SetTrigger(DeadName); // activates death-animation for Gameobject
                if (GetComponent<Animator>().GetBool(DeadName)){
                    if (Colliders[0].enabled){ // Only iterates IF necessary, i.e if MeshCollider is still active
                        foreach (MeshCollider c in Colliders) 
                        {
                            c.enabled = !GetComponent<Animator>().GetBool(DeadName);
                        }
                        }
                    }
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
