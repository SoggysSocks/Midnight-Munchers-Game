using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteTaskTouch : MonoBehaviour
{
    public StartStopRound startStopRound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            startStopRound.doneTask = true;
        }
    }
}
