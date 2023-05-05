using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Ink JSON")]
    [SerializeField] private GameObject exclamationMark;
    private bool playerInRange;

    [SerializeField] private List<TextAsset> inkJson;

    private bool isDialogPlaying;

    private void Awake()
    {
        playerInRange = false;
        exclamationMark.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (InputHandler.GetInstance().interactInput && !isDialogPlaying)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJson[0]);
                isDialogPlaying = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isDialogPlaying = false;
            exclamationMark.SetActive(true);
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isDialogPlaying = false;
            exclamationMark.SetActive(false);
            playerInRange = false;
        }
    }
}