using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PortraitGameplay : MonoBehaviour
{
    [SerializeField] private Sprite[] portraits;

    private Image image;
    private Quaternion initialRotation;
    private float offsetForward = -30f;
    private float offsetBack = 20f;
    private float offsetSides = -10f;

    private void Start()
    {
        image = GetComponent<Image>();
        initialRotation = transform.rotation;
    }

    public void SetPortrait(int index)
    {
        image.sprite = portraits[index];
    }

    public void PlayerMove(InputAction.CallbackContext context) // Vector2
    {
        if (context.performed)
        {
            Vector2 input = context.ReadValue<Vector2>();
            float offsetX = input.y > 0 ? offsetForward : input.y < 0 ? offsetBack : 0f;
            transform.rotation = Quaternion.Euler(offsetX, 0f, input.x * offsetSides);
        }
        else if (context.canceled)
        {
            transform.rotation = initialRotation;
        }
    }
}
