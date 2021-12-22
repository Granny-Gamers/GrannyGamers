using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    // Variables for targeting the text objects.
    public Text nameText;
    public Text dialogueText;

    public float typingDelay = 0.01f;

    private Queue<string> sentences;    

    // Start is called before the first frame update.
    void Start()
    {
        sentences = new Queue<string>();
    }

    // Loads the dialogue into the dialogue manager and displays the first sentence.
    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        
        sentences.Clear();

        // Loads all sentences.
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();

    }

    // Displays the next sentence.
    public void DisplayNextSentence()
    {
        Debug.Log(sentences.Count);

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    // Animates the typing of the sentence.
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        // Iterates through each character in the sentence, updating the dialogue and pausing per each iteration.
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            //yield return null;
            yield return new WaitForSeconds(typingDelay);
        }
    }

    // Indicates that the dialogue has ended.
    private void EndDialogue()
    {
        return;
    }
}
