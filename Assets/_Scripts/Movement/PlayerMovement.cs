using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float movementSpeed;

    private void Update()
    {
        if (!DialogueManager.GetInstance().DialogueIsPlaying)
        {
            rb.velocity = new Vector2(InputHandler.GetInstance().normalizedInputX * movementSpeed,
                InputHandler.GetInstance().normalizedInputY * movementSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}