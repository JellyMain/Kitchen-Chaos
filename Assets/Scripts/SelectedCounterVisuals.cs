using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisuals : MonoBehaviour
{
    [SerializeField] ClearCounter clearCounter;
    [SerializeField] GameObject selectedCounterVisuals;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += ChangeCounterVisual;
    }

    private void ChangeCounterVisual(object sender, Player.OnSelectedCounterChangedArgs args)
    {
        if (args.selectedCounter == clearCounter)
        {
            selectedCounterVisuals.SetActive(true);
        }
        else
        {
            selectedCounterVisuals.SetActive(false);
        }
    }

}
