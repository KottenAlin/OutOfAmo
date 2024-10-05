using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingAudio : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource audioSource;
    public bool pickedUpItem;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        StartCoroutine(PlayAudio(0)); 
        StartCoroutine(PlayAudio(1));
        if (pickedUpItem == true)
        {
            StartCoroutine(WaitAndPlayNextAudio(50, 3));
        }
        
    }

    public IEnumerator WaitAndPlayNextAudio(float waitTime, int i)
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(PlayAudio(i));
    }

    // Update is called once per frame
    public IEnumerator PlayAudio(int i)
    {
        Debug.Log("test 1");
        while (audioSource.isPlaying)
        {
            yield return null;
            //Debug.Log("test 2");
        }
        if (audioClips.Length > i)
        {
            Debug.Log("Playing audio " + i);
            audioSource.PlayOneShot(audioClips[i]);
        }
    }
}

