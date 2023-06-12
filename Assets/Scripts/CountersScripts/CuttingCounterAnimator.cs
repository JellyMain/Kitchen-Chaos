using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCoutnerAnimator : MonoBehaviour
{
    private const string CUT = "Cut";
    private Animator animator;

    [SerializeField] CuttingCounter cuttingCounter;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        cuttingCounter.OnCutting += PlayCuttingAnimation;
    }


    private void PlayCuttingAnimation(object sender, System.EventArgs args)
    {
        animator.SetTrigger(CUT);
    }

}
