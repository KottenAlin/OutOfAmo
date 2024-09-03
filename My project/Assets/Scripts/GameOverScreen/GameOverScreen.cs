using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    // Reference to the FirstPersonController GameObject
    public GameObject firstPersonController;
    public GameObject MainCamera;

    public GameObject DeathScreen;

    // The PlayerMovement script on the FirstPersonController
    private PlayerMovement playerMovementScript;

    private MouseLook MouseLookScript;


    // Call this method to show the Game Over screen and disable the scripts
    public void Setup()
    {
        // Enable the Game Over screen
        DeathScreen.SetActive(true);

        playerMovementScript.enabled = false;
        MouseLookScript.enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the PlayerMovement script from the FirstPersonController
        if (firstPersonController != null)
        {
            playerMovementScript = firstPersonController.GetComponent<PlayerMovement>();
            MouseLookScript = MainCamera.GetComponent<MouseLook>();
        }
    }
}
