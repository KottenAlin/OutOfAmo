using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(
            Random.Range(-10f, 10f),
            2f,
            Random.Range(-10f, 10f)
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
