using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToiletScript : MonoBehaviour
{
    //https://www.youtube.com/watch?v=Ehk9fKBwS3Y for lerp method

    RaycastHit hit;
    public Camera mainCamera;
    public Transform playerAim;
    public LineRenderer lineRend;

    public float toiletScore;
    public SoundManager soundManager;
    void Update()
    {
       // if (Input.GetButtonDown("Fire1"))

        FireRay();
        soundManager.PeeSound();
        
    }

    void FireRay()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out hit))
        {
            if (hit.collider.gameObject.CompareTag("ToiletBowl"))
            {

                SpawnRayCastLine();
                Debug.Log("bowl IS HIT");
            }
            if (hit.collider.gameObject.CompareTag("ToiletWater"))
            {

                SpawnRayCastLine();
                Debug.Log("ToiletWater Is hit");
            }
            if (hit.collider.gameObject.CompareTag("ToiletTarget"))
            {
                SpawnRayCastLine();
                toiletScore = Time.time;
                Debug.Log("Toilet Target Hit");
 

            }
            else
            {
                toiletScore = toiletScore;
                SpawnRayCastLine();
                toiletScore = -Time.time;
            }

        } 
    }
    void SpawnRayCastLine()
    {
        lineRend.enabled = true;
        lineRend.SetPosition(0, playerAim.transform.position);
        lineRend.SetPosition(1, hit.point);
    }
}
