using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerActions;

    private void Awake()
    {
        playerActions = new PlayerInputActions();
        playerActions.Player.Enable();
    }


    public Vector2 GetInputNormilized()
    {
        Vector2 inputVector = playerActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
}
