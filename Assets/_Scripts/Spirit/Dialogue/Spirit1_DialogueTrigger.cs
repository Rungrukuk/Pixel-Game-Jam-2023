using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spirit1_DialogueTrigger : DialogueTrigger
{
    private int currentDialogueIndex;

    [SerializeField] private List<TextAsset> inkJson;

    private void Start()
    {
        currentDialogueIndex = 0;
    }

    private void Update()
    {
        if (PlayerInRange)
        {
            if (InputHandler.GetInstance().interactInput && !IsDialogPlaying)
            {
                if (inkJson.Count<=currentDialogueIndex)
                {
                    currentDialogueIndex = inkJson.Count-1;
                }

                DialogueManager.GetInstance().EnterDialogueMode(inkJson[currentDialogueIndex],name);
                IsDialogPlaying = true;
            }

            if (IsDialogPlaying && !DialogueManager.GetInstance().DialogueIsPlaying)
            {
                if (Time.time>=DialogueManager.GetInstance().DialogueExitStartTime + DialogueExitWaitTime)
                {
                    IsDialogPlaying = false;
                    if (currentDialogueIndex == 1)
                    {
                        StaticVariables.IsHideAndSeekActivated = true;
                    }
                    currentDialogueIndex++;
                }
            }
        }
    }
}
