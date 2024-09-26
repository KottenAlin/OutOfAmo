using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekTarget : MonoBehaviour
{
    Transform JeffTransform;
    PickUpScript pickUpScript;
    public GameObject Jeff;
    public int speed;
    private Rigidbody rb;
    private bool velocityZeroed = false;
    // Start is called before the first frame update
    public PlayerController playerScript; //Refernce to Playerscript
    public GameOverScreen EndGameScript;
    public string SleepingName = "";

    // activate Cop Attack
    void Start()
    {
        pickUpScript = GameObject.Find("Main Camera").GetComponent<PickUpScript>();
        JeffTransform = Jeff.transform;
        rb = GetComponent<Rigidbody>(); // takes the rigidbody
    }

    // Update is called once per frame
    void Update()
    {
        if(!velocityZeroed && !pickUpScript.isHolding && rb.velocity.magnitude > 5f){
            velocityZeroed = true;
            rb.velocity = new Vector3(0,0,0);
        }

        if(velocityZeroed){
            JeffTransform = Jeff.transform;
            // Get the current waypoint position
            Vector3 destination = JeffTransform.position;
            Vector3 newPosition = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            transform.position = newPosition;  // updates the cars position values to align with movement towards waypoint

            float distance = Vector3.Distance(transform.position, destination); 
            if (distance <= 0.1f)  // Small threshold to avoid jitter
            {
                if(SleepingName != ""){
                    Jeff.GetComponent<Animator>().SetTrigger(SleepingName);
                }
                StartCoroutine(DelayedCompletion()); // Delays Win screen
                IEnumerator DelayedCompletion()
                {
                    // Wait
                    yield return new WaitForSeconds(3);

                    // Log a message after the delay
                    EndGameScript.Win();
                }

                // Disables everything related to player movement
                playerScript.input.Movement.Disable();
                playerScript.input.Jump.Disable();
                playerScript.readyToAttack = false; // Disables attacking durin arrest
                playerScript.lockAttack = true; // Disable Player Attack
                // -----------------------------
            }
        }
    }
    }
