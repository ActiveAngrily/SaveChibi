using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{

    public Text dialogueText;

    private Queue<string> sentences;

    public Dialogue dialogue;

    float nextTime = 0f;
    public float waitTime = 5f;
    void Start()
    {
        sentences = new Queue<string>();
        StartDialogue(dialogue);
    }

    private void Update()
    {
        if (Time.time >= nextTime)
        {
            NextSentence();
            nextTime = Time.time + waitTime;
            
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        nextTime = Time.time;


    }

    public void NextSentence()
    {
        if (sentences.Count == 0) return;

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            /*for(int i = 0; i < 8; i++)
            {
                yield return null;
            }*/
            yield return null;
        }
    }
}
