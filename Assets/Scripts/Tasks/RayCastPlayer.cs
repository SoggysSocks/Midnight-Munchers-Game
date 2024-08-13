using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RayCastPlayer : MonoBehaviour
{
    RaycastHit hit;
    public Camera mainCamera;
    public Animator anim;
    private bool isOpen = false;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            isOpen = true;
            ShootRay();
        }
        if (Input.GetKeyDown(KeyCode.E) && isOpen)
        {
            isOpen = false;
            ShootRay();
        }   
    }

    void ShootRay()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Fridge") && !isOpen)
            {
                anim.Play("Open");
            }
            if (hit.collider.gameObject.CompareTag("Fridge") && isOpen)
            {
                anim.Play("Close");
            }
        }
    }
}