
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoevementTutorial : MonoBehaviour
{
    public MouseClickTutorial mouseClickTutorial; // Reference to the MouseClickTutorial script

    // Start is called before the first frame update
    void Start()
    {
        mouseClickTutorial = GameObject.Find("MouseClick").GetComponent<MouseClickTutorial>(); // Find the MouseClickTutorial script
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Camera.main.transform.rotation.eulerAngles.y) < 170 || Mathf.Abs(Camera.main.transform.rotation.eulerAngles.y) > 195) // Check if the camera is not facing the target
        {
            Debug.Log(Mathf.Abs(Camera.main.transform.rotation.eulerAngles.y));
            mouseClickTutorial.Activate(); // Activate the MouseClickTutorial script
            Destroy(gameObject); // Destroy the tutorial UI when the camera moves
        }
    }
}
