using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBounceController : MonoBehaviour
{
    public float speed = 10;
    int randomRot;
    private Rigidbody rb;
    public bool onWall;

    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
        Rotate();
        onWall = false;
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity += transform.forward * Time.deltaTime * speed;

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
        yield return new WaitForSeconds(3f);
        RandomPos();
        Rotate();
    }
}
