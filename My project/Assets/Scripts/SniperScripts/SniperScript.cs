using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperScript : MonoBehaviour
{
    public GameObject firstPersonController;
    public GameObject mouseLookObject;

    private PlayerMovement playerMovementScript;
    private MouseLook mouseLookScript;



    //LYCKAS EJ MED SENSETIVITY!!!!!!!!1


    // Start is called before the first frame update
    void Start()
    {
        playerMovementScript = firstPersonController.GetComponent<PlayerMovement>();
        mouseLookScript = mouseLookObject.GetComponent<MouseLook>();

        if (playerMovementScript != null)
        {
            playerMovementScript.enabled = false;
        }

        if (mouseLookScript != null)
        {
            mouseLookScript.mouseSensitivity = 100f; // Accessing the non-static field through the instance
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

