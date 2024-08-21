using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopRound : MonoBehaviour
{
    public bool startRound;
    public bool doneTask;
    public bool midRound;


    public TaskTimer taskTimer;

    public RoundSystem roundsystem;

    //public SpiderBounceController spiderBounceController; how o reference script
    // Start is called before the first frame update
    void Start()
    {

        startRound = false;
        doneTask = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startRound && doneTask)
        {
            doneTask = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bed") && roundsystem.enableNight == true)
        {
            roundsystem.startNight = true;
            roundsystem.enableNight = false;
            roundsystem.RandomNumberRounds(); //replaced

        }
        if (collision.gameObject.CompareTag("Bed") && !doneTask && !startRound && roundsystem.startNight)
        {
            StartRound();
        }


        if (collision.gameObject.CompareTag("Bed") && doneTask && startRound)
        {
            EndRound();
            if (roundsystem.startNight)
            {
                StartRound();
            }
        }

    }
    public void StartRound()
    {
        startRound = true;
        taskTimer.RandomNumber();
    }
    public void EndRound()
    {
        startRound = false;
        doneTask = false;
        roundsystem.hasStarted = false;

        taskTimer.ResetTime();
        Debug.Log("Round Ended");

        roundsystem.numberOfRounds = roundsystem.numberOfRounds - 1;
    }

    public void TaskToTrue()
    {
        doneTask = true;
    }
}

