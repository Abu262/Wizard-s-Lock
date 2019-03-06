using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;


    [SerializeField] TextMeshProUGUI timerText = null;
    float timeLeft = 1200f;
    float timeMin = 0f;
    float timeSec = 0f;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        if ( timeLeft <= 0)
        {
            SceneManager.LoadScene("Lose Screen");
            timeLeft = 1200f;
        }
        
    }

    void UpdateTimer()
    {
        timeLeft -= Time.deltaTime;
        timeMin = timeLeft / 60;
        timeSec = timeLeft % 60;
        if (timeSec <= 10)
        {
            timerText.text = string.Format("{0}:0{1}", (int)timeMin, (int)timeSec);
        }
        else
        {
            timerText.text = string.Format("{0}:{1}", (int)timeMin, (int)timeSec);
        }
        
    }
}
