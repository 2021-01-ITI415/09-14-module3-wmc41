using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player_Audio : MonoBehaviour
{
    public AudioClip splashSound;

    public AudioSource audioS;

    public AudioMixerSnapshot idleSnapshot;
    public AudioMixerSnapshot auxinSnapshot;

private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            audioS.PlayOneShot(splashSound);
        }
        if (other.CompareTag("Enemy_Zone"))
        {
            auxinSnapshot.TransitionTo(0.5f);
        }
    }
private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            audioS.PlayOneShot(splashSound);
        }
        if (other.CompareTag("Enemy_Zone"))
        {
            idleSnapshot.TransitionTo(0.5f);
        }
    }
}
