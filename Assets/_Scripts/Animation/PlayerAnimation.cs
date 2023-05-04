using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] PlayerInputHandler inputHandler;
    [SerializeField] SpriteRenderer playerSprite;

    private void Update()
    {
        if (inputHandler.NormalizedInputX>0)
        {
            playerSprite.flipX = false;
            animator.SetBool("isRightWalking",true);
            animator.SetBool("isUpWalking",false);
            animator.SetBool("isDownWalking",false);
        }
        else if (inputHandler.NormalizedInputX < 0)
        {
            playerSprite.flipX = true;
            animator.SetBool("isRightWalking",true);
            animator.SetBool("isUpWalking",false);
            animator.SetBool("isDownWalking",false);
        }
        else if (inputHandler.NormalizedInputY<0)
        {
            animator.SetBool("isUpWalking",false);
            animator.SetBool("isRightWalking",false);
            animator.SetBool("isDownWalking",true);
        }
        else if (inputHandler.NormalizedInputY>0)
        {
            animator.SetBool("isUpWalking",true);
            animator.SetBool("isRightWalking",false);
            animator.SetBool("isDownWalking",false);
        }
        else if (inputHandler.NormalizedInputX == 0 && inputHandler.NormalizedInputY == 0)
        {
            animator.SetBool("isUpWalking",false);
            animator.SetBool("isRightWalking",false);
            animator.SetBool("isDownWalking",false);
        }

    }
}
