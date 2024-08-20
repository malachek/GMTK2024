using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    public AudioClip[] audioClips;
    public AudioSource[] audioSources;

    private void Start()
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            audioSources[i].clip = audioClips[i];
            audioSources[i].mute = true;
            //audioSources[i].loop = false;
            //audioSources[i].Play();
        }

        StartLooping();
    }

    private void StartLooping()
    {
        foreach (AudioSource source in audioSources)
        {
            source.loop = false;
            source.Play();
        }

        InvokeRepeating(nameof(ResetAudioSources), 0f, 30f);
    }

    void ResetAudioSources()
    {
        foreach (AudioSource source in audioSources)
        {
            if (source.isPlaying)
            {
                source.Stop();
            }
            source.time = 0;
            source.Play();
        }
    }
    public void UnMutePattern(int index)
    {
        Debug.Log("Unmuting pattern " + index);
        audioSources[index].mute = false;
    }
}
