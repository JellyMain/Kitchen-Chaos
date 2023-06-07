using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{

    [SerializeField] Transform counterTopPoint;
    [SerializeField] ClearCounter secondCounter;
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    public bool testing;

    private KitchenObject kitchenObject;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && testing)
        {
            if (kitchenObject != null)
            {
                kitchenObject.SetClearCounter(secondCounter);
            }
        }
    }


    public void Interact()
    {
        if (kitchenObject == null)
        {
            GameObject kitchenObjectInstance = Instantiate(kitchenObjectSO.prefab, GetCounterTopPoint());
            kitchenObject = kitchenObjectInstance.GetComponent<KitchenObject>();

            kitchenObject.SetClearCounter(this);

        }
        else
        {
            Debug.Log(kitchenObject.GetClearCounter());
        }

    }


    public Transform GetCounterTopPoint()
    {
        return counterTopPoint;
    }

}
