using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTutorialUI : MonoBehaviour
{
    public float speed = 4.0f;
    public float amplitude = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float height = Mathf.Sin(Time.time * speed) * amplitude;
        Transform transform = GetComponent<Transform>();
        if (transform != null)
        {
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
    
        }
    }
}
