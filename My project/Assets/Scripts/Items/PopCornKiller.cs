using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCornKiller : MonoBehaviour
{

    public GameObject palme;
    public Transform playerTransform;
    public float deathRadius = 1f;
    public GameObject heldObj;

    public PlayerController playerController;

    public bool isDead = false;
        public TalkingAudio talkingAudio;
    // Start is called before the first frame update
    void Start()
    {
        palme = GameObject.Find("Palme");
        playerTransform = GameObject.Find("Player").transform;
        talkingAudio = GameObject.Find("TalkingAudio").GetComponent<TalkingAudio>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        heldObj = GameObject.Find("Main Camera").GetComponent<PickUpScript>().heldObj;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerController.targetName == "Palme" && Vector3.Distance(transform.position, playerTransform.position) < 5f ) /*< 5f && heldObj.name == "Popcorn"*/
        {
           Debug.Log("Collided with palme!");
                Actor actorComponent = palme.GetComponent<Actor>();
                if (actorComponent != null)
                {
                    if (!isDead)
                    {
                        actorComponent.Death();
                        isDead = true;
                    }
                }
            talkingAudio.pickedUpItem = true;
        }
    
        if (Vector3.Distance(transform.position, playerTransform.position) < 5f) {
            Debug.Log("Player is near!");
            talkingAudio.pickedUpItem = true;
        }

}

void OnDrawGizmos()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position, deathRadius);
}
}
