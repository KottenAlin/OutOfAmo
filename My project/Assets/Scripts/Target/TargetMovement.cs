
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public Vector3 Destination1;
    public Vector3 Destination2;
    public SniperScript sniperScript;
    public Vector3[] Destination;
    

    public Vector3 walkPoint;
    public NavMeshAgent agent;

    public GameOverScreen gameOverScreen;

    [Header("Animation")]
    public string DeadName = "";
    public string XVelocityName = "";
    public string DanceName = "";
    int i = 0;

    private bool hasEntered = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(WaitUntilSniperHasShot());
        IEnumerator WaitUntilSniperHasShot() // Waits until Sniper has shot
        {
            while (sniperScript == null)
            {
                yield return null;  // Wait for the next frame
            }

            // Wait until StartWalking becomes true
            while (!sniperScript.StartWalking)
            {
                yield return null;  // Wait for the next frame
            }
            if (Destination.Length > 0) // If there are destinations, in the array
            {
                walkPoint = Destination[i];
                agent.SetDestination(walkPoint);
            }
        }
        

    }


    void Update()
    {
        if (DeadName != "")
        {
            if (GetComponent<Animator>().GetBool(DeadName))
            {
                agent.SetDestination(transform.position); // Freezes Target when killed by player
                StartCoroutine(WaitForTenSeconds());

            }
        }
        if (Destination.Length > 0 && Vector3.Distance(transform.position, Destination[Destination.Length - 1]) < 1f) // If the distance between the target and the current destination is less than 1, then move to the next destination
        {
            if (DanceName != "")
            {
                agent.SetDestination(transform.position); // Freezes Target when killed by player
                GetComponent<Animator>().SetTrigger(DanceName); // Triggers Dancing when endpoint is reached
                return;
            }
        }
        if (Destination.Length == 0) 
        {
            return;
        }
        if (Vector3.Distance(transform.position, Destination[i]) < 1f) // If the distance between the target and the current destination is less than 1, then move to the next destination
        {
            i++;
            if (i > Destination.Length) // If the index is greater than the length of the array, then return
            {   
                return;
            } else if (i == Destination.Length) // If the index is equal to the length of the array, then move to the next destination
            {
                gameOverScreen.MissionFailed();
            }
            walkPoint = Destination[i];
            agent.SetDestination(walkPoint);
        }
        // Debug.Log(agent.velocity.magnitude);
        if (agent.velocity.magnitude > 0)
        {
            if (XVelocityName != "")
            {
                GetComponent<Animator>().SetFloat(XVelocityName, agent.velocity.magnitude);
            }
        }
        else
        {
            if (XVelocityName != "")
            {
                GetComponent<Animator>().SetFloat(XVelocityName, 0);
            }
        }
    }

    // Update is called once per frame

    void OnDrawGizmos()
    {
        for (int i = 0; i < Destination.Length; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(Destination[i], 0.5f);
        }
    }

    IEnumerator WaitForTenSeconds()
    {

        yield return new WaitForSeconds(6);
        gameOverScreen.Win();
    }
}
