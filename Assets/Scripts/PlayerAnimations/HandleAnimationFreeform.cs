using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), DisallowMultipleComponent]
    public class HandleAnimationFreeform : MonoBehaviour
    {
        private Animator _animator;
        private PlayerControllerFreeform _playerMovement;

        private static readonly int ForwardWalkVel = Animator.StringToHash("ForwardWalkVel");
        private static readonly int LateralWalkVel = Animator.StringToHash("LateralWalkVel");

        private void OnEnable()
        {
            _playerMovement = GetComponent<PlayerControllerFreeform>();
            _animator = GetComponent<Animator>();
            
            _playerMovement.OnJump += Jump;
            _playerMovement.OnScream += Scream;
            _playerMovement.OnAttack += Attack;
            _playerMovement.OnDeath += Die;
            _playerMovement.OnRevive += Stand;
        }

        private void OnDisable()
        {
            _playerMovement.OnJump -= Jump;
            _playerMovement.OnScream -= Scream;
            _playerMovement.OnAttack -= Attack;
            _playerMovement.OnDeath -= Die;
            _playerMovement.OnRevive += Stand;
        }

        private void Update()
        {
            _animator.SetFloat(ForwardWalkVel, _playerMovement.WalkVel);
            _animator.SetFloat(LateralWalkVel, _playerMovement.LateralVel);
        }
        
        private void Jump()
        {
            _animator.SetTrigger("Jump");
        }

        

        private void Attack()
        {
            _animator.SetTrigger("Attack");
        }

        private void Scream()
        {
            _animator.SetTrigger("Scream");
        }

        private void Die(){
            _animator.SetTrigger("Die");

        }

        private void Stand(){
            _animator.SetTrigger("Stand");
        }
    }
