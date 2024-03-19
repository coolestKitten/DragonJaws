using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleAnimation : MonoBehaviour
{
    private Animator _animator;
    private PlayerController _playerMovement;

    public static readonly int ForwardWalkVel = Animator.StringToHash("ForwardWalkVel");
    public static readonly int SidewaysWalkVel = Animator.StringToHash("SidewaysWalkVel");
    private void OnEnable(){
        _playerMovement = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();

        _playerMovement.OnJump += Jump;
        _playerMovement.OnDance += Dance;
        _playerMovement.OnSlide += Slide;
    }
    // Start is called before the first frame update
    void OnDisable(){
        _playerMovement.OnJump -= Jump;
        _playerMovement.OnDance -= Dance;
        _playerMovement.OnSlide -= Slide;
    }

    private void Jump()
    {
        _animator.SetTrigger("OnJump");
    }
    
    private void Dance()
    {
        _animator.SetTrigger("OnDance");
    }

    private void Slide()
    {
        _animator.SetTrigger("OnSlide");
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat(ForwardWalkVel, _playerMovement.WalkVel);
        _animator.SetFloat(SidewaysWalkVel, _playerMovement.LateralVel);
    }
}
