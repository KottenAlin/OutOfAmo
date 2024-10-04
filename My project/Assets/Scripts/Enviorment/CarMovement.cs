using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public List<GameObject> waypoints;  // List of waypoints to follow
    public GameObject Jeff;
    public SniperScript sniperScript;
    public float speed = 2;             // Speed of the car
    public float rotationSpeed = 100;   // Speed at which the car rotates
    public bool startMoving = false;
    public float circularRadius = 5;    // Radius for circular movement
    int index = 0;                      // Index for current waypoint

    [Header("Animation")]
    public string provokedTriggerName = "";

    private void Start(){
        StartCoroutine(WaitUntilSniperHasShot());
        IEnumerator WaitUntilSniperHasShot()
        {
            while (sniperScript == null && Jeff == null)
            {
                yield return null;  // Wait for the next frame
            }

            // Wait until StartWalking becomes true
            while (!sniperScript.StartWalking)
            {
                yield return null;  // Wait for the next frame
            }
            startMoving = true; // start moving
            if(provokedTriggerName != "" && Jeff){ // activates Jeff provoked animation
                Jeff.GetComponent<Animator>().SetTrigger(provokedTriggerName);
            }
        }
    }

    private void Update()
    {
        if (startMoving && index < waypoints.Count)
        {
            MoveTowardsWaypoint();
        }
    }

    private void MoveTowardsWaypoint()
    {
        // Get the current waypoint position
        Vector3 destination = waypoints[index].transform.position;

        // Calculate direction to the waypoint
        Vector3 direction = destination - transform.position;

        // Find the angle between the car's forward direction and the waypoint
        float angleToWaypoint = Vector3.SignedAngle(transform.forward, direction, Vector3.up);

        // Check if the waypoint is to the left or right and rotate accordingly
        if (Mathf.Abs(angleToWaypoint) > 1)  // Only rotate if the angle is significant
        {
            // Determine rotation direction: positive angle means rotate right, negative means rotate left
            float rotationDirection = Mathf.Sign(angleToWaypoint);
            transform.Rotate(Vector3.up, rotationDirection * rotationSpeed * Time.deltaTime);
        }

        // Move the car forward without any extra offset
        transform.position += transform.forward * speed * Time.deltaTime;

        // Check distance to the waypoint to determine if we reached it
        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.1f)  // Small threshold to avoid jitter
        {
            if (index < waypoints.Count - 1)
            {
                index++;  // Move to the next waypoint
            }
            else
            {
                Debug.Log("Finished");
            }
        }
    }
}
