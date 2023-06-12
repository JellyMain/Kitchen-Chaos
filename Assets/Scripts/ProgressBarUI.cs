using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{

    [SerializeField] CuttingCounter cuttingCounter;
    [SerializeField] Image barImage;


    private void Start()
    {
        cuttingCounter.OnProgressChanged += SetBarProgress;
        Hide();
    }

    private void SetBarProgress(object sender, CuttingCounter.OnProgressChangedArgs args)
    {
        barImage.fillAmount = args.normalizedProgress;
        if (args.normalizedProgress == 0 || args.normalizedProgress == 1)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }


    private void Hide()
    {
        gameObject.SetActive(false);
    }


    private void Show()
    {
        gameObject.SetActive(true);
    }
}
