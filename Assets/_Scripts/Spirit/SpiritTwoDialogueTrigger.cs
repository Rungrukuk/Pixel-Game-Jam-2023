using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritTwoDialogueTrigger : DialogueTrigger
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
                    IsDialogPlaying = false;
                    currentDialogueIndex++;
                    
                }
            }
            if (InputHandler.GetInstance().interactInput && !IsDialogPlaying)
            {
                Debug.Log(currentDialogueIndex);
                DialogueManager.GetInstance().EnterDialogueMode(inkJson[currentDialogueIndex]);
                IsDialogPlaying = true;
            }
        }
    }
}
