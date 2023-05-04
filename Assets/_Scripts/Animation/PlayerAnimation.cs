using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] private Rigidbody2D rb;

    private void Update()
    {
        if (rb.velocity.y>0)
        {
            animator.SetBool("isUpWalking",true);
            animator.SetBool("isDownWalking",false);
        }
        else if (rb.velocity.y<0)
        {
            animator.SetBool("isUpWalking",false);
            animator.SetBool("isDownWalking",true);
        }
        else
        {
            animator.SetBool("isUpWalking",false);
            animator.SetBool("isDownWalking",false);
        }

    }
}
