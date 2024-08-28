using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class WeepingAngelController : MonoBehaviour
{ // YOUTUBE VID https://www.youtube.com/watch?v=f27kWiI_B60&t=988s 
    //The AI's Nav Mesh Agent
    public NavMeshAgent ai;

    //The player's Transform
    public Transform player;

    //The AI's Animator component
    public Animator aiAnim;

    //The AI's destination
    Vector3 dest;

    //The player's Camera and the AI's jumpscare Camera
    public Camera playerCam, jumpscareCam;

    //The AI's movement speed
    public float aiSpeed;

    //The distance in which the AI can catch the player from
    public float catchDistance;

    //The amount of seconds it takes for the AI's jumpscare to finish
    public float jumpscareTime = 0;

    //The scene you load into after dying
    public string sceneAfterDeath;

    public HealthSystem healthSystem;
    public AudioSource audioSouce;
    public AudioSource audioSouce2;
    public AudioClip bangSound;
    public AudioClip footSteps;
    public bool soundBool = false;
    public bool soundBool2 = false;

    public StartStopRound startStopRound;
    //The Update() void, stuff occurs every frame in this void
    private void Start()    
    {
        startStopRound = FindObjectOfType<StartStopRound>();
        //need reference for prefab
        playerCam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthSystem = player.GetComponent<HealthSystem>();
    }
    void Update()
    {
        if (startStopRound.deleteAllEnemys) // Deletes enemy when player is damaged or round has ended
        {
            Destroy(gameObject);
        }
        //Calculate the player's Camera's frustum planes
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(playerCam);

        //Get the AI's distance from the player
        float distance = Vector3.Distance(transform.position, player.position);

        //If the AI is in the player's Camera's view,
        if (GeometryUtility.TestPlanesAABB(planes, this.gameObject.GetComponent<Renderer>().bounds))
        {
            ai.speed = 0; //The AI's speed will equal to 0
            

            //If the player object is active,
            if (player.gameObject.active == true)
            {
                aiAnim.speed = 0; //The AI'S animation speed will be set to 0
                if (!soundBool)
                {
                    audioSouce.pitch = 0.9f;
                    audioSouce.PlayOneShot(bangSound);
                    
                    soundBool = true;
                    }
                    
                }
            ai.SetDestination(transform.position); //The AI's destination will be set to themselves to stop a delay in the movement stopping
        }
        else
        {
            soundBool = false;
            audioSouce.pitch = 1.4f;
            
        }
        if (!soundBool)
        {
            if (soundBool2)
            {
                audioSouce2.Play();
                audioSouce2.PlayOneShot(footSteps);
                soundBool2 = false;
            }

        }
        else
        {
            soundBool2 = true;
            audioSouce2.Stop();
        }

        //If the AI isn't in the player's Camera's view,
        if (!GeometryUtility.TestPlanesAABB(planes, this.gameObject.GetComponent<Renderer>().bounds))
        {
            //audioSouce.pitch = 1.8f;
            
            //audioSouce.clip = footSteps;


            ai.speed = aiSpeed; //The AI's speed will equal to the value of aiSpeed
            aiAnim.speed = 1; //The AI's animation speed will be set to 1
            dest = player.position; //dest will equal to the player's position
            ai.destination = dest; //The AI's destination will equal to dest

            //If the distance between the player and the AI is less than or equal to the catchDistance,
            if (distance <= catchDistance)
            {
                //player.gameObject.SetActive(false); //The player object will be set false
                aiAnim.Play("jumpscareee");
                StartCoroutine(killPlayer()); //The killPlayer() coroutine will start
            }
        }
    }
    //The killPlayer() coroutine
    IEnumerator killPlayer()
    {
        yield return new WaitForSeconds(jumpscareTime); //After the amount of seconds determined by the jumpscareTime,
        healthSystem.Damage();
        Destroy(gameObject);
        //SceneManager.LoadScene(sceneAfterDeath); //The scene after death will load
    }
}
