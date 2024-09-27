using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCornKiller : MonoBehaviour
{

    public GameObject palme;
    public float deathRadius = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        palme = GameObject.Find("Palme");
    }

    // Update is called once per frame
    void Update()
    {
     
            if (Vector3.Distance(transform.position, palme.transform.position) < deathRadius) {
                Debug.Log("Collided with palme!");
                Actor actorComponent = palme.GetComponent<Actor>();
                if (actorComponent != null)
                {
                    actorComponent.Death(); 
                }
                // Add additional logic here if needed
            }
}

void OnDrawGizmos()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, deathRadius);
}
}
