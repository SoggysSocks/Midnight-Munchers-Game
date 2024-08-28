using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BananaManController : MonoBehaviour
{
    public SoundManager soundManager;
    public StartStopRound startStopRound;

    public float range = 15;
    public float walkTimer = 5;
    public float playerRangeRoll = 15;
    public float playerRangeMax = 35;
    private float playerRangeMin;
    public float jumpSpeed = 15;
    public float normalSpeed = 3.5f;
    public float spawnPrefabEvery = 4;
    private float randomNumber2;



    public Transform player;
    private NavMeshAgent agent;
    private float timer;
    public float spawnTimer;
    public GameObject eggPrefab;
    public GameObject spiderPrefab;
    public GameObject prefabSpawn;

    public bool isWalking = false;


    public Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; //getting refercne at start because prefab
        startStopRound = FindObjectOfType<StartStopRound>();
        playerRangeMin = playerRangeRoll;
        agent = GetComponent<NavMeshAgent>();
        timer = walkTimer;
        RandomPos();

       
    }

    void Update()
    {
        if (startStopRound.deleteAllEnemys) // Deletes enemy when player is damaged or round has ended
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
        spawnTimer += Time.deltaTime;
        if (timer >= walkTimer)
        {

            float randomNumber = Random.value;

            if (randomNumber <= 0.5 && Vector3.Distance(transform.position, player.position) <= playerRangeRoll) //chance between two nuumvers that it rolls at palyer
            {
                RollToPlayer();
                timer = 0;
            } 
            else if (randomNumber <= 0.3 && Vector3.Distance(transform.position, player.position) <= playerRangeMax && Vector3.Distance(transform.position, player.position) >= playerRangeMin) //chance between to numbers that it jumps at player
            {
                JumpToPlayer();
                timer = 0;
            }
            else
            {
                RandomPos(); //if it isnt both it will jsut walk randomly
                timer = 0;
            }

        }
        if(spawnTimer >= spawnPrefabEvery) //if timer reaches poitn it plays functyion and resets timer
        {
            anim.SetTrigger("IsThrowing");
            
            spawnTimer = 0;
            StartCoroutine(ThrowingTimer());
        }

        if (agent.remainingDistance == 0) // walkign anim to false
        {

            anim.SetBool("IsWalking", false);
  
        }  
        if (agent.velocity.sqrMagnitude > 0.1f) //if its moving it plays animation
       {
           anim.SetBool("IsWalking", true);
        }
        if (anim.GetBool("IsRolling")) //doesn work at the moment...
        {
            soundManager.RollSoundBMan();
        } else
        {
           
        }
            
    }

    void RandomPos() //gets a random popsition within a area.
    {
        //https://www.youtube.com/watch?v=dYs0WRzzoRc

        Vector3 randomPoint = Random.insideUnitSphere * range;
        randomPoint += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, range, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
            anim.SetBool("IsWalking", true);
            
        }
        else
        {
            //anim.SetBool("IsWalking", false);
            
        }
     //
    }


    void JumpToPlayer() //goes to player, makes movement faster and palys a tiemr function for animation./
    {
        anim.SetBool("IsJumping", true);
        Debug.Log("Banana man jump" + player.position);
        agent.speed = jumpSpeed;
        agent.SetDestination(player.position);
        StartCoroutine(ResetSpeedDelay(normalSpeed));
    }
    void RollToPlayer()
    {
        anim.SetBool("IsRolling", true);
        Debug.Log("Banana man roll" + player.position);
        agent.speed = jumpSpeed;
        agent.SetDestination(player.position);
        StartCoroutine(ResetSpeedDelay(normalSpeed));
        
    }
    void SpawnPrefab()
    {

        float randomNumber2 = Random.value;
        if (randomNumber2 <= 0.35)
        {
            Instantiate(eggPrefab, prefabSpawn.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(spiderPrefab, prefabSpawn.transform.position, Quaternion.identity);
        }
    }
    IEnumerator ThrowingTimer() //until to trow animation resets.
    {
        yield return new WaitForSeconds(0.8f);
        SpawnPrefab();
        anim.SetBool("IsThrowing", false);
        Debug.Log("spawned and anim 4 banana man");
    }
    IEnumerator ResetSpeedDelay(float normalSpeed) //resets speed and animation fro roll and jump.
    {
        yield return new WaitForSeconds(1); 
        agent.speed = normalSpeed;
        anim.SetBool("IsJumping", false);
        anim.SetBool("IsRolling", false);
        agent.SetDestination(transform.position);

    }

}