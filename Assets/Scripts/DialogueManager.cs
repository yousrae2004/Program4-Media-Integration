using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    private Queue<string> sentences;
    public static DialogueManager Instance;

    void Awake()
    {
        Instance = this;
        sentences = new Queue<string>();
    }

    void Start()
    {
        
        dialogueBox.SetActive(false);
    }

    void Update()
    {
        // Only listen for keys if the dialogue box is actually visible
        if (dialogueBox.activeInHierarchy)
        {
            // Advance Dialogue: ONLY when pressing Enter (Return)
            if (Input.GetKeyDown(KeyCode.Return))
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueBox.SetActive(true); 
        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            // replaces {player} with the name typed in the Main Menu
            string finalSentence = sentence.Replace("{player}", GameGlobals.playerName);
            sentences.Enqueue(finalSentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        // If no more sentences, close the box
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        dialogueBox.SetActive(false); 
    }
}