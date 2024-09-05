using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public GameObject player;
    public float speed = 5f;

    public GameObject projectile; // The projectile that the enemy will shoot

    public NavMeshAgent agent; // The NavMeshAgent component on the enemy

    public LayerMask groundLayer, playerLayer; // The layers that the enemy can interact with

    public bool useShootingAttack, useMeleeAttack; // Check if the enemy uses shooting or melee attack


    // Patrolling

    public Vector3 walkPoint; // The position of where the enemy will walk to
    bool walkPointSet;
    public float walkPointRange; // The range of the walk point from the enemy

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //states

    public float sightRange, attackRange;
    private bool playerInSightRange, playerInAttackRange; // Check if the player is in sight or attack range


    void Awake()
    {
        player = GameObject.Find("Player"); // Find the player GameObject
        agent = GetComponent<NavMeshAgent>(); // Get the NavMeshAgent component on the enemy
    }

    void Patrolling()
    {
        if (!walkPointSet) SearchWalkPoint(); // If the walk point is not set, search for a walk point
        if (walkPointSet) agent.SetDestination(walkPoint); // If the walk point is set, set the destination of the NavMeshAgent to the walk point

        Vector3 distanceToWalkPoint = transform.position - walkPoint; // Calculate the distance to the walk point

        if (distanceToWalkPoint.magnitude < 1f) walkPointSet = false; // If the enemy is close to the walk point, the enemy has reached the walk point
    }

    void SearchWalkPoint()
    { // Search for a random walk point
        // Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange); // Random Z value within the walk point range
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ); // Set the walk point to the random position

        if (Physics.Raycast(walkPoint, -transform.up, 2f, groundLayer)) walkPointSet = true; // If the walk point is on the ground, set the walk point
    }
    void ChasePlayer()
    {
        agent.SetDestination(player.transform.position); // Set the destination of the NavMeshAgent to the player's position
    }

    void AttackPlayer()
    {
        if (agent.isOnNavMesh)
        {
            agent.SetDestination(transform.position); // Stop the enemy from moving

            transform.LookAt(player.transform); // Look at the player, so the enemy faces the player

            if (!alreadyAttacked)
            {
                //Attack code here

                Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
                rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
                rb.AddForce(transform.up * 8f, ForceMode.Impulse);

                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
    }

    void ResetAttack()
    {
        alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Enemy took damage");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }


    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = player.transform.position;

        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);

        if (!playerInSightRange && !playerInAttackRange) Patrolling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

    }
}
