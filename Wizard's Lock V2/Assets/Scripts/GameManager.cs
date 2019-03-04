using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    TextMeshProUGUI timerText;
    float timeLeft = 1200f;
    float timeMin = 0f;
    float timeSec = 0f;

    // Start is called before the first frame update
    void Start()
    {
        timerText = this.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        
    }

    void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;
        timeMin = timeLeft / 60;
        timeSec = timeLeft % 60;
        timerText.text = string.Format("{0}:{1}", (int)timeMin, (int)timeSec);
    }
}
