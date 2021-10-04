using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    private AudioSource audioSource;

    [SerializeField] private AudioClip fireShot;
    [SerializeField] private AudioClip fleshHit;
    [SerializeField] private AudioClip shipHit;
    [SerializeField] private AudioClip button;
    [SerializeField] private AudioClip coin;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayFlesh()
    {
        audioSource.PlayOneShot(fleshHit, 0.8f);
    }

    public void PlayShipHit()
    {
        audioSource.PlayOneShot(shipHit, 0.8f);
    }

    public void PlayCoin()
    {
        audioSource.PlayOneShot(coin, 0.8f);
    }

    public void PlayButton()
    {
        audioSource.PlayOneShot(button, 0.8f);
    }


    public void PlayFire()
    {
        audioSource.PlayOneShot(fireShot, 0.8f);
    }
}
