
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public Vector3 Destination1;
    public Vector3 Destination2;

    public Vector3 walkPoint;
    public NavMeshAgent agent;

    public GameOverScreen gameOverScreen;

    [Header("Animation")]
    public string DeadName = "";
    public string XVelocityName = "";
    public string DanceName = "";

    private bool hasEntered = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //walkPoint = Destination1;
        agent.SetDestination(walkPoint);
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
        if (Vector3.Distance(transform.position, Destination2) < 1f)
        {
            if (DanceName != "")
            {
                agent.SetDestination(transform.position); // Freezes Target when killed by player
                GetComponent<Animator>().SetTrigger(DanceName); // Triggers Dancing when endpoint is reached
            }
        }
        if (Vector3.Distance(transform.position, Destination1) < 1f)
        {
            walkPoint = Destination2;
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
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Destination1, 0.5f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(Destination2, 0.5f);
    }

    IEnumerator WaitForTenSeconds()
    {

        yield return new WaitForSeconds(6);
        gameOverScreen.Win();
    }
}
