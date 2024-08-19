using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkTask : MonoBehaviour
{
    RaycastHit hit;
    public Camera mainCamera;
    public bool snackTaskDone = false;

    public FridgeController fridgeController;
    public StartStopRound startStopRound;

    // Start is called before the first frame update
    void Start()
    {
        fridgeController = FindObjectOfType<FridgeController>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            ShootRayDrink();
        }

    }
    public void ShootRayDrink()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Drink") && fridgeController.isOpen)
            {
                Debug.Log("drink");
                snackTaskDone = true;
                
            }

        }
    }
}