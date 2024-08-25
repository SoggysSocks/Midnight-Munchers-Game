using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWorkTask : MonoBehaviour
{
    RaycastHit hit;
    public Camera mainCamera;
    public StartStopRound startStopRound;
    public RoundSystem roundSystem;
    private float playerDistance = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (roundSystem.homeworkTask )  
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ShootRaySnack();
            }
        }

    }
    public void ShootRaySnack()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out hit, playerDistance))
        {
            if (hit.collider.gameObject.CompareTag("HWTask"))
            {

                startStopRound.doneTask = true;
            }

        }
    }
}

