using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioEvents : HandleFeetNoises
{
    [SerializeField] public PlayerControllerFreeform _playerMovement;

    public AudioClip screamClip;
    public AudioClip attackClip;

    public AudioClip deathClip;
    public AudioClip reviveClip;

    private new void OnEnable(){
        base.OnEnable();
        _playerMovement.OnScream += PlayScream;
        _playerMovement.OnAttack += PlayGroanAttack;
        _playerMovement.OnDeath += PlayDeathSound;
        _playerMovement.OnRevive += PlayStandUpSound;
    }

    private void OnDisable(){
        
        _playerMovement.OnScream -= PlayScream;
        _playerMovement.OnAttack -= PlayGroanAttack;
        _playerMovement.OnDeath -= PlayDeathSound;
        _playerMovement.OnRevive -= PlayStandUpSound;
    }
    void Start()
    {
        audioClip = null;
    }

    private void PlayScream (){
        audioClip = screamClip;
        audioSource.PlayOneShot(audioClip);
    }

    private void PlayGroanAttack (){
        audioClip = attackClip;
        audioSource.PlayOneShot(audioClip);
    }
    
    private void PlayDeathSound (){
        audioClip = deathClip;
        audioSource.PlayOneShot(audioClip);
    }

    private void PlayStandUpSound(){
        audioClip = reviveClip;
        audioSource.PlayOneShot(audioClip);
    }
}
