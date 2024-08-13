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

    // Start is called before the first frame update
    void Start()
    {
        GameObject particleInstance = Instantiate(particleEffect, particlePos.position, particlePos.rotation);
        Destroy(particleInstance, 1f);
        
        RandomPos();
        Rotate();
        onWall = false;
        rb = GetComponent<Rigidbody>();
        

    }

    // Update is called once per frame
    void Update()
    {
  
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
    public void RandomPos()
    {
        // give nm number and reyurn it
        randomRot = Random.Range(0, 360);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("HIT WALLS");
            //RandomPos();
            //Rotate();
            onWall = true;

        }
        else
        {
            onWall = false;
        }
       
    }

    public void Rotate()
    {
        //rotate player based om number
        transform.Rotate(0, randomRot, 0);
    }
    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(0.02f);
        RandomPos();
        Rotate();
    }

}
