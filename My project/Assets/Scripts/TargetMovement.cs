
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    public Vector3 Destination1;
    public Vector3 Destination2;

    public Vector3 walkPoint;

    public string XVelocityName = "";
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //walkPoint = Destination1;
        agent.SetDestination(walkPoint);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, walkPoint) < 1f)
        {
            walkPoint = Destination2;
            agent.SetDestination(walkPoint);
        }
        Debug.Log(agent.velocity.magnitude);
        if (agent.velocity.magnitude > 0)
        {
            GetComponent<Animator>().SetFloat(XVelocityName, agent.velocity.magnitude);
        }
        else
        {
            GetComponent<Animator>().SetFloat(XVelocityName, 0);
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
}
