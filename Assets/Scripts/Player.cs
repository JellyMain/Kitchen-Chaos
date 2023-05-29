using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] GameInput gameInput;
    [SerializeField] float moveSpeed = 15;
    [SerializeField] float rotateSpeed = 5;

    private bool isWalking;

    private void Update()
    {
        Vector2 inputVector = gameInput.GetInputNormilized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        isWalking = moveDirection != Vector3.zero;

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }



    public bool IsWalking()
    {
        return isWalking;
    }
}
