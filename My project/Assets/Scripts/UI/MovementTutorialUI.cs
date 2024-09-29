using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTutorialUI : MonoBehaviour
{
    public float speed = 4.0f;
    public float amplitude = 1f;
    float randNum = 0;

    // Start is called before the first frame update
    void Start()
    {
    randNum = Random.Range(0.8f, 1f); 
    }

    // Update is called once per frame
    void Update()
    {
        
        float height = Mathf.Sin(Time.time * speed *randNum) * amplitude;
       
        Transform transform = GetComponent<Transform>();
        if (transform != null)
        {
            Vector3 newPosition = transform.position;
            newPosition.y = newPosition.y + height/40f;
            transform.position = newPosition;

        }
    }
}
