using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{

    GameMaster gm;
    public Text dialogueText;

    private Queue<string> sentences;


    float nextTime = 0f;
    public float waitTime = 5f;
    public bool allDialogsDone = false;

    public Dialogue dialogue;
    public Dialogue pt1;
    public Dialogue pt2;
    public Dialogue pt3;
    public Dialogue pt4;


    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        sentences = new Queue<string>();
        StartDialogue(pt1);
    }

    private void Update()
    {
        if (Time.time >= nextTime)
        {
            NextSentence();
            nextTime = Time.time + waitTime;
        }
        if (allDialogsDone)
        {
            Debug.Log("Got Here");
            StartCoroutine(gm.p1());

            bool p1 = gm._p1;

            if (p1)
            {
                // start p2
                StartDialogue(pt2);
            }

            allDialogsDone = !allDialogsDone;
        }
    }



    public void StartDialogue(Dialogue dialogues)
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
        if (sentences.Count == 0)
        {
            allDialogsDone = true;
            return;
        }

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
