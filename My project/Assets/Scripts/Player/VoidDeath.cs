using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidDeath : MonoBehaviour
{

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y < -100)
        {
            player.position = new Vector3(0, 0, 0);
        }
    }
}
