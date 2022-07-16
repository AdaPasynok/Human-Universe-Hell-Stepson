using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    public float movementSpeed = 10f;

    private CharacterController characterController;
    private Vector3 movementDirection = Vector2.zero;
    private float lookHorizontalInput = 0f;
    private float lookVerticalInput = 0f;
    private float rotationSpeed = 0.1f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        characterController.SimpleMove(transform.TransformDirection(movementDirection) * movementSpeed);
        transform.Rotate(Vector3.up, lookHorizontalInput * rotationSpeed);
        float newRotationX = cameraTransform.localEulerAngles.x - lookVerticalInput * rotationSpeed;
        cameraTransform.localEulerAngles = new Vector3(newRotationX, 0f, 0f);
    }

    public void Move(InputAction.CallbackContext context) // Vector2
    {
        if (context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>().normalized;
            movementDirection = new Vector3(input.x, 0f, input.y);
        }
        else if (context.canceled)
        {
            movementDirection = Vector2.zero;
        }
    }

    public void LookHorizontal(InputAction.CallbackContext context) // Axis -> Delta/X [Mouse]
    {
        if (context.performed)
        {
            lookHorizontalInput = context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            lookHorizontalInput = 0f;
        }
    }

    public void LookVertical(InputAction.CallbackContext context) // Axis -> Delta/Y [Mouse]
    {
        if (context.performed)
        {
            lookVerticalInput = context.ReadValue<float>();
        }
        else if (context.canceled)
        {
            lookVerticalInput = 0f;
        }
    }
}
