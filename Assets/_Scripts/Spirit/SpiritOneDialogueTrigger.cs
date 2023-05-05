using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritOneDialogueTrigger : DialogueTrigger
{
    private int currentDialogueIndex;
    private void Start()
    {
        currentDialogueIndex = 0;
        PlayerInRange = false;
        exclamationMark.SetActive(false);
    }
    private void Update()
    {
        if (PlayerInRange)
        {
            if (IsDialogPlaying && !DialogueManager.GetInstance().DialogueIsPlaying)
            {
                if (Time.time>=DialogueManager.GetInstance().DialogueExitStartTime + DialogueExitWaitTime)
                {
                    Debug.Log(currentDialogueIndex);
                    IsDialogPlaying = false;
                    currentDialogueIndex++;
                }
            }
            if (InputHandler.GetInstance().interactInput && !IsDialogPlaying)
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJson[currentDialogueIndex]);
                IsDialogPlaying = true;
            }
        }
    }
}
