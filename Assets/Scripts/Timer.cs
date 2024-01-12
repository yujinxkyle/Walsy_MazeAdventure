using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Serialized] TextMeshProUGUI timerText;
    [Serialized] float remainingTime;

    void Update()
    {
       if(remainingTime > 0 )
       {
          remainingTime -= Time.deltaTime;
       }
       else if (remainingTime < 0 )
       {
           remainingTime = 0;
           // GameOver();
           timerText.color = Color.red;
       }
       int minutes = Mathf.FloorToInt(elapsedTime/ 60);
       int seconds = Mathf.FloorToInt(elapsedTime % 60);
       timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
