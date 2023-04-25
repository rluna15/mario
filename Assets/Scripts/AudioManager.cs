using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip jumpSFX;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip growShroomSFX;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayJump()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(jumpSFX);
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void PlayDeath()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(deathSFX);
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void PlayCoin()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(coinSFX);
        }
        else
        {
            audioSource.Stop();
        }
    }

    public void PlayGrowShroom()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(growShroomSFX);
        }
        else
        {
            audioSource.Stop();
        }
    }
}
