using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static Action<bool> OnGamePaused;
    private bool isPaused;
    void Start()
    {
        isPaused = false;
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            isPaused = !isPaused;
            OnGamePaused?.Invoke(isPaused);
        }
    }
}
