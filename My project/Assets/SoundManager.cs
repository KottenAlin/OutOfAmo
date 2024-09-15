using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip Music;
    public AudioClip ambientSound1, ambientSound2, ambientSound3, ambientSound4, ambientSound5;
    
    // Start is called before the first frame update
    void Start()
    {
        Music = Resources.Load<AudioClip>("Music"); //loads the music file from the resources folder

        AudioSource audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = Music;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
