using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopRound : MonoBehaviour
{
    public bool startRound;
    public bool doneTask;

    public TaskTimer taskTimer;

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
        if (collision.gameObject.CompareTag("Bed") && !doneTask && !startRound)
        {
            StartRound();

        }
        if (collision.gameObject.CompareTag("Bed") && doneTask && startRound)
        {
            EndRound();
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

        taskTimer.ResetTime();
        Debug.Log("Round Ended");

    }

    public void TaskToTrue()
    {
        doneTask = true;
    }
}
