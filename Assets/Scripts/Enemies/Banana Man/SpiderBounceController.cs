using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBounceController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RandomPos();
        Rotate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RandomPos()
    {
           // give nm number and reyurn it
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            RandomPos();
            Rotate();
        }
       
    }
    public void Rotate()
    {
        //rotate player baed om number
    }
}
