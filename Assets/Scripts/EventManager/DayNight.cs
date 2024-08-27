using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    public PlayerAnimations playerAnim;
    public GameObject dayLight;
    public GameObject nightLight;
    public List<AudioSource> sounds;
   
    private bool soundBool = true;
    // Start is called before the first frame update
    void Start()
    {
        DayTime();
        dayLight.SetActive(true);
        nightLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DayTime()
    {
        if (soundBool)
        {
            sounds[0].Play();
            sounds[4].Play(); //birds
            sounds[5].Play();
            sounds[3].Stop();
            soundBool = false;
        }
        playerAnim.dayTime = true;
        dayLight.SetActive(true);   
        nightLight.SetActive(false);

        
    }
    public void NightTime()
    {
        if (!soundBool)
        {
            sounds[0].Play(); //lights
            sounds[1].Play(); //bass
            sounds[2].Play(); //ambient
            sounds[3].Play(); // ambient
            sounds[4].Stop();
            sounds[5].Stop();
            soundBool = true;
        }
       
        playerAnim.dayTime = false;
        nightLight.SetActive(true);
        dayLight.SetActive(false);

    }
}


