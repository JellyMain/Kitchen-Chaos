using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;


    private IKithenObjectParent kitchenObjectParent;

    public KitchenObjectSO GetKitchenObject()
    {
        return kitchenObjectSO;
    }


    public void SetKitchenObjectParent(IKithenObjectParent newKitchenObjectParent)
    {
        if (kitchenObjectParent != null)
        {
            kitchenObjectParent.ClearKitchenObject();
        }

        kitchenObjectParent = newKitchenObjectParent;

        if (newKitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("Counter already has object");
        }

        newKitchenObjectParent.SetKitchenObject(this);

        transform.parent = kitchenObjectParent.GetCounterTopPoint();
        transform.localPosition = Vector3.zero;
    }



    public IKithenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }

}
