using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{

    public float speed = 4.0f;
    public float amplitude = 40f;

    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
       
        float height = Mathf.Sin(Time.time * speed) * amplitude;
        RectTransform rectTransform = GetComponent<RectTransform>();
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, height);
            rectTransform.sizeDelta = new Vector2((height)+amplitude*5f, (height) + amplitude*5f);
        }
    }




}
