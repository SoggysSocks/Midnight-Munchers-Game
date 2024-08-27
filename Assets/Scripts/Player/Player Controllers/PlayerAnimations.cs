using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator anim;
    public bool dayTime;

    public PlayerMovement playerMovement;
    public List<AudioSource> sounds;

    // Start is called before the first frame update
    void Start()
    {

        anim = GetComponent<Animator>();
        dayTime = true;

    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !dayTime)
        {
            anim.SetBool("Walking", true);
            sounds[0].Play();
            sounds[0].pitch = 2;
        }
        else
        {
            anim.SetBool("Walking", false);
            AllSoundsOff();
        }

        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && dayTime)
        {
            anim.SetBool("Zest Walk", true);
        }
        else
        {
            anim.SetBool("Zest Walk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && playerMovement.grounded)
        {
            anim.SetTrigger("Jumping");
            
        }
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement is missing ");
            if (playerMovement.grounded)
            {
                anim.SetBool("Ground", true);
                sounds[0].Play();
            }
            else
            {
                anim.SetBool("Ground", false);
            }
        }

    }
    public void AllSoundsOff()
    {
        sounds[0].Stop();
    }
}
