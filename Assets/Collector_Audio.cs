using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Collector_Audio : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip collectSound;
    public AudioClip town1Sound;

    public AudioMixerSnapshot town1Snapshot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            audioS.PlayOneShot(collectSound);
        }
        if (other.CompareTag("Town1"))
        {
            audioS.PlayOneShot(town1Sound);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Town1"))
        {
            town1Snapshot.TransitionTo(0.5f);
        }
    }
}
