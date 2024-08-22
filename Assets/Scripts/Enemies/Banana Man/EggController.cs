using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    public float hatchTimer;
    public GameObject spiderBanPrefab;
    public Transform prefabTransorm;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
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
