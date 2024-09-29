using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{

    public float zoomIntensity = 2.0f;


    public KeyCode zoomInKey = KeyCode.Z;

    public Camera camera;
    private float fieldOfView;
    private float sensitivity;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        playerController = GetComponent<PlayerController>();

        sensitivity = playerController.sensitivity;
    }

    // Update is called once per frame
    void Update()
    {
        fieldOfView = playerController.GetFieldOfView();
        if (Input.GetKey(zoomInKey))
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0.0f)
            {
                zoomIntensity += scroll;
                zoomIntensity = Mathf.Clamp(zoomIntensity, 0.1f, 10.0f); // Clamping to avoid extreme zoom values
            }
            camera.fieldOfView = fieldOfView / zoomIntensity;
            playerController.sensitivity = sensitivity / zoomIntensity;

        }
        else
        {
            camera.fieldOfView = fieldOfView;
            playerController.sensitivity = sensitivity;
        }

    }
}
