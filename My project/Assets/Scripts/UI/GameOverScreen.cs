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
    public GameObject WinScreen;
    public GameObject arrestScreen;

    public AudioSource winSound;
    public AudioSource arrestSound;
    public AudioSource deathSound;
    public GameObject GameManager;
    public GameObject[] Timers;
    // The PlayerController script on the FirstPersonController
    private PlayerController PlayerControllerScript;

    void awake() {
        WinScreen = GameObject.Find("WinBackground");
        DeathScreen = GameObject.Find("DeathBackground");
        arrestScreen = GameObject.Find("ArrestBackground");
    }

    private void RemoveExtraUI() //

    {
    
        foreach (GameObject Timer in Timers)
        {
            Timer.SetActive(false);
        }
    }
    // Call this method to show the Game Over screen and disable the scripts
    public void Death()
    {
        // Enable the Game Over screen
        DeathScreen.SetActive(true);
        deathSound.Play();
        Time.timeScale = 0;
        PlayerControllerScript.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        DeactivateSounds();

        RemoveExtraUI();
    }

    public void DeactivateSounds() {
          if (GameManager != null)
        {
            Debug.Log("Deactivating sounds");
            GameManager.transform.Find("Music").gameObject.SetActive(false);
            GameManager.transform.Find("AmbientSoundsTrump").gameObject.SetActive(false);
            
        }

    }

    public void Win()
    {
        // Enable the Game Over screen
        WinScreen.SetActive(true);
        winSound.Play();
        Time.timeScale = 0;
        PlayerControllerScript.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        DeactivateSounds();

        RemoveExtraUI();
    }

    public void Arrested()
    {
        // Enable the Game Over screen
        arrestScreen.SetActive(true);
        arrestSound.Play();
        Time.timeScale = 0;
        PlayerControllerScript.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        DeactivateSounds();

        RemoveExtraUI();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("Gamemanager");
        // Get the Music and AmbientSoundsTrump components from the GameManager
     
        // Get the PlayerController script from the FirstPersonController
        if (firstPersonController != null)
        {
            Time.timeScale = 1; // restarts time
            PlayerControllerScript = firstPersonController.GetComponent<PlayerController>();

        }
    }
}
