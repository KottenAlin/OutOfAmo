
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : MonoBehaviour
{

    public float speed = 4.0f;

    public float amplitude = 40f;
    public RectTransform rectTransform;
    public Vector2 size;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        size = rectTransform.sizeDelta; // get the size of the rect
    }

    // Update is called once per frame
    void Update()
    {
       
        float height = Mathf.Sin(Time.time * speed) * amplitude;
        
        if (rectTransform != null)
        {
            
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, height);
            rectTransform.sizeDelta = new Vector2(height/20 + size.x, height/20 + size.y);
            
        }
    }




}
