using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    public float hatchTimer;
    public GameObject spiderBanPrefab;
    public Transform prefabTransorm;

    public Animator anim;
    public StartStopRound startStopRound;

    // Start is called before the first frame update
    void Start()
    {
        startStopRound = FindObjectOfType<StartStopRound>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startStopRound.deleteAllEnemys) // Deletes enemy when player is damaged or round has ended
        {
            Destroy(gameObject);
        }

        hatchTimer += Time.deltaTime;

        if (hatchTimer >= 6.15f)
        {
            Instantiate(spiderBanPrefab, prefabTransorm.position, Quaternion.identity);
            Instantiate(spiderBanPrefab, prefabTransorm.position, Quaternion.identity);
            Instantiate(spiderBanPrefab, prefabTransorm.position, Quaternion.identity);
            Instantiate(spiderBanPrefab, prefabTransorm.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }
}   
