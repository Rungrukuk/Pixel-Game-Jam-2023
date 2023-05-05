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
    private float dialogueExitWaitTime = 0.1f;
    private int currentDialogueIndex;
    private void Awake()
    {
        currentDialogueIndex = 0;
        playerInRange = false;
        exclamationMark.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange)
        {
            if (InputHandler.GetInstance().interactInput && !isDialogPlaying)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJson[currentDialogueIndex]);
                isDialogPlaying = true;
            }

            if (isDialogPlaying && !DialogueManager.GetInstance().DialogueIsPlaying)
            {
                if (Time.time>=DialogueManager.GetInstance().DialogueExitStartTime + dialogueExitWaitTime)
                {
                    isDialogPlaying = false;
                    currentDialogueIndex++;
                }
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