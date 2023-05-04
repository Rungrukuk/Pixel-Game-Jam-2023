using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private PlayerInputHandler inputHandler;
    public Collider2D InteractedCollider { get; private set; }
    
    private bool canInteract = false;
    private bool hasInteracted = false;
    private bool inDialogue = false;
    
    private void Update()
    {
        if (canInteract)
        {
            if (inputHandler.InteractInput && inDialogue && !hasInteracted)
            {
                InteractedCollider.GetComponent<DialogueTrigger>().NextSentence();
                hasInteracted = true;
            }
            if (inputHandler.InteractInput && !hasInteracted && !inDialogue)
            {
                hasInteracted = true;
                InteractedCollider.GetComponent<DialogueTrigger>().TriggerDialogue();
                inDialogue = true;
            }
        }
        if (!inputHandler.InteractInput && hasInteracted)
        {
            hasInteracted = false;
        }
    }
    

    private void OnTriggerEnter2D(Collider2D interactable)
    {
        if (interactable.gameObject.CompareTag("Interactable"))
        {
            canInteract = true;
            InteractedCollider = interactable;
        }
    }
    
    private void OnTriggerExit2D(Collider2D interactable)
    {
        if (interactable.gameObject.CompareTag("Interactable"))
        {
            canInteract = false;
            hasInteracted = false;
            InteractedCollider = null;
            inDialogue = false;
        }
    }
    
}
