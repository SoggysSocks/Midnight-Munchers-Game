using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToiletScript : MonoBehaviour
{
    public StartStopRound startStopRound;

    RaycastHit hit;
    public Camera mainCamera;
    public Transform playerAim;
    public LineRenderer lineRend;

    public float toiletScore;
    public float scoreMax;

    public SoundManager soundManager;

    void start()
    {
        scoreMax = 0;
    }
    void FixedUpdate()
    {
        // if (Input.GetButtonDown("Fire1"))
        if (scoreMax >= 600)
        {
            ToiletScoreMax();
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
                toiletScore++;
                Debug.Log("Toilet Target Hit");
            }
            else
            {
                toiletScore = toiletScore;
                SpawnRayCastLine();
            }

        }
    }
    public void ToiletScoreMax()
    {
        scoreMax = 0;
        startStopRound.TaskToTrue();
    }
    void SpawnRayCastLine()
    {
        lineRend.enabled = true;
        lineRend.SetPosition(0, playerAim.transform.position);
        lineRend.SetPosition(1, hit.point);
        soundManager.PeeSound();
    }

}
