using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioClip audioClip1; // First audio clip
    public AudioClip audioClip2; // Second audio clip
    public AudioClip audioClip3; // Third audio clip
    public AudioClip audioClip4; // Fourth audio clip
    public AudioClip audioClip5; // Fifth audio clip
    public AudioClip audioClip6; // Sixth audio clip
    public AudioClip audioClip7; // Seventh audio clip
    public AudioClip audioClip8; // Eighth audio clip
    // Ninth audio clip

    private AudioSource audioSource1; // First audio source
    private AudioSource audioSource2; // Second audio source
    private AudioSource audioSource3; // Third audio source
    private AudioSource audioSource4; // Fourth audio source
    private AudioSource audioSource5; // Fifth audio source
    private AudioSource audioSource6; // Sixth audio source
    private AudioSource audioSource7; // Seventh audio source
    private AudioSource audioSource8; // Eighth audio source
    // Ninth audio source

    private void Start()
    {
        // Initializing the audio sources
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource3 = gameObject.AddComponent<AudioSource>();
        audioSource4 = gameObject.AddComponent<AudioSource>();
        audioSource5 = gameObject.AddComponent<AudioSource>();
        audioSource6 = gameObject.AddComponent<AudioSource>();
        audioSource7 = gameObject.AddComponent<AudioSource>();
        audioSource8 = gameObject.AddComponent<AudioSource>();

        // Assigning the audio clips to the audio sources
        audioSource1.clip = audioClip1;
        audioSource2.clip = audioClip2;
        audioSource3.clip = audioClip3;
        audioSource4.clip = audioClip4;
        audioSource5.clip = audioClip5;
        audioSource6.clip = audioClip6;
        audioSource7.clip = audioClip7;
        audioSource8.clip = audioClip8;
    }

    private void Update()
    {
        
    }
}
