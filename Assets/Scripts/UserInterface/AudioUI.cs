using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUI : MonoBehaviour
{
    
    [HideInInspector] public AudioManager audioManager;
    [Space]
    public Slider masterSlider;
    public Slider walkSlider;
    public Slider uiSlider;
    public Slider fxSlider;
    public Slider gameloopSlider;

    public void OnEnable (){
        audioManager = GetComponent<AudioManager>();
        masterSlider.onValueChanged.AddListener(audioManager.SetMasterVolume);
        walkSlider.onValueChanged.AddListener(audioManager.SetWalkVolume);
        uiSlider.onValueChanged.AddListener(audioManager.SetUIVolume);
        fxSlider.onValueChanged.AddListener(audioManager.SetFXVolume);
        gameloopSlider.onValueChanged.AddListener(audioManager.SetGameLoopVolume);
    }

    public void OnDisable (){
        audioManager = GetComponent<AudioManager>();
        masterSlider.onValueChanged.RemoveListener(audioManager.SetMasterVolume);
        walkSlider.onValueChanged.RemoveListener(audioManager.SetWalkVolume);
        uiSlider.onValueChanged.RemoveListener(audioManager.SetUIVolume);
        fxSlider.onValueChanged.RemoveListener(audioManager.SetFXVolume);
        gameloopSlider.onValueChanged.RemoveListener(audioManager.SetGameLoopVolume);
    }
    
}
