using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public List<AudioSource> sounds;

public void PeeSound()
    {
        sounds[0].Play();
    }
public void RollSoundBMan()
    {
        sounds[1].Play();
    }
}
