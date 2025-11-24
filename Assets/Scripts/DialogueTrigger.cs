using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue; // This holds the sentences
    public bool triggerOnStart = false; // Check this box for the Intro!

    void Start()
    {
        if (triggerOnStart)
        {
            if (GameGlobals.hasSeenIntro == false)
            {
                TriggerDialogue();
                GameGlobals.hasSeenIntro = true;
            }
            
        }
    }

    public void TriggerDialogue()
    {
        // Calls the Manager to show the box
        DialogueManager.Instance.StartDialogue(dialogue);
    }
}