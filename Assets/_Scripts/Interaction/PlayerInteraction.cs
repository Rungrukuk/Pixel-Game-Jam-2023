using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler inputHandler;
    public Collider2D InteractedCollider { get; private set; }
    
    private bool canInteract;
    private bool hasInteracted;

    private void Update()
    {
        if (canInteract)
        {
            Debug.Log("Tap Enter to Listen Spirit");
            if (inputHandler.InteractInput && !hasInteracted)
            {
                hasInteracted = true;
                Debug.Log($"{InteractedCollider.gameObject.name} Says Hello");
            }
        }
    }
    

    private void OnTriggerEnter2D(Collider2D interactable)
    {
        Debug.Log("Entered");
        if (interactable.gameObject.CompareTag("Interactable"))
        {
            canInteract = true;
            InteractedCollider = interactable;
        }
    }


    
    private void OnTriggerExit2D(Collider2D interactable)
    {
        Debug.Log("Exited");
        if (interactable.gameObject.CompareTag("Interactable"))
        {
            canInteract = false;
            hasInteracted = false;
            InteractedCollider = null;
        }
    }
    
}
