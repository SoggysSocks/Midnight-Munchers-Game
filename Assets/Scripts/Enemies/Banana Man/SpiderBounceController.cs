using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBounceController : MonoBehaviour
{
    public float speed = 10;
    int randomRot;
    private Rigidbody rb;
    public bool onWall;
    public float timer;
    public float timeDuration = 12;

    public GameObject particleEffect;
    public Transform particlePos;

    public Animator anim;

    public HealthSystem healthSystem;
    public GameObject player;
    public GameObject bMan;
    public AudioSource audioSource;
    public AudioSource audioSource2;
    public float time;

    public StartStopRound startStopRound;

    // Start is called before the first frame update
    void Start()
    {
        startStopRound = FindObjectOfType<StartStopRound>(); //reference
        audioSource.Play();
        player = GameObject.FindWithTag("Player"); // yt 
        if (player != null) //if player is there.
        {
            healthSystem = player.GetComponent<HealthSystem>(); //
        }


        GameObject particleInstance = Instantiate(particleEffect, particlePos.position, particlePos.rotation);
        Destroy(particleInstance, 1f);
        
        RandomPos();
        Rotate();
        onWall = false;
        rb = GetComponent<Rigidbody>();
        
        //other stuff such as gameobjects for particles.
    }

    // Update is called once per frame
    void Update()
    {
        if (startStopRound.deleteAllEnemys) // Deletes enemy when player is damaged or round has ended
        {
            Destroy(gameObject);
        }
        time += -Time.deltaTime;
        if(time >= 2.5f)
        {
            Rotate();
            time = 0;
        }


        rb.velocity += -transform.right * Time.deltaTime * speed;
        
        timer += Time.deltaTime;
        if (timer >= timeDuration)
        {
            GameObject particleInstance = Instantiate(particleEffect, particlePos.position, particlePos.rotation);
            Destroy(particleInstance, 1f);
            Destroy(gameObject);
        }

        if (onWall == true)
        {
            StartCoroutine(Wait(0f));
            onWall = false;
        }   
    }
    public void RandomPos() //bounces random direaction
    {
        // give nm number and reyurn it
        randomRot = Random.Range(0, 360);
    }
    private void OnCollisionEnter(Collision collision) //player collides with something other then floor it bounces off and plays a sound.
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            //RandomPos();
            //Rotate();
            onWall = true;
            
            
        }
        else
        {
            onWall = false;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            healthSystem.Damage();
            Destroy(gameObject);
            Destroy(bMan);
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
        }
        else
        {
            onWall = true;
        }
    }

    public void Rotate()
    {
        //rotate player based om number
        transform.Rotate(0, randomRot, 0);
        audioSource2.Play();
    }
    IEnumerator Wait(float seconds)
    {
        //has timer cuz soemtimes stuck on wall.
        yield return new WaitForSeconds(0.02f);
        RandomPos();
        Rotate();
    }

}
