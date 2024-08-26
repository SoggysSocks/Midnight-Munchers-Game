using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public GameOver gameOver;

    public int maxHealth;
    public int heartNumber;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite EmptyHeart; // skull
    public Animator UIanim; //UI

    public List<AudioSource> sounds;
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
        if (maxHealth <= 1)
        {
            
            gameOver.EndGame();
            
        } else
        {
            sounds[0].Play();
            sounds[1].Play();
            sounds[2].Play();
            maxHealth = maxHealth - 1;
            UIanim.SetTrigger("DamagePlayer");

        }
    }
}
