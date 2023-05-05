using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private PlayerInput playerInput;

    public Vector2 rawMovementInput { get; private set; }
    public bool interactInput { get; private set; }
    public int normalizedInputX { get; private set; }
    public int normalizedInputY { get; private set; }

    public static InputHandler instanceInputHandler;

    private void Awake()
    {
        if (instanceInputHandler!=null)
        {
            Debug.LogWarning("You got more than one input handler instance");
        }

        instanceInputHandler = this;
    }

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    
    public static InputHandler GetInstance()
    {
        return instanceInputHandler;
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        rawMovementInput = context.ReadValue<Vector2>();
        rawMovementInput.Normalize();
        if (Mathf.Abs(rawMovementInput.x) > 0.5f)
            normalizedInputX = (int)(rawMovementInput.x * Vector2.right).normalized.x;
        else
            normalizedInputX = 0;
        
        if(Mathf.Abs(rawMovementInput.y)>0.5f)
            normalizedInputY = (int)(rawMovementInput.y * Vector2.up).normalized.y;
        else
            normalizedInputY = 0;
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            interactInput = true;
        }
        if (context.canceled)
        {
            interactInput = false;
        }
    }
}
