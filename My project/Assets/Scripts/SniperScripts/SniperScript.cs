using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SniperScript : MonoBehaviour
{
    private PlayerController playerScript; //Refernce to Playerscript

    public MouseClickTutorial mouseClickTutorial; // Reference to the MouseClickTutorial script

    public GameObject ambienceSound; //Reference to the ambience sound
    public GameObject music; //Reference to the music

    private Zoom zoomScript;

    public bool StartWalking = false;

    private TimerScript timerScript;
    private GameObject arms; //Refence to arms
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

    private float realInitialFOV;

    private float realInitialSensetivity;
    public float sniperSensitivity = 1.5f;

    public Image sniperScope;

    private bool canShoot = true;

    public float fovTarget = 15;

    public float targetFOV = 20f;
    public float initialFOV = 15f;



    void Awake()
    {
        //Finding every object.
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();

        ambienceSound = GameObject.Find("AmbientSoundsTrump");

        music = GameObject.Find("Music");

        zoomScript = GameObject.Find("Player").GetComponent<Zoom>();

        timerScript = GameObject.Find("Canvas_TimerAndDeath").GetComponent<TimerScript>();

        arms = GameObject.Find("Arms");

        cameraGameObject = GameObject.Find("Main Camera");

        // Initialize the PlayerInput and input actions
        playerInput = new PlayerInput();
        input = playerInput.Main;
        mouseClickTutorial = GameObject.Find("MouseClick").GetComponent<MouseClickTutorial>();

        // Ensure the player aims towards the target when the game starts

        
    }

    void OnEnable() // Enable the input system when the script is enabled
    {
        // Enable the input system
        input.Enable();

       
        // Ensure the mainCamera is assigned
    
        /*if (victimObject != null && mainCamera != null)
        {
            Vector3 directionToTarget = (victimObject.position + offset) - cameraGameObject.transform.position; 
            cameraGameObject.transform.rotation = Quaternion.LookRotation(directionToTarget); // Look at the target
        }
        else
        {
            Debug.LogWarning("victimObject or mainCamera reference is not assigned.");
        }*/
    
        // Bind the Shoot method to the Attack input action
    
        StartCoroutine(PauseScriptForOneSecond());
    
        IEnumerator PauseScriptForOneSecond()
        {
            yield return new WaitForSeconds(1f);
            input.Attack.started += ctx => Shoot();
        }
    }
    void Start()
    {
        mainCamera = cameraGameObject.GetComponent<Camera>();
        audioSource = GetComponent<AudioSource>();

        if (ambienceSound != null)
        {
            ambienceSound.SetActive(false);
        }
        music.SetActive(false);
        if (mainCamera == null)
        {
            Debug.LogError("Camera component not found on the specified GameObject.");
            return;
        }
        realInitialFOV = mainCamera.fieldOfView;
        realInitialSensetivity = playerScript.sensitivity;
        // Debug.Log(realInitialSensetivity);
        // Debug.Log(realInitialFOV);

        //turns of a movement and attack aswell as the players arms. Lowers also the sensitivity and field of View to trully be in the sniper mode!
        playerScript.lockMovement = true;
        playerScript.lockAttack = true;
        playerScript.sensitivity = sniperSensitivity;
        arms.SetActive(false);
        mainCamera.fieldOfView = fovTarget;
        StartCoroutine(moveCamera()); // Start the moveCamera coroutine
    }

    public IEnumerator moveCamera() {
                        playerScript.lockCamera = true;
        //Gets camera position and rotation.
        Vector3 initialCameraPosition = mainCamera.transform.position;
        Quaternion initialCameraRotation = mainCamera.transform.rotation;

        //Using the camera position and rotation together with the victims position + offset to set the target rotation.
        Quaternion targetRotation = Quaternion.LookRotation((victimObject.position - offset) - mainCamera.transform.position);
        yield return new WaitForSeconds(0.2f);
        playerScript.lockCamera = false;
    }




    //Function that gets called once we shoot.
    void Shoot()
    {
        if (canShoot)
        {
            Debug.Log("Shoot action triggered from SniperScript!");
            mouseClickTutorial.DeActivate();
            StartCoroutine(MissAndShoot()); // Start AutoMiss coroutine when shooting
            canShoot = false;
        }

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
        playerScript.lockCamera = true;


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

        for (int i = 0; i < frameCount2 / 2; i++) //This part of the code animates the shoot by changing the field of view back and fourth.
        {
            mainCamera.fieldOfView = Mathf.Lerp(targetFOV, initialFOV, (float)i / (frameCount2 / 2));
            yield return null;
        }


        for (int i = 0; i < 120; i++) //This part of the code animates the shoot by changing the field of view back and fourth.

        {
            yield return null;
        }

        //reseting the fov
        mainCamera.fieldOfView = initialFOV;

        int frameCount3 = 100;

        Color currentColor = sniperScope.color;
        for (int i = 0; i < frameCount3; i++) //This part of the code animates the shoot by changing the field of view back and fourth.
        {
            // Set the alpha (transparency) value
            currentColor.a = i / frameCount3;

            // Apply the modified color back to the image
            sniperScope.color = currentColor;


            mainCamera.fieldOfView = Mathf.Lerp(initialFOV, realInitialFOV, (float)i / (frameCount3));
            yield return null;
        }
        timerScript.turnOnTimer = true;
        playerScript.lockMovement = false;
        playerScript.lockAttack = false;

        //Enables the ability to look around again.

        arms.SetActive(true);
        playerScript.lockCamera = false;
        playerScript.sensitivity = realInitialSensetivity;
        zoomScript.enabled = true;
        ambienceSound.SetActive(true);
        music.SetActive(true);

        StartWalking = true;
    }


}
