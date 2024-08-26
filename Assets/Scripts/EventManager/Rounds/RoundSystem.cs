using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoundSystem : MonoBehaviour
{
    public StartStopRound startStopRound;
    public NightmareSpawn nightmareSpawn;
    public DayNight dayNight;

    public int numberOfRounds;
    public int taskNumber;
    public int previousNumber;
    public bool startNight;
    public bool enableNight;
    public bool hasStarted = false;
    

    // LIST OF TASKS // BOOLS //
    public bool snackTask = false;
    public bool fridgeDrinkTask = false;
    public bool homeworkTask = false;
    public bool peeTask = false;
    public bool nightnumres = true;
    public int nightNumber;

    public TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        enableNight = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!startNight)
        {
            // RandomNumberRounds(); //would scroll endlessly. new one in start stop when touches bed.
            dayNight.DayTime();
        } else
        {
            dayNight.NightTime();
        }
        if (startStopRound.startRound && !hasStarted)
        {
            AllTaskToFalse();
            RandomNumberTask();
            hasStarted = true;
        }
        if (numberOfRounds == 0)
        {
            startNight = false;
            enableNight = true;
            startStopRound.EndRound();
            taskNumber = 0;

        }
        if (numberOfRounds <= 0)
        {
            if (nightnumres)
            {
                nightNumber++;
                nightnumres = false;
                _text.text = nightNumber.ToString();
            }
        }
        else
        {
            nightnumres = true;
        }
        if (startStopRound.startRound && !startStopRound.doneTask)
        {
            previousNumber = taskNumber;
        }

        //Nightmare
        if (numberOfRounds == 1)
        {
            nightmareSpawn.spawnNightmare = true;
        }
        else
        {
            nightmareSpawn.spawnNightmare = false;
        }

        // Tasks //
        if (taskNumber == 1)
        {
            AllTaskToFalse();
            snackTask = true;
        }
        if (taskNumber == 2)
        {
            AllTaskToFalse();
            fridgeDrinkTask = true;
        }
        if (taskNumber == 3)
        {
            AllTaskToFalse();
            homeworkTask = true;
        }
        if (taskNumber == 4)
        {
            AllTaskToFalse();
            peeTask = true;
        }
        if (taskNumber == 5)
        {
            AllTaskToFalse();

        }
    }


    public void RandomNumberRounds()
    {
        numberOfRounds = Random.Range(2, 6);
    }
    public void RandomNumberTask()
    {
        taskNumber = Random.Range(1, 5);
        if (taskNumber == previousNumber)
        {
            RandomNumberTask();
        }
    }
    void AllTaskToFalse()
    {
        snackTask = false;
        fridgeDrinkTask = false;
        homeworkTask = false;
        peeTask = false;
    }
}
