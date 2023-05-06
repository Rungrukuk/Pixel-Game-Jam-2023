using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{    
    [SerializeField] private GameObject exclamationMark;

    protected bool PlayerInRange;
    protected bool IsDialogPlaying;
    protected float DialogueExitWaitTime = 0.1f;

    private void Awake()
    {
        PlayerInRange = false;
        exclamationMark.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            IsDialogPlaying = false;
            exclamationMark.SetActive(true);
            PlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            IsDialogPlaying = false;
            exclamationMark.SetActive(false);
            PlayerInRange = false;
        }
    }
}