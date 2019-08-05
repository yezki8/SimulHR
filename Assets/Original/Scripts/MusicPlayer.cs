using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    AudioSource audioData;

    public void startMusic()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play();
        Debug.Log("started");
    }

    public void pauseMusic()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Pause();
    }

    public void stopMusic()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Stop();
    }
}
