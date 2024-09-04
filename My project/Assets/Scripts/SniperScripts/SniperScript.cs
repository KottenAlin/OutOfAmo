using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SniperScript : MonoBehaviour
{
    public PlayerController playerScript;
    public GameObject arms;
    public GameObject cameraGameObject;

    private PlayerInput playerInput; // Reference to PlayerInput
    private PlayerInput.MainActions input; // Reference to input actions
    private Camera camera; // Camera reference

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
        camera = cameraGameObject.GetComponent<Camera>();
        if (camera == null)
        {
            Debug.LogError("Camera component not found on the specified GameObject.");
            return;
        }

        playerScript.enableMovement = false;
        playerScript.enableAttack = false;
        playerScript.sensitivity = 3f;
        arms.SetActive(false);
        camera.fieldOfView = 15f;
    }

    void Update()
    {
        // Any other code you might need in Update
    }

    void Shoot()
    {
        Debug.Log("Shoot action triggered from SniperScript!");
        StartCoroutine(ChangeFOVCoroutine());
    }

    IEnumerator ChangeFOVCoroutine()
    {
        if (camera == null)
        {
            Debug.LogError("Camera reference is missing.");
            yield break;
        }

        float targetFOV = 20f;
        float initialFOV = 15f;
        int frameCount = 30;

        for (int i = 0; i < frameCount / 2; i++)
        {
            camera.fieldOfView = Mathf.Lerp(initialFOV, targetFOV, (float)i / (frameCount / 2));
            yield return null;
        }

        for (int i = 0; i < frameCount / 2; i++)
        {
            camera.fieldOfView = Mathf.Lerp(targetFOV, initialFOV, (float)i / (frameCount / 2));
            yield return null;
        }

        camera.fieldOfView = initialFOV;
    }
}
