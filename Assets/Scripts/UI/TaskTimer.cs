using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskTimer : MonoBehaviour
{
    public StartStopRound startStopRound;

    public float timeLeft = 0;
    public bool timeRunning = true;
    public TMP_Text timeText;

    int randomTime;
    bool randomTimeBool;
    public DayNight dayNight;

    public HealthSystem healthSystem;

    // some of this script is from yt https://www.youtube.com/watch?v=x9IFMcwqkPY
    // Start is called before the first frame update
    void Start()
    {
        dayNight = FindObjectOfType<DayNight>();
        RandomNumber();
    }

    // Update is called once per frame
    void Update()
    {


        if (startStopRound.startRound == true)
        {

            timeRunning = true;

            if (timeRunning)
            {
                if (timeLeft >= 0)
                {
                    timeLeft += -Time.deltaTime;
                    DisplayTime(timeLeft);
                    
                }
                if (timeLeft <= 0)
                {
                    Debug.Log("live lost");
                    healthSystem.Damage();
                    ResetTime();
                    startStopRound.startRound = false;
                    startStopRound.EndRound();
                    dayNight.DayTime();

                }

            }



        }

    }

    void DisplayTime (float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }
    public void RandomNumber()
    {
     randomTime = Random.Range(100, 150);
     timeLeft = randomTime;
    }
    public void ResetTime()
    {

        timeLeft = 0;
        DisplayTime(timeLeft);
    }
}
