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
    // The PlayerController script on the FirstPersonController
    private PlayerController PlayerControllerScript;
  

    // Call this method to show the Game Over screen and disable the scripts
    public void Death()
    {
        // Enable the Game Over screen
        DeathScreen.SetActive(true);

        PlayerControllerScript.enabled = false;
        

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Get the PlayerController script from the FirstPersonController
        if (firstPersonController != null)
        {
            PlayerControllerScript = firstPersonController.GetComponent<PlayerController>();
           
        }
    }
}
