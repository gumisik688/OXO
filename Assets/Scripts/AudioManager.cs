using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource SFXSource;

    public AudioClip piston;
    public AudioClip shotgun;
    public AudioClip enemyAttack;
    public AudioClip ammoPickUp;

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void StopSFX(AudioClip clip)
    {
        SFXSource.Stop();
    }
}

