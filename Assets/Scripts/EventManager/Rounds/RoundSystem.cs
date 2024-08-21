using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundSystem : MonoBehaviour
{
    public StartStopRound startStopRound;
    public NightmareSpawn nightmareSpawn;
    public DayNight dayNight;

    public int numberOfRounds;
    public int taskNumber;
    public bool startNight;
    public bool enableNight;
    public bool hasStarted = false;
    

    // LIST OF TASKS // BOOLS //
    public bool snackTask = false;

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
            snackTask = true;
        }
        if (taskNumber == 2)
        {
            
        }
        if (taskNumber == 3)
        {
            
        }
        if (taskNumber == 4)
        {
            
        }
    }


    public void RandomNumberRounds()
    {
        numberOfRounds = Random.Range(2, 5);
    }
    public void RandomNumberTask()
    {
        taskNumber = Random.Range(1, 5);
    }
    void AllTaskToFalse()
    {
        snackTask = false;
    }
}
