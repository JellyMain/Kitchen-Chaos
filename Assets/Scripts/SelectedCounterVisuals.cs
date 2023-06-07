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
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        selectedCounterVisuals.SetActive(true);
    }


    private void Hide()
    {
        selectedCounterVisuals.SetActive(false);
    }
}
