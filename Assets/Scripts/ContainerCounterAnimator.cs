using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterAnimator : MonoBehaviour
{
    private const string OPEN_CLOSE = "OpenClose";
    private Animator animator;

    [SerializeField] ContainerCounter containerCounter;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        containerCounter.OnContainerOpened += PlayOpenAnimation;
    }


    private void PlayOpenAnimation(object sender, System.EventArgs args)
    {
        animator.SetTrigger(OPEN_CLOSE);
    }

}
