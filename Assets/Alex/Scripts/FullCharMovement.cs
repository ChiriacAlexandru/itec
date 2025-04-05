using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class FullCharMovement : MonoBehaviour
{
    [Header("Sistem de input")]
    [SerializeField] private InputActionReference moveInput;
    [SerializeField] private InputActionReference jumpInput;
    [SerializeField] private InputActionReference sprintInput;


    [Header("Variabile de miscare")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = -15f;




    [Header("Componente Joc")]
    [SerializeField] private CharacterController characterController;
    private Vector3 velocity;
    private bool isSprinting;
    private float currentSpeed;
    [SerializeField] private CameraScript cameraScript;
    [SerializeField] private CameraFollow2D cameraMovement;
    [SerializeField] private Animator animator;
    public bool canRight;
    public bool canForward;
    public bool can2D;


    private void Awake()
    {
    }






    private void FixedUpdate()
    {
        
        playerGravityFunction();
        playerMoveFunction();
        playerJumpFunction();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            cameraMovement.cameraMove();
        }
    }
    //aici citim inputurile / nu stergeti nimic de aici!!!!!!
    private void OnEnable()
    {
        moveInput.action.Enable();
        jumpInput.action.Enable();
        sprintInput.action.Enable();

        sprintInput.action.performed += _ => isSprinting = true;
        sprintInput.action.canceled += _ => isSprinting = false;
    }

    private void OnDisable()
    {
        moveInput.action.Disable();
        jumpInput.action.Disable();
        sprintInput.action.Disable();
    }

    // functie pentru a activa gravitatie unui character controller
    private void playerGravityFunction()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.fixedDeltaTime;
        characterController.Move(velocity * Time.fixedDeltaTime);
    }
    // functie de movement la jucator, se poate modifica conform dorintelor ulterioare
    private void playerMoveFunction()
    {
        Vector2 inputDirection = moveInput.action.ReadValue<Vector2>();

        if(canForward == false)
        {
            inputDirection.y = 0;
        }

        if(canRight == false)
        {
            inputDirection.x = 0;
        }

        if(can2D == false)
        {
            if (inputDirection.x < 0)
                inputDirection.x = 0;
        }
        Vector3 moveDirection = (cameraScript.GetCameraForward() * inputDirection.y + cameraScript.GetCameraRight() * inputDirection.x).normalized;

        currentSpeed = isSprinting ? sprintSpeed : walkSpeed;
        characterController.Move(moveDirection * currentSpeed * Time.fixedDeltaTime);
    }

    private void playerJumpFunction()
    {
        if (characterController.isGrounded && jumpInput.action.triggered)
        {
            velocity.y = (float)Math.Sqrt(jumpForce * -2f * gravity);
        }
    }


    private void animationController()
    {
        
    }
}
