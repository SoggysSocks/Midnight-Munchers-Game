using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public List<AudioSource> sounds;
    public string currentscene;
    public Animator uiAnim;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.SetActive(false);
        Debug.Log("Game Over");
        uiAnim.SetTrigger("GameOver");
        sounds[0].Play();
        sounds[1].Play();
        sounds[2].Play();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(currentscene);
    }
}
