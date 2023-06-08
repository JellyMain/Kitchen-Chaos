using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour, IKithenObjectParent
{

    public event EventHandler<OnSelectedCounterChangedArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedArgs : EventArgs
    {
        public BaseCounter baseCounter;
    }

    public static Player Instance { get; private set; }

    [SerializeField] GameInput gameInput;
    [SerializeField] float moveSpeed = 15;
    [SerializeField] float rotateSpeed = 5;
    [SerializeField] LayerMask interactLayerMask;
    [SerializeField] Transform handsPoint;
    private bool isWalking;
    private BaseCounter baseCounter;

    private KitchenObject heldObject;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("something wrong");
        }
        Instance = this;
    }


    private void Start()
    {
        gameInput.OnInteractAction += SelectedCounterInteraction;
    }


    private void SelectedCounterInteraction(object sender, System.EventArgs args)
    {
        if (baseCounter != null)
        {
            baseCounter.Interact(this);
        }
    }


    private void Update()
    {
        HandleMovement();
        HandleInteraction();
    }


    private void HandleInteraction()
    {
        float interactDistance = 2f;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit raycastHit, interactDistance, interactLayerMask))
        {
            if (raycastHit.transform.TryGetComponent(out BaseCounter baseCounter))
            {
                if (baseCounter != this.baseCounter)
                {
                    SetSelectedCounter(baseCounter);
                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
    }


    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetInputNormilized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        isWalking = moveDirection != Vector3.zero;


        float moveDistance = moveSpeed * Time.deltaTime;
        float playerHeight = 2f;
        float playerRadius = 0.7f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance);


        if (!canMove)
        {
            Vector3 moveDirX = new Vector3(moveDirection.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                moveDirection = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDirection.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    moveDirection = moveDirZ;
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotateSpeed * Time.deltaTime);
    }


    public bool IsWalking()
    {
        return isWalking;
    }


    private void SetSelectedCounter(BaseCounter baseCounter)
    {
        this.baseCounter = baseCounter;

        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedArgs
        {
            baseCounter = baseCounter
        });
    }


    public Transform GetCounterTopPoint()
    {
        return handsPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        heldObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return heldObject;
    }

    public void ClearKitchenObject()
    {
        heldObject = null;
    }

    public bool HasKitchenObject()
    {
        if (heldObject != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
