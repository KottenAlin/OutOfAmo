using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public AudioListener audioListener;

    void Awake()
    {
        if (instance == null) // If there is no GameManager instance, set this as the instance
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1; // Set the time scale to 1 when the game starts
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Make the cursor invisible
        audioListener = FindObjectOfType<AudioListener>(); // Find the AudioListener in the scene
        audioListener.enabled = true; // Enable the AudioListener
        AudioListener.volume = 1.0f; // Set the audio volume to 1
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
