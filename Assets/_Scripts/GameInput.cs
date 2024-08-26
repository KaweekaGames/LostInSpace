using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = new PlayerInput();
        playerInput.Player.Enable();
    }
    public float GetFirePressed()
    {
        float firedPressed = playerInput.Player.Fire.ReadValue<float>();
        return firedPressed;
    }

    public float GetRotation()
    {
        Vector2 movement = playerInput.Player.Movement.ReadValue<Vector2>();
        float rotationValue = movement.x;
        return rotationValue;
    }

    public float GetJumpPressed()
    {
        float jumpPressed = playerInput.Player.Jump.ReadValue<float>();
        return jumpPressed;
    }
}
