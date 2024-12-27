using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, PlayerInput.IPlayerActions
{
    public event Action JumpEvent;
    public event Action DodgeEvent;

    public Vector2 MoveVector {  get; private set; }

    private PlayerInput playerInput;
    private void Start() {
        playerInput = new PlayerInput();
        playerInput.Player.SetCallbacks(this);
        playerInput.Player.Enable();
    }

    private void OnDestroy() {
        playerInput.Player.Disable();
    }

    public void OnJump(InputAction.CallbackContext context) {
        if (!context.performed) {
            return;
        }

        JumpEvent?.Invoke();
    }

    public void OnDodge(InputAction.CallbackContext context) {
        if (!context.performed) {
            return;
        }

        DodgeEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context) {
        MoveVector = context.ReadValue<Vector2>();
    }
}
