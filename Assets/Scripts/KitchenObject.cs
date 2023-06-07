using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;


    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObject()
    {
        return kitchenObjectSO;
    }



    public void SetClearCounter(ClearCounter clearCounter)
    {
        this.clearCounter = clearCounter;
        transform.parent = clearCounter.GetCounterTopPoint();
        transform.localPosition = Vector3.zero;
    }


    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }

}
