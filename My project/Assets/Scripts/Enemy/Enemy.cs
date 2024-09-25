using System.Transactions;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    public float health;

    //Patroling
    public Vector3 walkPoint;

    public AudioSource gunShot;
    public bool walkPointSet;
    public float walkPointRange;

    [Header("CenterPoint")]

    public Vector3 centerPoint;
    public float centerPointRange;

    [Header("Attacking")]

    public bool isRanged = true;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public int meleeAttackDamage = 10;

    public PlayerHealth playerHealth;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    [Header("Animation")]
    public string XVelocityName = "";
    public string DeathName = "";
    private bool IsDead = false;

    void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    void Start()
    {
        centerPoint = transform.position;
        if (!isRanged)
        {
            attackRange = 2f;
        }
    }

    void Update()
    {
        if (agent.velocity.magnitude > 0.01)
        {
            if (XVelocityName != "" && !IsDead)
            {
                GetComponent<Animator>().SetFloat(XVelocityName, agent.velocity.magnitude); // activate walking animation when enemy is moving
            }
        }
        if (DeathName != "")
        {
            if (GetComponent<Animator>().GetBool(DeathName))
            {
                IsDead = true;
                agent.SetDestination(transform.position); // Freezes Target when killed by player
            }
            if (IsDead)
            {
                GetComponent<Animator>().SetFloat(XVelocityName, 0);
            }
        }
        if (!IsDead)
        {
            //Check for sight and attack range
            playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer); // Check if the player is in sight range 
            playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

            if (!playerInSightRange && !playerInAttackRange) Patroling();
            if (playerInSightRange && !playerInAttackRange) ChasePlayer();

            if (playerInAttackRange && playerInSightRange) AttackPlayer();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();



        if (walkPointSet)
        {

            // Set the destination to the walk point
            agent.SetDestination(walkPoint);

            // Check if the enemy is standing still
            if (agent.velocity.magnitude < 0.1f && agent.remainingDistance < 0.5f)
            {
                // Enemy is standing still and has reached the walk point, reset walk point
                walkPointSet = false;
            }
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1.5f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        // Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);



        Vector3 randomPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Vector3.Distance(centerPoint, randomPoint) >= centerPointRange)
        {
            return;
        }


        // Check if the random point is on the NavMesh
        NavMeshHit hit; // Stores information about the point where the raycast hit
                        //Debug.Log(NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas));
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) // Check if the random point is on the NavMesh 
        {
            walkPoint = hit.position; // Set the walkPoint to the random point
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            if (isRanged) Shoot();
            else
            {
                ///Melee attack code
                playerHealth.TakeDamage(meleeAttackDamage);
                //melee attack animation
            }
            ///End of attack code
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    void Shoot()
    {
        Vector3 bulletPos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        Rigidbody rb = Instantiate(projectile, bulletPos, Quaternion.identity).GetComponent<Rigidbody>();
        gunShot.Play();
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        rb.AddForce(transform.up * 8f, ForceMode.Impulse);
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(centerPoint, centerPointRange);
    }
}
