using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler inputHandler;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float movementSpeed;
    private void Update()
    {
        rb.velocity = new Vector2(inputHandler.NormalizedInputX * movementSpeed,
            inputHandler.NormalizedInputY * movementSpeed);
    }
}
