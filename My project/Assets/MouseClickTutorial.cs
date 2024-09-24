using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MouseClickTutorial : MonoBehaviour
{
    public Image image;
    public int waitTime = 3;


    void Awake()
    {
        image = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
        foreach (Transform child in transform) 
        {
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void DeActivate() {
        Destroy(gameObject);
    }

    public void Activate() {
        StartCoroutine(ActivateAfterDelay());

        IEnumerator ActivateAfterDelay()
        {
            yield return new WaitForSeconds(waitTime);
            image.enabled = true;
            foreach (Transform child in transform) 
        {
            child.gameObject.SetActive(true);
        }
        }
    }
}
