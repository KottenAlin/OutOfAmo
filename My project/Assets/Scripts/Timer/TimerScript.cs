using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Timer_Text;
    [SerializeField] float remainingTime;

    public GameOverScreen gameOverScreen;

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            Timer_Text.color = Color.red;
            gameOverScreen.Setup();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        Timer_Text.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
