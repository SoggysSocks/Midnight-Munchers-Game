using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public PlayerAnimations playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        DayTime();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DayTime()
    {
        playerAnim.dayTime = true;
    }
    public void NightTime()
    {
        playerAnim.dayTime = false;
    }
}


