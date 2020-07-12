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
    void Start()
    {
        diac = FindObjectOfType<DialogueController>();
        d = GetComponent<Dialogue>();
        dc = FindObjectOfType<DogController>();
        cs = FindObjectOfType<CarSpawner>();

        cs.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!dialogueRunning)
        {
            // enter pre dialog code here
            dc.controlsOn =false;
            diac.StartDialogue(d);
            dialogueRunning = true;
            cs.gameObject.SetActive(false);
        }
        if(diac.allDialogsDone)
        {
            dc.controlsOn = false;
            dialogueFinished = true;
            dialogueRunning = false;
            cs.gameObject.SetActive(false);
        }

        if(dialogueFinished)
        {
            // enter post dialogue code here
            dc.controlsOn = true;
                
            cs.gameObject.SetActive(true);

            // end post dialog code
        
            CodeFinished = true;
            dialogueFinished = false;
        
        }
    }
}
