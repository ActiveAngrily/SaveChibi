using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part1Dialog : MonoBehaviour
{

    DialogueController diac;
    Dialogue d;

    DogController dc;
    CarSpawner cs;

    bool dialogueRunning = false;
    bool dialogueFinished = false;
    public bool CodeFinished = false;

    float nextTime = 0f;
    public float spawnerRuntime = 5f;
    void Start()
    {

    }

    void Awake()
    {
        diac = FindObjectOfType<DialogueController>();
        d = GetComponent<Dialogue>();
        dc = FindObjectOfType<DogController>();
        cs = FindObjectOfType<CarSpawner>();

        cs.gameObject.SetActive(false);

        if (!dialogueRunning)
        {
            // enter pre dialog code here
            dc.controlsOn = false;
            diac.StartDialogue(d);
            dialogueRunning = true;
            cs.gameObject.SetActive(false);
        }

    }
    void Update()
    {
        if(diac.allDialogsDone) dialogueFinished = true;
        if (dialogueFinished)
        {
            // enter post dialogue code here
            dc.controlsOn = true;

            cs.gameObject.SetActive(true);
            nextTime = Time.time + spawnerRuntime;

            // end post dialog code
            dialogueFinished = false;
        }
        if (nextTime > 0 && Time.time > nextTime)
        {
            Debug.Log("Test");
            cs.gameObject.SetActive(false);
            CodeFinished = true;

        }
    }
}
