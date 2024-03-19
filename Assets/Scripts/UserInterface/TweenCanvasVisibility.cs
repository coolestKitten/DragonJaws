using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenCanvasVisibility : MonoBehaviour
{
    private CanvasGroup _canvasGroup;

    void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        CanvasVisibility(false, 0, 0);
        PauseGame.OnGamePaused += GamePaused;
    }

    private void OnDestroy(){
        PauseGame.OnGamePaused -= GamePaused;
    }

    private void GamePaused(bool _isPaused){
        var alpha = _isPaused ? 1 : 0;
        CanvasVisibility(_isPaused, alpha, 1f);
    }

    public void CanvasVisibility(bool active, float alphaValue, float animTime){
        _canvasGroup.interactable = active;
        LeanTween.alphaCanvas(_canvasGroup, alphaValue, animTime);
    }
}
