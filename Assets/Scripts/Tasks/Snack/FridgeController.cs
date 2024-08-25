using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FridgeController : MonoBehaviour
{
   

    RaycastHit hit;
    public Camera mainCamera;
    public Animator anim;
    public bool isOpen = false;
    private float playerDistance = 3;

    void Update()
    {

            if (Input.GetKeyDown(KeyCode.E))
            {
                ShootRay();
            }


    }

    void ShootRay()
    {   
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out hit, playerDistance))
        {
            if (hit.collider.gameObject.CompareTag("Fridge") && !isOpen)
            {
                anim.Play("Open");
                isOpen = true;
            } else if (hit.collider.gameObject.CompareTag("Fridge") && isOpen)
            {
                anim.Play("Close");
                isOpen = false;
            }
        }
    }

}