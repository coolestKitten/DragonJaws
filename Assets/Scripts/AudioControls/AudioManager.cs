using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] public float masterVolume;
    [SerializeField] public float walkVolume;
    [SerializeField] public float uiVolume;
    [SerializeField] public float fxVolume;
    [SerializeField] public float gameloopVolume;

    private void OnEnable(){
        PauseGame.OnGamePaused += GamePaused;
    }

    private void OnDisable(){
        PauseGame.OnGamePaused -= GamePaused;
    }

    private void GamePaused(bool gamePaused){
        if(gamePaused){
            SetChanelVolume("Walk", -80);
            SetChanelVolume("UI", uiVolume);
            SetChanelVolume("UX", -80);
            SetChanelVolume("GameLoop", -80);
        } else {
            SetChanelVolume("Walk", walkVolume);
            SetChanelVolume("UI", -80);
            SetChanelVolume("UX", fxVolume);
            SetChanelVolume("GameLoop", gameloopVolume);
        }
    }

    private void SetChanelVolume(string chanel, float volume){
        audioMixer.SetFloat(chanel, volume);
    }

    public void SetMasterVolume(float volume){
        masterVolume = volume;
        audioMixer.SetFloat("Master", volume);
    }

    public void SetWalkVolume(float volume){
        walkVolume = volume;
        audioMixer.SetFloat("Walk", volume);
    }

    public void SetUIVolume(float volume){
        uiVolume = volume;
        audioMixer.SetFloat("UI", volume);
    }

    public void SetFXVolume(float volume){
        fxVolume = volume;
        audioMixer.SetFloat("UX", volume);
    }

    public void SetGameLoopVolume(float volume){
        gameloopVolume = volume;
        audioMixer.SetFloat("GameLoop", volume);
    }
}
