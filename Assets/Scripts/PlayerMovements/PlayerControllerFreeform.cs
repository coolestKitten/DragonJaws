using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

 [RequireComponent(typeof(Rigidbody)), DisallowMultipleComponent]
public class PlayerControllerFreeform : MonoBehaviour
    {
        [SerializeField] private float forwardMoveSpeed = 1f; 
        [SerializeField] private float backMoveSpeed = 1f; 
        [SerializeField] private float rotationSpeed = 100f; 
        [SerializeField] private float jumpForce = 10f; 
        
        private Rigidbody rb; 

        private RaycastHit hit; 
        [SerializeField] private bool isGrounded; 
        [SerializeField] private float groundRaycastDistance = 0.2f; 
        [SerializeField] private LayerMask groundLayerMask; 
        
        private float _walkVel; 
        public float WalkVel => _walkVel; 
        
        private float _lateralVel; 
        public float LateralVel => _lateralVel;
        
        private float yaw = 0f; 

        public bool isSprinting;
        
        public Action OnJump;
        public Action OnScream;
        public Action OnAttack;
        public Action OnDance;
        public Action OnDeath;
        public Action OnRevive;
        private bool isDead = false;

        private float _runMultiplier = 1f;
        private readonly float MAX_RUN_SPEED = 4f;

        private void OnEnable(){
            PauseGame.OnGamePaused += GamePaused;
        }

        private void OnDisable(){
            PauseGame.OnGamePaused -= GamePaused;
        }

        private void GamePaused(bool obj){
            Cursor.lockState = obj ? CursorLockMode.None : CursorLockMode.Locked; 
        }

        private void Start()
        {
            rb = GetComponent<Rigidbody>();
            isGrounded = true;
            
            Cursor.lockState = CursorLockMode.Locked; 
        }

        void OnTriggerEnter(Collider other){
            if(other.CompareTag("DeathBox")){
                isDead = true;
                OnDeath?.Invoke();
                transform.position = new Vector3(-33.1056f, 124.1313f, 348.2395f);

                
            }
        }

        private void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            isSprinting = Input.GetKey(KeyCode.LeftShift);

            
            if(verticalInput > 0)
                _walkVel = verticalInput * forwardMoveSpeed;
            else if(verticalInput < 0)
                _walkVel = verticalInput * backMoveSpeed;
            else
                _walkVel = 0;
            
            
            if (isSprinting && _runMultiplier < MAX_RUN_SPEED){
                _runMultiplier += Time.deltaTime * MAX_RUN_SPEED;
            } else if (!isSprinting && _runMultiplier > 1f){
                _runMultiplier -= Time.deltaTime * MAX_RUN_SPEED;
            }

            _walkVel *= _runMultiplier;
            _lateralVel = horizontalInput;

            
            Vector3 forwardMovement = transform.forward * _walkVel * Time.deltaTime;
            Vector3 lateralMovement = transform.right * _lateralVel * Time.deltaTime;

            
            Vector3 movement = forwardMovement + lateralMovement;
            
            
            rb.MovePosition(rb.position + movement);

            
            float mouseX = Input.GetAxis("Mouse X");
            yaw += mouseX * rotationSpeed * Time.deltaTime;

            
            transform.rotation = Quaternion.Euler(0f, yaw, 0f);

            
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false; 
                OnJump?.Invoke();
            }
            
            if (Input.GetKeyDown(KeyCode.E) && isGrounded)
            {
                OnScream?.Invoke();
            }

            if (Input.GetKeyDown(KeyCode.Q) && isGrounded)
            {
                OnAttack?.Invoke();
            }
            
            isGrounded = Physics.Raycast(transform.position, Vector3.down, groundRaycastDistance, groundLayerMask);

            if(isGrounded && Input.GetKeyDown(KeyCode.R) && isDead)
            {
                isDead = false;
                OnRevive?.Invoke();

            } 
            
            
        }
    }