using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class MouseClickTutorial : MonoBehaviour
{
    public Image image;
    public int waitTime = 10;

    public TalkingAudio talkingAudio; // Reference to the TalkingAudio script

    void Awake()

    {
        talkingAudio = GameObject.Find("TalkingAudio").GetComponent<TalkingAudio>(); // Find the TalkingAudio script
        image = GetComponent<Image>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (image == null)
        {
            Debug.Log("Image not found!");
            return;

        }

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
        if (this == null)
        {
            return;
        }
        StartCoroutine(ActivateAfterDelay());

        IEnumerator ActivateAfterDelay()
        {
            yield return new WaitForSeconds(waitTime);
            image.enabled = true;
            foreach (Transform child in transform) 
        {
            child.gameObject.SetActive(true);
            StartCoroutine(talkingAudio.PlayAudio(2));
        }
        }
    }
}
