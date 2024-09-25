using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PunchingTutorial : MonoBehaviour
{
    public KeyCode qButton = KeyCode.Q;
    public Canvas canvas;
    public KeyCode leftClickButton = KeyCode.Mouse0;

    bool isShowing = false;
    bool qIsPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(qButton) && !qIsPressed)
        {
            qIsPressed = true;
            StartCoroutine(ShowTutorial());

            IEnumerator ShowTutorial()
            {
                yield return new WaitForSeconds(5);
                canvas.enabled = true;
            }
        }
        if(Input.GetKeyDown(leftClickButton) && canvas.enabled)
        {
            canvas.enabled = false;
        }
    }
}
