using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareSpawn : MonoBehaviour
{
    public bool spawnNightmare = false;
    public int nightmareNumber;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && spawnNightmare)
        {

        }
    }
    void RandomNumberNightmare()
    {
        nightmareNumber = Random.Range(1, 2);
    }
}
