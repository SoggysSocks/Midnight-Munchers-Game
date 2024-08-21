using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BananaManController : MonoBehaviour
{
    public float range = 15;
    public float walkTimer = 5;
    public float playerRange = 15;
    public float jumpSpeed = 15;
    public float normalSpeed = 3.5f;

    public Transform player;
    private NavMeshAgent agent;
    private float timer;

    public GameObject eggPrefab;
    public GameObject spiderPrefab;
    public GameObject prefabSpawn;

    public Animator anim;

    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        timer = walkTimer;
        RandomPos();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= walkTimer)
        {
            float randomNumber = Random.value;

            if (randomNumber <= 0.3 && Vector3.Distance(transform.position, player.position) <= playerRange)
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
        }
        //
    }
    void JumpToPlayer()
    {
        Debug.Log("Banana Man Jumped" + player.position);
        agent.speed = jumpSpeed;
        agent.SetDestination(player.position);
        StartCoroutine(ResetSpeedDelay(normalSpeed));

    }

    void InstantiatePrefab()
    {

        float randomNumber = Random.value;
        if (randomNumber <= 0.3)
        {
            Instantiate(eggPrefab, prefabSpawn.transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(spiderPrefab, prefabSpawn.transform.position, Quaternion.identity);
        }



    }
    IEnumerator ResetSpeedDelay(float normalSpeed)
    {
        yield return new WaitForSeconds(1f); 
        agent.speed = normalSpeed;
    }
}