using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public Animator anim;
    public bool dayTime;

    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement component is missing from the GameObject");
        }


        anim = GetComponent<Animator>();
        dayTime = true;
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && !dayTime)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
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

        if (playerMovement.grounded)
        {
            anim.SetBool("Ground", true);
        }
        else
        {
            anim.SetBool("Ground", false);
        }
    }
}
