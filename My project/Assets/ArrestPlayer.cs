using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrestPlayer : MonoBehaviour
{
    // Start is called before the first frame update
        // This will be called when something enters the trigger box
    public PlayerController playerScript; //Refernce to Playerscript
    public GameObject[] ArrestingOfficers;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the box is the player
        if (other.CompareTag("Player"))
        {
            foreach (GameObject ArrestingOfficer in ArrestingOfficers) 
            {
                ArrestingOfficer.SetActive(true);
            }
            playerScript.readyToAttack = false; // Disables attacking durin arrest
            playerScript.lockMovement = true; // Lock Player Movement
            playerScript.lockAttack = true; // Disable Player Attack
            // activate Cop Attack
        }
    }
}
