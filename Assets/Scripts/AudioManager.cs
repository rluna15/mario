using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] GameObject coinSFX;
    [SerializeField] GameObject jumpSFX;
    [SerializeField] GameObject deathSFX;
    [SerializeField] GameObject growShroomSFX;

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
}
