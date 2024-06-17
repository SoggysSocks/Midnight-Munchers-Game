using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWithCam : MonoBehaviour
{
    //gets cams transform
    public Transform cameraTransform; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRotation = new Vector3(0, cameraTransform.eulerAngles.y, 0); //cams rotation and sets to 0
        transform.rotation = Quaternion.Euler(newRotation); //rotates it.
    }
}
