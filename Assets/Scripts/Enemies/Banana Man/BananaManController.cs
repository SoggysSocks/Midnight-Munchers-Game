using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BananaManController : MonoBehaviour
{
    public SoundManager soundManager;

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
        playerRangeMin = playerRangeRoll;
        agent = GetComponent<NavMeshAgent>();
        timer = walkTimer;
        RandomPos();

       
    }

    void Update()
    {
        timer += Time.deltaTime;
        spawnTimer += Time.deltaTime;
        if (timer >= walkTimer)
        {

            float randomNumber = Random.value;

            if (randomNumber <= 0.5 && Vector3.Distance(transform.position, player.position) <= playerRangeRoll)
            {
                RollToPlayer();
                timer = 0;
            } 
            else if (randomNumber <= 0.3 && Vector3.Distance(transform.position, player.position) <= playerRangeMax && Vector3.Distance(transform.position, player.position) >= playerRangeMin)
            {
                JumpToPlayer();
                timer = 0;
            }
            else
            {
                RandomPos();
                timer = 0;
            }

        }
        if(spawnTimer >= spawnPrefabEvery)
        {
            
            anim.SetBool("IsThrowing", true);
            spawnTimer = 0;
            StartCoroutine(ThrowingTimer());
        }

        if (agent.remainingDistance <= 0.1f)
        {

                anim.SetBool("IsWalking", false);
  
        }
        if (anim.GetBool("IsRolling"))
        {
            soundManager.RollSoundBMan();
        } else
        {
           
        }
            
    }

    void RandomPos()
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
            anim.SetBool("IsWalking", false);
            
        }
    
    }


    void JumpToPlayer()
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
    IEnumerator ThrowingTimer()
    {
        yield return new WaitForSeconds(1.2f);
        SpawnPrefab();
        anim.SetBool("IsThrowing", false);
        Debug.Log("spawned and anim 4 banana man");
    }
    IEnumerator ResetSpeedDelay(float normalSpeed)
    {
        yield return new WaitForSeconds(1); 
        agent.speed = normalSpeed;
        anim.SetBool("IsJumping", false);
        anim.SetBool("IsRolling", false);

    }

}