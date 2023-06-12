using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerActions;
    public event EventHandler OnInteractAction;
    public event EventHandler OnAltInteraction;

    private void Awake()
    {
        playerActions = new PlayerInputActions();
        playerActions.Player.Enable();

        playerActions.Player.Interact.performed += Interact;
        playerActions.Player.InteractAlternate.performed += AltInteract;
    }


    private void Interact(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }


    private void AltInteract(InputAction.CallbackContext obj)
    {
        OnAltInteraction?.Invoke(this, EventArgs.Empty);
    }


    public Vector2 GetInputNormilized()
    {
        Vector2 inputVector = playerActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
