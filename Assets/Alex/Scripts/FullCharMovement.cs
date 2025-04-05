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



    private void Awake()
    {
    }






    private void FixedUpdate()
    {
        playerGravityFunction();
        playerMoveFunction();
        playerJumpFunction();
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
        if(characterController.isGrounded && velocity.y < 0)
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
        Vector3 moveDirection = new Vector3(inputDirection.x, 0, inputDirection.y).normalized;
        currentSpeed = isSprinting ? sprintSpeed : walkSpeed;
        moveDirection = transform.TransformDirection(moveDirection);
        characterController.Move(moveDirection * currentSpeed * Time.fixedDeltaTime);
    }

    private void playerJumpFunction()
    {
        if(characterController.isGrounded && jumpInput.action.triggered)
        {
            velocity.y = (float)Math.Sqrt(jumpForce * 2f * gravity);
        }
    }
}
