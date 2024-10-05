
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTutorialUI : MonoBehaviour
{
    public float speed = 4.0f;
    public float amplitude = 1f;
    float randNum = 0;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
    randNum = Random.Range(0.9f, 1f); 
    startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        float height = Mathf.Sin(Time.time * speed) * amplitude * randNum;
       
        Transform transform = GetComponent<Transform>();
        if (transform != null)
        {
            Vector3 newPosition = transform.position;
            
            transform.position = new Vector3(newPosition.x, startPos.y + height, newPosition.z);

        }
    }
}
