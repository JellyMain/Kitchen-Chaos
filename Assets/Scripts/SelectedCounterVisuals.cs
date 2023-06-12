using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisuals : MonoBehaviour
{
    [SerializeField] BaseCounter baseCounter;
    [SerializeField] GameObject[] selectedCounterVisuals;

    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += ChangeCounterVisual;
    }

    private void ChangeCounterVisual(object sender, Player.OnSelectedCounterChangedArgs args)
    {
        if (args.baseCounter == baseCounter)
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
        foreach (GameObject gameObjectVisuals in selectedCounterVisuals)
        {
            gameObjectVisuals.SetActive(true);
        }
    }


    private void Hide()
    {
        foreach (GameObject gameObjectVisuals in selectedCounterVisuals)
        {
            gameObjectVisuals.SetActive(false);
        }
    }
}
