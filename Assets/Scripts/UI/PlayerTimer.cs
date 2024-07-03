using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTimer : MonoBehaviour
{
    public StartStopRound startStopRound;

    public float playerTimer;
    int randomTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startStopRound.startRound == true)
        {
            
            playerTimer -= Time.deltaTime;
        }

    }
    void RandomNumber()
    {
        randomTime = Random.Range(100, 150);
    }
}
