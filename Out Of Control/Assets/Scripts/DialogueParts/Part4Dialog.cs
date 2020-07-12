using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Part4Dialog : MonoBehaviour
{

    DialogueController diac;
    Dialogue d;
    public GameObject player;
    DogController dc;
    CarSpawner cs;
    DragAndDrop dad;
    Text devText;

    bool part4state = false;

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
        cs.gameObject.SetActive(false);

        diac.allDialogsDone = false;
        cs.gameObject.SetActive(false);
        if (!dialogueRunning)
        {
            // enter pre dialog code here
            dc.controlsOn = false;
            diac.StartDialogue(d);
            dialogueRunning = true;
            cs.gameObject.SetActive(false);
            dc.CancelAllMotion();
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
            dc.controlsOn = false;


            nextTime = Time.time + spawnerRuntime;

            // end post dialog code
            dialogueFinished = false;
        }
        if (nextTime > 0 && Time.time > nextTime)
        {
            cs.gameObject.SetActive(false);
            CodeFinished = true;
            devText.text = "";
        }
    }
}
