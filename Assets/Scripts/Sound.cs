using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance;
    [SerializeField] private AudioSource soundFX;
    [SerializeField] private AudioClip landClip, deathClip, iceBreakClip, gameOverClip,starClip;
    void Start()
    {
        if (instance == null)
            instance = this;
    }
    public void LandSound()
    {
        soundFX.clip = landClip;
        soundFX.Play();
    }
    public void IceBreakSound()
    {
        soundFX.clip = iceBreakClip;
        soundFX.Play();
    }
    public void DeathSound()
    {
        soundFX.clip = deathClip;
        soundFX.Play();
    }
    public void GameOverSound()
    {
        soundFX.clip = gameOverClip;
        soundFX.Play();
    }
    public void StarSound()
    {
        soundFX.clip = starClip;
        soundFX.Play();
    }
}
 
