using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBounceController : MonoBehaviour
{
    public float speed = 10;
    int randomRot;

    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
        Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed; 
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
            Debug.Log("HIY WALLS");
            RandomPos();
            Rotate();
        }
       
    }

    public void Rotate()
    {
        //rotate player based om number
        transform.Rotate(0, randomRot, 0);
    }
}
