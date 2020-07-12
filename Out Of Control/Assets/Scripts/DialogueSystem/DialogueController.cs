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

    /*
        public Dialogue dialogue;
        public Dialogue pt1;
        public Dialogue pt2;
        public Dialogue pt3;
        public Dialogue pt4;

        public int partRunning = 0;
        bool p1 = false;
        bool p2 = false;
        bool p3 = false;
        bool p4 = false;
    */

    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        sentences = new Queue<string>();
        /* StartDialogue(pt1);
         partRunning = 1;*/
    }

    private void Update()
    {
        if (Time.time >= nextTime)
        {
            NextSentence();
            nextTime = Time.time + waitTime;
        }
        /*
        p1 = gm._p1;
        p2 = gm._p2;
        p3 = gm._p3;
        p4 = gm._p4;


        if (allDialogsDone)
        {
            switch (partRunning)
            {
                case 1:
                    Debug.Log("P1 - Dialogs Done");
                    gm.p1();

                    if (p1)
                    {
                        Debug.Log("P1 - End");

                        // start p2
                        StartDialogue(pt2);
                        partRunning = 2;
                    }

                    break;
                case 2:
                    Debug.Log("P2 - Dialogs Done");
                    gm.p2();
                    if (p2)
                    {
                        Debug.Log("P2 - End");

                        //startDialogue
                        StartDialogue(pt3);
                        partRunning = 3;
                    }
                    break;
                case 3:
                    Debug.Log("P3 - Dialogs Done");
                    gm.p3();
                    if(p3)
                    {
                        Debug.Log("P3 - End");

                        //startDialogue
                        StartDialogue(pt4);
                        partRunning = 4;
                    }
                    break;
                case 4:
                    break;
            }

            allDialogsDone = !allDialogsDone;
        }
        */

    }



    public void StartDialogue(Dialogue dialogues)
    {
        Debug.Log("Dialog Running - " + dialogues.name);

        sentences.Clear();

        foreach (string sentence in dialogues.sentences)
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
