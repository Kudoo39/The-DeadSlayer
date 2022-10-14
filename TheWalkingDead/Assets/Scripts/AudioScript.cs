using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioScript Instance;
    public AudioSource Sound;
    public AudioClip jumpsound, touchenemy, killenemy;

    void Start()
    {
        Instance = this;
    }
    public void jumpSound()
    {
        Sound.clip = jumpsound;
        Sound.Play();
    }
    public void touchEnemy()
    {
        Sound.clip = touchenemy;
        Sound.Play();
    }
    public void killEnemy()
    {
        Sound.clip = killenemy;
        Sound.Play();
    }
}
