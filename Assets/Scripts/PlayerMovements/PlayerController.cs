using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float forwardMoveSpeed = 2f;
    [SerializeField] private float backMoveSpeed = 2f;
    [SerializeField] private float rotationSpeed = 400f;
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody rb;
    private RaycastHit hit;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundRaycastDistance = 1f;
    [SerializeField] private LayerMask groundLayerMask;

    private float _walkVel;
    public float WalkVel => _walkVel;

    private float _lateralVel;
    public float LateralVel => _lateralVel;

    private float yaw = 0f;

    public Action OnJump;
    public Action OnSlide;
    public Action OnDance;

    public void Awake(){
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        if(VerticalInput > 0 ){
            _walkVel = VerticalInput * forwardMoveSpeed;
        } else if (VerticalInput < 0){
            _walkVel = VerticalInput * backMoveSpeed;
        } else {
            _walkVel = 0;
        }

        _lateralVel = HorizontalInput;

        Vector3 forwardMovement = transform.forward * _walkVel * Time.deltaTime;
        Vector3 lateralMovement = transform.right * _lateralVel * Time.deltaTime;

        Vector3 movement = forwardMovement + lateralMovement;

        rb.MovePosition(rb.position + movement);

        float mouseX = Input.GetAxis("Mouse X");
        yaw += mouseX * rotationSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0f, yaw, 0f);

        if(Input.GetButtonDown("Jump") && isGrounded){
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isGrounded = false;
            OnJump?.Invoke();

        }

        if(Input.GetKeyDown(KeyCode.C) && isGrounded){
            OnDance?.Invoke();

        }

        if(Input.GetKeyDown(KeyCode.Z) && isGrounded && _walkVel > 1){
            OnSlide?.Invoke();

        }

        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundRaycastDistance, groundLayerMask);

    }
}