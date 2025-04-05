using UnityEngine;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{
    [Header("Componente necesare")]
    [SerializeField] private Animator animator;
    [SerializeField] private InputActionReference moveInput;
    [SerializeField] private CameraScript cameraScript;

    private void OnEnable()
    {
        moveInput.action.Enable();
    }

    private void OnDisable()
    {
        moveInput.action.Disable();
    }

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        Vector2 inputDirection = moveInput.action.ReadValue<Vector2>();

        Vector3 moveDirection = (cameraScript.GetCameraForward() * inputDirection.y + cameraScript.GetCameraRight() * inputDirection.x).normalized;

        Vector2 animationDirection = new Vector2(moveDirection.x, moveDirection.z);

        animator.SetFloat("moveX", animationDirection.x);
        animator.SetFloat("moveY", animationDirection.y);
        animator.SetBool("isMoving", animationDirection.sqrMagnitude > 0.01f);
    }
}
