using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter, IKithenObjectParent
{
    [SerializeField] Transform counterTopPoint;
    [SerializeField] KitchenObjectSO kitchenObjectSO;

    private KitchenObject kitchenObject;

    public override void Interact(Player player)
    {
        if (kitchenObject == null)
        {
            GameObject spawnedKitchenObject = Instantiate(kitchenObjectSO.prefab, counterTopPoint);

            spawnedKitchenObject.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            kitchenObject.SetKitchenObjectParent(player);
        }
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
