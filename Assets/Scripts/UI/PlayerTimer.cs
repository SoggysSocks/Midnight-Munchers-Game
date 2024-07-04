using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimer : MonoBehaviour
{
    public StartStopRound startStopRound;

    public float playerTimer;
    int randomTime;
    public bool timeIsOn;
    // Start is called before the first frame update
    void Start()
    {
        timeIsOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startStopRound.startRound == true)
        {
            RandomNumber();
            playerTimer -= Time.deltaTime;
            timeIsOn = true;
        }
        if (startStopRound.startRound == false)
        {
            timeIsOn = false;
        }
    }
    void RandomNumber()
    {
        if (timeIsOn == true)
        {
            randomTime = Random.Range(100, 150);
            playerTimer = randomTime;
        }
    }
}
