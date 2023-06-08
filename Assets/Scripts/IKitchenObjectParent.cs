using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKithenObjectParent
{
    public Transform GetCounterTopPoint();

    public void SetKitchenObject(KitchenObject kitchenObject);

    public KitchenObject GetKitchenObject();

    public void ClearKitchenObject();

    public bool HasKitchenObject();

}
