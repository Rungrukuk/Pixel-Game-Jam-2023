using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	private DialogueManager dialogueManager;

	private void Awake()
	{
		dialogueManager = GetComponent<DialogueManager>();
	}

	public void TriggerDialogue ()
	{
		dialogueManager.StartDialogue(dialogue);
	}

	public void NextSentence()
	{
		dialogueManager.DisplayNextSentence();
	}

}
