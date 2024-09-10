using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SniperScript : MonoBehaviour
{
    public PlayerController playerScript; //Refernce to Playerscript
    public GameObject arms; //Refence to arms
    public GameObject cameraGameObject;

    private PlayerInput playerInput; // Reference to PlayerInput
    private PlayerInput.MainActions input; // Reference to input actions
    private Camera mainCamera; // Camera reference

    private AudioSource audioSource; // AudioSource reference

    public GameObject objectToSpawn;

    public Transform playerTransform;

    public AudioClip shootSound;

    public Transform victimObject; // Target to look at


    public float spawnDistance = 2.0f; // Distance in front of the player where the object should spawn

    public Vector3 offset = new Vector3(1, 1, 2); //Offset so that the shoot misses the victim. 


    void Awake()
    {
        // Initialize the PlayerInput and input actions
        playerInput = new PlayerInput();
        input = playerInput.Main;
    }

    void OnEnable()
    {
        // Enable the input system
        input.Enable();

        // Bind the Shoot method to the Attack input action
        input.Attack.started += ctx => Shoot();
    }

    void OnDisable()
    {
        // Disable the input system
        input.Disable();
    }

    void Start()
    {
        mainCamera = cameraGameObject.GetComponent<Camera>();
        audioSource = GetComponent<AudioSource>();

        if (mainCamera == null)
        {
            Debug.LogError("Camera component not found on the specified GameObject.");
            return;
        }

        //turns of a movement and attack aswell as the players arms. Lowers also the sensitivity and field of View to trully be in the sniper mode!
        playerScript.enableMovement = false;
        playerScript.enableAttack = false;
        playerScript.sensitivity = 3f;
        arms.SetActive(false);
        mainCamera.fieldOfView = 15f;
    }

    //Function that gets called once we shoot.
    void Shoot()
    {
        Debug.Log("Shoot action triggered from SniperScript!");
        StartCoroutine(MissAndShoot()); // Start AutoMiss coroutine when shooting
    }

    //Function to spawn the shoot. It will get the same position + offset as the camera and the same rotation so that the skottScript makes so that the shoot goes where you aimed.
    void Spawn()
    {
        // Ensure the mainCamera is assigned
        if (mainCamera != null)
        {
            // Calculate the spawn position in front of the mainCamera
            Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * spawnDistance;

            // Calculate the rotation based on the mainCamera's forward direction
            Quaternion spawnRotation = Quaternion.LookRotation(mainCamera.transform.forward);

            // Instantiate the prefab at the calculated position with the calculated rotation
            GameObject skottInstance = Instantiate(objectToSpawn, spawnPosition, spawnRotation);

            // Adjust the rotation if needed (e.g., applying the -90 degree on the X-axis)
            skottInstance.transform.Rotate(-90f, 0f, 0f);
        }
        else
        {
            Debug.LogWarning("mainCamera reference is not assigned.");
        }
    }

    //Function to miss the victim and call the shoot function aswell as animation and sound.
    IEnumerator MissAndShoot()
    {
        //Disables the ability to look around 
        playerScript.enableLook = false;


        //Gets camera position and rotation.
        Vector3 initialCameraPosition = mainCamera.transform.position;
        Quaternion initialCameraRotation = mainCamera.transform.rotation;

        //Using the camera position and rotation together with the victims position + offset to set the target rotation.
        Quaternion targetRotation = Quaternion.LookRotation((victimObject.position + offset) - mainCamera.transform.position);


        //Amount of frames it will take to reach the target rotation.
        int frameCount = 50;

        //For each frame we inch closer to the target rotation.
        for (int i = 0; i < frameCount; i++)
        {
            float t = (float)i / frameCount;
            mainCamera.transform.rotation = Quaternion.Slerp(initialCameraRotation, targetRotation, t);
            yield return null;
        }



        // Ensure the final rotation is set
        mainCamera.transform.rotation = targetRotation;


        //This part of the code animates the shoot by changing the field of view back and fourth. 
        float targetFOV = 20f;
        float initialFOV = 15f;
        int frameCount2 = 30;

        for (int i = 0; i < frameCount2 / 2; i++)
        {
            mainCamera.fieldOfView = Mathf.Lerp(initialFOV, targetFOV, (float)i / (frameCount2 / 2));
            yield return null;
        }

        //Here we also play the sound of the shoot. 
        if (audioSource != null && shootSound != null)
        {
            audioSource.PlayOneShot(shootSound);
        }
        else
        {
            Debug.LogWarning("AudioSource or shootSound is not assigned.");
        }

        //While the FOV is the biggest we spawn in the shoot. 
        Spawn();

        for (int i = 0; i < frameCount2 / 2; i++)
        {
            mainCamera.fieldOfView = Mathf.Lerp(targetFOV, initialFOV, (float)i / (frameCount2 / 2));
            yield return null;
        }

        //reseting the fov
        mainCamera.fieldOfView = initialFOV;
    }


}
