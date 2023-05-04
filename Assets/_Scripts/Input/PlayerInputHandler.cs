using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInput playerInput;

    public Vector2 RawMovementInput { get; private set; }
    public bool InteractInput { get; private set; }
    public int NormalizedInputX { get; private set; }
    public int NormalizedInputY { get; private set; }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector2>();
        RawMovementInput.Normalize();
        if (Mathf.Abs(RawMovementInput.x) > 0.5f)
            NormalizedInputX = (int)(RawMovementInput.x * Vector2.right).normalized.x;
        else
            NormalizedInputX = 0;
        
        if(Mathf.Abs(RawMovementInput.y)>0.5f)
            NormalizedInputY = (int)(RawMovementInput.y * Vector2.up).normalized.y;
        else
            NormalizedInputY = 0;
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            InteractInput = true;
        }
        if (context.canceled)
        {
            InteractInput = false;
        }
    }
}
