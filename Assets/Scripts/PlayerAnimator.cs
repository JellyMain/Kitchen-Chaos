using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    [SerializeField] Animator animator;
    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }


    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());
    }


}
