using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoneTaskUI : MonoBehaviour
{
    public StartStopRound startStopRound;

    public Toggle taskToggle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startStopRound.doneTask)
        {
            taskToggle.isOn = true;
        }
        else
        {
            taskToggle.isOn = false;
        }
    }
}
