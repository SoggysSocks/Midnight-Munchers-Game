using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopRound : MonoBehaviour
{
    public bool startRound;
    public bool doneTask;
    public bool midRound;
    public bool deleteAllEnemys = false;


    public TaskTimer taskTimer;

    public RoundSystem roundsystem;

    public Animator uiAnim;

    public AudioSource audioSource;
    private bool soundBool = true;

    //public SpiderBounceController spiderBounceController; how o reference script
    // Start is called before the first frame update
    void Start()
    {
        deleteAllEnemys = false;
        startRound = false;
        doneTask = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (!startRound && doneTask) //player cant do task at day
        {
            doneTask = false;
        }
        if (doneTask && soundBool)
        {
            audioSource.Play();
            soundBool = false;
        }


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bed") && roundsystem.enableNight == true) //when player initally hits bed it starts round
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
            uiAnim.SetTrigger("Sleep");
            EndRound();
            if (roundsystem.startNight)
            {
                StartRound();
                soundBool = true;
            }
        }

    }
    public void StartRound() //starts round with bool and random task
    {
        deleteAllEnemys = false;
        startRound = true;
        taskTimer.RandomNumber();
    }
    public void EndRound() //ends round, deletes all enemys and startroudn to false. resets timer
    {
        deleteAllEnemys = true;
        startRound = false;
        doneTask = false;
        roundsystem.hasStarted = false;

        taskTimer.ResetTime();
        Debug.Log("Round Ended");

        roundsystem.numberOfRounds = roundsystem.numberOfRounds - 1;
    }

    public void TaskToTrue() //function for the bool
    {
        doneTask = true;
    }
    public void DeleteAllEnemys() //fucntion for the bool
    {
        deleteAllEnemys = true;
    }
}

