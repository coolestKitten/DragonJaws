using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandleFeetNoises : MonoBehaviour, AudioPlayer
{
    public AudioSource audioSource;   
    public AudioClip audioClip; 

    public void OnEnable(){
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }
    public void PlayAudio() {
        audioSource.Play();
        //Debug.Log("PlayAudio");
    }

    public void StopAudio() {
        audioSource.Stop();
        //Debug.Log("StopAudio");
    }

    public void SetVolume(float _volume) {
        audioSource.volume = _volume;
        //Debug.Log("SetVolume");
    }
}
