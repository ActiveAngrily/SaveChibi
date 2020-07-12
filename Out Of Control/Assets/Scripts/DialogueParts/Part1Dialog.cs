using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Part1Dialog : MonoBehaviour
{

    DialogueController diac;
    Dialogue d;

    DogController dc;
    CarSpawner cs;
    Text devText;
    controlBar ctrl;

    public bool dialogueRunning = false;
    public bool dialogueFinished = false;
    public bool CodeFinished = false;

    float nextTime = 0f;
    public float spawnerRuntime = 5f;

    float nextTime2 = 0f;
    public float infoBarWaitTime = 1.5f;

    float nextTime3 = 0f;
    public float waitTime = 2f;

    void Awake()
    {
        diac = FindObjectOfType<DialogueController>();
        d = GetComponent<Dialogue>();
        dc = FindObjectOfType<DogController>();
        cs = FindObjectOfType<CarSpawner>();
        devText = FindObjectOfType<Text>();
        //   dc.CancelAllMotion();
        ctrl = FindObjectOfType<controlBar>();

    }
    void OnEnable()
    {
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
    bool oneRun = false;
    void Update()
    {
        if (diac.allDialogsDone)
        {
            if (!oneRun)
            {
                dialogueFinished = true;
                nextTime2 = Time.time + infoBarWaitTime;
                nextTime3 = Time.time + infoBarWaitTime + waitTime;
                oneRun = true;
            }
        }
        if (dialogueFinished)
        {
            if (Time.time > nextTime2)
            {
                showInfoBar();
                Debug.Log("SHowing");
                if (Time.time > nextTime3)
                {
                    // enter post dialogue code here
                    dc.controlsOn = true;

                    cs.gameObject.SetActive(true);
                    nextTime = Time.time + spawnerRuntime;

                    // end post dialog code
                    dialogueFinished = false;

                }
            }
        }
        if (nextTime > 0 && Time.time > nextTime)
        {
            //cs.gameObject.SetActive(false);
            CodeFinished = true;
            devText.text = "";
        }
    }
    private void showInfoBar()
    {
        // Show info bar
        ctrl.WASD();
        Debug.Log("Show Information Bar");
    }
}
