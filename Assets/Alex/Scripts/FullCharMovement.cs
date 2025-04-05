using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class FullCharMovement : MonoBehaviour
{
    [Header("Sistem de input")]
    [SerializeField] private InputActionReference moveInput;
    [SerializeField] private InputActionReference jumpInput;
    [SerializeField] private InputActionReference sprintInput;

    [Header("Variabile de mișcare")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float sprintSpeed = 8f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask canJump;

    private bool jumpRequested;
    private bool isGrounded;
    private bool isSprinting;
    private float currentSpeed;

    [Header("Componente joc")]
    private Rigidbody rb;
    [SerializeField] private CameraScript cameraScript;
    [SerializeField] private CameraFollow2D cameraMovement;

    public bool canRight;
    public bool canForward;
    public bool can2D;
    public bool canRotate2D;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        canRotate2D = false;
    }

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

        sprintInput.action.performed -= _ => isSprinting = true;
        sprintInput.action.canceled -= _ => isSprinting = false;
    }

    private void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance + 0.1f, canJump);

        if (isGrounded && jumpInput.action.WasPerformedThisFrame())
        {
            jumpRequested = true;
        }

        if (Input.GetKeyDown(KeyCode.F) && canRotate2D)
        {
            cameraMovement.cameraMove();
        }
    }

    private void FixedUpdate()
    {
        HandleMovement();

        if (jumpRequested)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z); // reset Y
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpRequested = false;
        }
    }

    private void HandleMovement()
    {
        Vector2 input = moveInput.action.ReadValue<Vector2>();

        if (!canForward)
            input.y = 0;
        if (!canRight)
            input.x = 0;
        if (!can2D && input.x < 0)
            input.x = 0;

        Vector3 direction = (cameraScript.GetCameraForward() * input.y + cameraScript.GetCameraRight() * input.x).normalized;
        currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        Vector3 move = direction * currentSpeed;
        move.y = rb.linearVelocity.y; // preserve vertical velocity

        rb.linearVelocity = move;
    }
}
