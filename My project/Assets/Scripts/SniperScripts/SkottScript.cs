using UnityEngine;

public class SkottScript : MonoBehaviour
{
    //Speed of the shoot
    public float speed = 5.0f;

    //Amount of frames that it takes to despawn the Object. In order to save minimal amount of calculations
    public float TimetoDespawn = 500;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Moving the skott along it's own position and rotation.
        transform.position -= transform.up * speed * Time.deltaTime;

        //Code to despawn the shoot object after TimetoDespawn.
        TimetoDespawn -= 1;

        if (TimetoDespawn < 0)
        {
            Destroy(gameObject);
        }

    }
}
