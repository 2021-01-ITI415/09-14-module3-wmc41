using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Player_Audio : MonoBehaviour
{
    public AudioClip splashSound;

    public AudioSource audioS;

    public AudioMixerSnapshot idleSnapshot;
    public AudioMixerSnapshot auxInSnapshot;
    public AudioMixerSnapshot ambIdleSnapshot;
    public AudioMixerSnapshot ambInSnapshot;

    public LayerMask enemyMask;

    bool enemyNear;
    private void Update()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, 10f, transform.forward, 5f, enemyMask);
        if (hits.Length > 0)
        {
            if (!enemyNear)
            {
                auxInSnapshot.TransitionTo(0.5f);
                enemyNear = true;
            }

        }
        else
        {
            if (enemyNear)
            {
                idleSnapshot.TransitionTo(0.5f);
                enemyNear = false;
            }
        }
    }

private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            audioS.PlayOneShot(splashSound);
        }
        if (other.CompareTag("Enemy_Zone"))
        {
            auxInSnapshot.TransitionTo(0.5f);
        }
        if (other.CompareTag("Ambiance"))
        {
            ambInSnapshot.TransitionTo(0.5f);
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
        if (other.CompareTag("Ambiance"))
        {
            ambIdleSnapshot.TransitionTo(0.5f);
        }
    }
}
