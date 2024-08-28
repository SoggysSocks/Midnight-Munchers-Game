using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareSpawn : MonoBehaviour
{
    public bool spawnNightmare = false;
    public bool spawnBool;
    public int nightmareNumber;
    public RoundSystem roundSystem;
    public GameObject bananaMan;
    public GameObject george;
    public GameObject prefabSpawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!spawnNightmare)
        {
            spawnBool = true;
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && spawnNightmare && spawnBool)
        {
            RandomNumberNightmare();
            spawnBool = false;

            if (roundSystem.nightNumber <= 2)
            {
                if (nightmareNumber == 1)
                {
                    Instantiate(bananaMan, prefabSpawn.transform.position, Quaternion.identity);
                }
                if (nightmareNumber == 2)
                {
                    Instantiate(george, prefabSpawn.transform.position, Quaternion.identity);
                }
            }
            if (roundSystem.nightNumber == 3)
            {
                if (nightmareNumber == 1)
                {
                    Instantiate(bananaMan, prefabSpawn.transform.position, Quaternion.identity);
                    Instantiate(bananaMan, prefabSpawn.transform.position, Quaternion.identity);
                }
                if (nightmareNumber == 2)
                {
                    Instantiate(george, prefabSpawn.transform.position, Quaternion.identity);
                    Instantiate(george, prefabSpawn.transform.position, Quaternion.identity);
                }
            }
            if (roundSystem.nightNumber == 4)
            {
                if (nightmareNumber == 1)
                {
                    Instantiate(george, prefabSpawn.transform.position, Quaternion.identity);
                    Instantiate(bananaMan, prefabSpawn.transform.position, Quaternion.identity);
                    Instantiate(bananaMan, prefabSpawn.transform.position, Quaternion.identity);
                }
                if (nightmareNumber == 2)
                {
                    Instantiate(george, prefabSpawn.transform.position, Quaternion.identity);
                    Instantiate(george, prefabSpawn.transform.position, Quaternion.identity);
                    Instantiate(bananaMan, prefabSpawn.transform.position, Quaternion.identity);
                }

            }
            if (roundSystem.nightNumber == 5)
            {
                Instantiate(george, prefabSpawn.transform.position, Quaternion.identity);
                Instantiate(george, prefabSpawn.transform.position, Quaternion.identity);
                Instantiate(bananaMan, prefabSpawn.transform.position, Quaternion.identity);
                Instantiate(bananaMan, prefabSpawn.transform.position, Quaternion.identity);
            }
            if (roundSystem.nightNumber >= 6)
            {
                Instantiate(george, prefabSpawn.transform.position, Quaternion.identity);
                Instantiate(george, prefabSpawn.transform.position, Quaternion.identity);
                Instantiate(george, prefabSpawn.transform.position, Quaternion.identity);
                Instantiate(bananaMan, prefabSpawn.transform.position, Quaternion.identity);
                Instantiate(bananaMan, prefabSpawn.transform.position, Quaternion.identity);
                Instantiate(bananaMan, prefabSpawn.transform.position, Quaternion.identity);
                Instantiate(bananaMan, prefabSpawn.transform.position, Quaternion.identity);
            }
        }
    }
    void RandomNumberNightmare()
    {
        nightmareNumber = Random.Range(1, 2);
    }
}
