using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer playerSprite;

    private void Update()
    {
        if (!DialogueManager.GetInstance().DialogueIsPlaying)
        {
            if (InputHandler.GetInstance().normalizedInputX > 0)
            {
                playerSprite.flipX = false;
                animator.SetBool("isRightWalking", true);
                animator.SetBool("isUpWalking", false);
                animator.SetBool("isDownWalking", false);
            }
            else if (InputHandler.GetInstance().normalizedInputX < 0)
            {
                playerSprite.flipX = true;
                animator.SetBool("isRightWalking", true);
                animator.SetBool("isUpWalking", false);
                animator.SetBool("isDownWalking", false);
            }
            else if (InputHandler.GetInstance().normalizedInputY < 0)
            {
                animator.SetBool("isUpWalking", false);
                animator.SetBool("isRightWalking", false);
                animator.SetBool("isDownWalking", true);
            }
            else if (InputHandler.GetInstance().normalizedInputY > 0)
            {
                animator.SetBool("isUpWalking", true);
                animator.SetBool("isRightWalking", false);
                animator.SetBool("isDownWalking", false);
            }
            else if (InputHandler.GetInstance().normalizedInputX == 0 &&
                     InputHandler.GetInstance().normalizedInputY == 0)
            {
                animator.SetBool("isUpWalking", false);
                animator.SetBool("isRightWalking", false);
                animator.SetBool("isDownWalking", false);
            }
        }
        else
        {
            animator.SetBool("isUpWalking", false);
            animator.SetBool("isRightWalking", false);
            animator.SetBool("isDownWalking", false);
        }
    }
}