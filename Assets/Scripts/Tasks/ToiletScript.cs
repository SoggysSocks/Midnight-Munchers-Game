using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToiletScript : MonoBehaviour
{
    RaycastHit hit;
    public Camera mainCamera;
    public Transform playerAim;
    public LineRenderer lineRend;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireRay();
        }
        FireRay();
        
    }

    void FireRay()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out hit))
        {
            if (hit.collider.gameObject.CompareTag("ToiletBowl"))
            {
                lineRend.enabled = true;
                lineRend.SetPosition(0, playerAim.transform.position);
                lineRend.SetPosition(1, hit.point);

                Debug.Log("bowl IS HIT");
            }
            if (hit.collider.gameObject.CompareTag("ToiletWater"))
            {

                Debug.Log("ToiletWater IS HIT");
            }
            else
            {
                lineRend.enabled = true;
                lineRend.SetPosition(0, playerAim.transform.position);
                lineRend.SetPosition(1, hit.point);
            }

        } 
    }
}
