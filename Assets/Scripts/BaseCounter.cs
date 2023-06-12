using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCounter : MonoBehaviour, IKithenObjectParent
{

    [SerializeField] Transform counterTopPoint;

    protected KitchenObject kitchenObject;

    public abstract void Interact(Player player);

    public virtual void AltInteract(Player player)
    {

    }


    public Transform GetCounterTopPoint()
    {
        return counterTopPoint;
    }


    public void SetKitchenObject(KitchenObject newKitchenObject)
    {
        this.kitchenObject = newKitchenObject;
    }


    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }


    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }


    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }

}
