using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Part2Dialog : MonoBehaviour
{

    DialogueController diac;
    Dialogue d;

    DogController dc;
    CarSpawner cs;

    Text devText;

    public bool dialogueRunning = false;
    public bool dialogueFinished = false;
    public bool CodeFinished = false;

    float nextTime = 0f;
    public float spawnerRuntime = 5f;

    void Awake()
    {
        diac = FindObjectOfType<DialogueController>();
        d = GetComponent<Dialogue>();
        dc = FindObjectOfType<DogController>();
        cs = FindObjectOfType<CarSpawner>();
        devText = FindObjectOfType<Text>();
        dc.CancelAllMotion();
        cs.gameObject.SetActive(false);
        diac.allDialogsDone = false;
        if (!dialogueRunning)
        {
            // enter pre dialog code here
            dc.controlsOn = false;
            diac.StartDialogue(d);
            dialogueRunning = true;
            cs.gameObject.SetActive(false);
        }

    }
    bool oneRun = false;
    void Update()
    {
        if (diac.allDialogsDone)
        {
            if (!oneRun)
            {
                dialogueFinished = true;
                oneRun = true;
            }
        }
        if (dialogueFinished)
        {
            // enter post dialogue code here
            dc.controlsOn = true;
            dc.randomizeDirection = true;
            cs.gameObject.SetActive(true);
            nextTime = Time.time + spawnerRuntime;

            // end post dialog code
            dialogueFinished = false;
        }
        if (nextTime > 0 && Time.time > nextTime)
        {
            CodeFinished = true;
            devText.text = "";
        }
    }
}
