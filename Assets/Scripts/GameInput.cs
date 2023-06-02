using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerActions;
    public event EventHandler OnInteractAction;

    private void Awake()
    {
        playerActions = new PlayerInputActions();
        playerActions.Player.Enable();

        playerActions.Player.Interact.performed += Interact;
    }


    private void Interact(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetInputNormilized()
    {
        Vector2 inputVector = playerActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
