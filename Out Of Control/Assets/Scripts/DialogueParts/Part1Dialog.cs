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

    public bool dialogueRunning = false;
    public bool dialogueFinished = false;
    public bool CodeFinished = false;

    float nextTime = 0f;
    public float spawnerRuntime = 5f;

    float nextTime2 = 0f;
    public float infoBarWaitTime = 5f;

    float nextTime3 = 0f;
    public float waitTime = 2f;

    void Awake()
    {
        diac = FindObjectOfType<DialogueController>();
        d = GetComponent<Dialogue>();
        dc = FindObjectOfType<DogController>();
        cs = FindObjectOfType<CarSpawner>();
        devText = FindObjectOfType<Text>();
        dc.CancelAllMotion();

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
        if (Time.time > nextTime2)
        {

            StartCoroutine(showInfoBar());
            if (Time.time > nextTime3)
            {
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
                    //cs.gameObject.SetActive(false);
                    CodeFinished = true;
                    devText.text = "";
                }
            }
        }
    }
    private IEnumerator showInfoBar()
    {
        // Show info bar
        Debug.Log("Show Information Bar");
        yield return null;
    }
}
