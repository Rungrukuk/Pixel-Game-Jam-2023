using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")] 
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices")] 
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    
    
    private Story currentStory;
    
    private static DialogueManager _instance;

    public bool DialogueIsPlaying { get; private set; }

    
    private bool hasInteracted;

    public float DialogueExitStartTime { get; private set; }
    
    public int CurrentDialogueIndex { get; private set; }


    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Found more than one dialogue manager");
        }
        _instance = this;
    }

    private void Start()
    {
        CurrentDialogueIndex = 0;
        hasInteracted = false;
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;

        foreach (var choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!DialogueIsPlaying)
        {
            return;
        }

        if (InputHandler.GetInstance().interactInput && !hasInteracted)
        {
            ContinueStory();

            hasInteracted = true;
        }

        if (!InputHandler.GetInstance().interactInput && hasInteracted)
        {
            hasInteracted = false;
        }
        
    }

    public static DialogueManager GetInstance()
    {
        return _instance;
    }

    public void EnterDialogueMode(TextAsset inkJson)
    {
        currentStory = new Story(inkJson.text);
        DialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }


    public void ExitDialogueMode()
    {
        CurrentDialogueIndex++;
        DialogueExitStartTime = Time.time;
        DialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }
    
    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
            DisplayChoices();
        }
        else
        {
            ExitDialogueMode();
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        if (currentChoices.Count>choices.Length)
        {
            Debug.LogError("More choices were given than UI can support. Number of choices given:" + currentChoices.Count);
        }

        int index = 0;
        foreach (var choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
    }
    
}