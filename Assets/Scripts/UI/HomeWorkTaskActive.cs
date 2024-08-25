using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWorkTaskActive : MonoBehaviour
{
    public Canvas canvas;
    public RoundSystem roundsystem;
    public StartStopRound startStopRound;

    // Update is called once per frame
    private void Start()
    {
        canvas.gameObject.SetActive(false);

    }
    void Update()
    {
        if (roundsystem.homeworkTask)
        {
            canvas.gameObject.SetActive(true);
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
        if (startStopRound.doneTask)
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
