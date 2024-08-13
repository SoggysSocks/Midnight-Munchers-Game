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
    public float lerpSpeed = 4;
    public float aimOffset = 2;
    public float rayCastDistance = 20;
    public float noiseAmount = 0.08f;
    public float noiseSpeed = 0.5f;
    public float decreaseScore = 0;

    public SoundManager soundManager;
    private Vector3 previousHitPoint;

    private float time; //noise

    public GameObject pParticle;

    void Start()
    {
        scoreMax = 150;
        previousHitPoint = playerAim.position;
       
        time = 0; //for noise

    }
    void FixedUpdate()
    {
        decreaseScore = Time.time;
        if (decreaseScore >= 10 && toiletScore >= 1) ;
        {
            toiletScore = toiletScore - 0.1f;
            decreaseScore = 0;  
        }
        // if (Input.GetButtonDown("Fire1"))
        if (toiletScore >= scoreMax)
        {
            ToiletScoreMax();
        }

        FireRay();
       

    }

    void FireRay()
    {

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);



        time += noiseSpeed * Time.deltaTime;

        //soem noise thing i found online
        Vector3 noise = new Vector3(
            Mathf.PerlinNoise(time, 0) - 0.5f,
            Mathf.PerlinNoise(0, time) - 0.5f,
            Mathf.PerlinNoise(time, time) - 0.5f
        ) * noiseAmount;
        //

        // Offset the pee position down
        Vector3 offsetOrigin = cameraRay.origin;
        offsetOrigin.y -= aimOffset;


        Vector3 rayNoise = cameraRay.direction + noise; //gets 


        if (Physics.Raycast(offsetOrigin, rayNoise, out hit, rayCastDistance))
        {

            Vector3 hitPoint = hit.point;

            GameObject particleInstance = Instantiate(pParticle, hitPoint, Quaternion.identity);


            Destroy(particleInstance, .8f); //time for destruction.

            if (hit.collider.gameObject.CompareTag("ToiletBowl"))
            {

                SpawnRayCastLine();
                Debug.Log("bowl IS HIT");
            }
            else if (hit.collider.gameObject.CompareTag("ToiletWater"))
            {

                SpawnRayCastLine();
                Debug.Log("ToiletWater Is hit");
            }
            else if (hit.collider.gameObject.CompareTag("ToiletTarget"))
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
        lineRend.SetPosition(0, playerAim.position);

        // Smoothly moves the end position using lerp (lerp just makes it a clean transition)
        Vector3 targetHitPoint = hit.point;
        previousHitPoint = Vector3.Lerp(previousHitPoint, targetHitPoint, lerpSpeed * Time.deltaTime);
        lineRend.SetPosition(1, previousHitPoint);
        soundManager.PeeSound();

        // lineRend.enabled = true;
        //lineRend.SetPosition(0, playerAim.transform.position);
        // lineRend.SetPosition(1, hit.point);
        //soundManager.PeeSound();
    }

}
