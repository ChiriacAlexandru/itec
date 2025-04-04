using UnityEngine;

public class CharMovement : MonoBehaviour
{
    [Header("Can Move Bools")]
    public bool canMoveLeft = true;
    public bool canMoveRight = true;
    public bool canJump = true;
    public bool canMove3d = false;

    [Header("Valori Movement")]
    [SerializeField] private float _charSpeed = 5f;
    [SerializeField] private float _jumpPower = 5f;
    [SerializeField] private CharacterController _characterController;

    private Vector3 _moveDirection = Vector3.zero;
    private float _gravity = -9.81f * 10;
    private float _verticalVelocity;

    private void Awake()
    {
        if (_characterController == null)
        {
            _characterController = GetComponent<CharacterController>();
        }
    }

    void Update()
    {
        if (canMove3d)
        {
            Complete3DMovement();
        }
        else
        {
            Complete2DMovement();
        }
    }

    private void Complete2DMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if ((!canMoveLeft && horizontalInput < 0) || (!canMoveRight && horizontalInput > 0))
        {
            horizontalInput = 0;
        }
            _verticalVelocity += _gravity * Time.deltaTime;

        if (_characterController.isGrounded && canJump && Input.GetKeyDown(KeyCode.Space))
        {
            _verticalVelocity = _jumpPower;
        }

        Vector3 move = new Vector3(horizontalInput * _charSpeed, _verticalVelocity, 0f);
        _characterController.Move(move * Time.deltaTime);
    }

    private void Complete3DMovement()
    {
    }
}
