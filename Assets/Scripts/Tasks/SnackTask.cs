using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnackTask : MonoBehaviour
{
    RaycastHit hit;
    public Camera mainCamera;
    public StartStopRound startStopRound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ShootRaySnack();
        }
    }
    public void ShootRaySnack()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Snack"))
            {

                startStopRound.doneTask = true;
            }

        }
    }
}
