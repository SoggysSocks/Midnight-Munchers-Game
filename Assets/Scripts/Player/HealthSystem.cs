using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth;
    public int heartNumber;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart; // skull
    // Start is called before the first frame update


    void Start()
    {
        maxHealth = 3;
        heartNumber = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(maxHealth > heartNumber)
        {
            maxHealth = heartNumber;
        }

        // YOUTUBE VID https://www.youtube.com/watch?v=3uyolYVsiWc
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < maxHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = EmptyHeart;
            }
            if(i < heartNumber)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void Damage()
    {
        maxHealth = maxHealth - 1;

        if (maxHealth <= 0)
        {
            Debug.Log("Game Over");

        }
    }
}
