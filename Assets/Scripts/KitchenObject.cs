using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    private IKithenObjectParent kitchenObjectParent;



    public static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKithenObjectParent kithenObjectParent)
    {
        GameObject spawnedObject = Instantiate(kitchenObjectSO.prefab);
        KitchenObject spawnedKitchenObject = spawnedObject.GetComponent<KitchenObject>();
        spawnedKitchenObject.SetKitchenObjectParent(kithenObjectParent);
        return spawnedKitchenObject;
    }


    public KitchenObjectSO GetKitchenObjectSO()
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


    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }
}
