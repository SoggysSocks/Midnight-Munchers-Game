using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStopRound : MonoBehaviour
{
    public bool startRound;
    public bool doneTask;

  

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
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bed") && !doneTask)
        {
            startRound = true;
        }
        if (collision.gameObject.CompareTag("Bed") && doneTask)
        {
            EndRound();
        }
    }
    public void StartRound()
    {
        startRound = true;
    }
    public void EndRound()
    {
        startRound = false;
        doneTask = false;

    }

    public void TaskToTrue()
    {
        doneTask = true;
    }
}
