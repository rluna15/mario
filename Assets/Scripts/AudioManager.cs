using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject coinSFX;
    [SerializeField] GameObject jumpSFX;
    [SerializeField] GameObject deathSFX;
    [SerializeField] GameObject growShroomSFX;
    [SerializeField] GameObject squishSFX;
    [SerializeField] GameObject warpSFX;
    [SerializeField] GameObject brickBreakSFX;
    [SerializeField] GameObject bumpSFX;
    [SerializeField] GameObject fireballSFX;

    public void PlayJump()
    {
        Instantiate(jumpSFX);
    }

    public void PlayDeath()
    {
        Instantiate(deathSFX);
    }

    public void PlayCoin()
    {
        Instantiate(coinSFX);
    }

    public void PlayGrowShroom()
    {
        Instantiate(growShroomSFX);
    }

    public void PlaySquish()
    {
        Instantiate(squishSFX);
    }

    public void PlayWarp()
    {
        Instantiate(warpSFX);
    }

    public void PlayBrickBreak()
    {
        Instantiate(brickBreakSFX);
    }

    public void PlayBump()
    {
        Instantiate(bumpSFX);
    }

    public void PlayFireball()
    {
        Instantiate(fireballSFX);
    }
}
