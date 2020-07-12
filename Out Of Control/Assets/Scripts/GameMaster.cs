using UnityEngine;
using System.Collections;


public class GameMaster : MonoBehaviour
{
    /*
    CarSpawner cs;
    DogController dc;

    public float p1waitTime = 5f;
    public float p2waitTime = 5f;
    public float p3waitTime = 5f;
    public float p4waitTime = 5f;

    float nextTime = 0f;

    public bool _p1 = false;
    public bool _p2 = false;
    public bool _p3 = false;
    public bool _p4 = false;

    private void Start()
    {
        dc = FindObjectOfType<DogController>();
        cs = FindObjectOfType<CarSpawner>();

        cs.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (p1doOnce)
        {
            if (nextTime > 0 && Time.time >= nextTime)
            {
                Debug.Log("P1 - Before End");
                cs.gameObject.SetActive(false);
                _p1 = true;
                nextTime = 0f;

                p1doOnce = false;
            }
        }
        if (p2doOnce)
        {
            if (nextTime > 0 && Time.time >= nextTime)
            {
                Debug.Log("P2 - Before End");
                cs.gameObject.SetActive(false);
                _p2 = true;
                nextTime = 0f;
                p2doOnce = false;
            }
        }
    }

    bool p1doOnce = false;
    public void p1()
    {
        Debug.Log("P1 - After Dialogs");
        dc.controlsOn = true;
        cs.gameObject.SetActive(true);
        //play animations
        if (!p1doOnce)
        {
            nextTime = Time.time + p1waitTime;
            p1doOnce = true;
        }
    }

    public bool p2doOnce = false;
    public void p2()
    {
        Debug.Log("P2 - After Dialogs");
        dc.controlsOn = true;
        dc.randomizeDirection = true;
        cs.gameObject.SetActive(true);

        if (!p2doOnce)
        {
            Debug.Log("P2 - Doing Once");
            nextTime = Time.time + p2waitTime;
            p2doOnce = true;
        }
    }

    bool p3doOnce = false;
    public void p3()
    {
        Debug.Log("P3 - After Dialog");
        dc.controlsOn = true;

        cs.gameObject.SetActive(true);

        if (!p3doOnce)
        {
            Debug.Log("P3 - Doing Once");
            nextTime = Time.time + p3waitTime;
            p3doOnce = true;
        }

    }

    /*
    Element 1 - Normal Controls
    Element 2 - Randomized Controls
    Element 3 - Drag and Drop the dog
    Element 4 - Drag and Drop the Cars

    // THE END
    */
    /*
    CarSpawner cs;
    DogController dc;
    DialogueController diac;

    public Dialogue pt1;
    public Dialogue pt2;
    public Dialogue pt3;
    public Dialogue pt4;

    float nextTime = 0f;
    public float[] SpawnTime = { 30f, 30f,
                                    30f, 30f };


    public bool timeelapsed = false;
    private bool initializing = false;

    private void Start()
    {
        dc = FindObjectOfType<DogController>();
        cs = FindObjectOfType<CarSpawner>();
        diac = FindObjectOfType<DialogueController>();

        cs.gameObject.SetActive(false);

        Init();
    }

    private void Update()
    {
        //For Part 1

        if (initializing)
        {
            if (Time.time >= nextTime)
            {
                cs.gameObject.SetActive(false);
                timeelapsed = true;
            }
        }
    }
    public void Init()
    {
        Part1();
    }
    public void Part1()
    {
        // Run Dialog Box
        diac.dialogue = pt1;
        diac.StartDialogue();
        // Start Car Spawner after all the dialog is spoken
        if (diac.allDialogsDone)
        {
            cs.gameObject.SetActive(true);
            nextTime = Time.time + SpawnTime[0];
            initializing = true;
            if (timeelapsed)
            {
                cs.gameObject.SetActive(false);
                initializing = false;
                Part2();
                return;
            }
        }
    }
    public void Part2()
    {
        diac.dialogue = pt2;
        diac.StartDialogue();

        if (diac.allDialogsDone)
        {
            cs.gameObject.SetActive(true);
            nextTime = Time.time + SpawnTime[1];
            initializing = true;
            if (timeelapsed)
            {
                cs.gameObject.SetActive(false);
                initializing = false;
                Part3();
                return;
            }
        }
    }
    public void Part3()
    {
        diac.dialogue = pt3;
        diac.StartDialogue();

        if (diac.allDialogsDone)
        {
            cs.gameObject.SetActive(true);
            nextTime = Time.time + SpawnTime[2];
            initializing = true;

            if (timeelapsed)
            {
                cs.gameObject.SetActive(false);
                initializing = false;
                Part4();
                return;
            }
        }
    }

    public void Part4()
    {

        diac.dialogue = pt4;
        diac.StartDialogue();
        if (diac.allDialogsDone)
        {
            cs.gameObject.SetActive(true);
            nextTime = Time.time + SpawnTime[3];
            initializing = true;

            if (timeelapsed)
            {
                cs.gameObject.SetActive(false);
                initializing = false;
                Part4();
                return;
            }
        }
    }*/

    public Part1Dialog p1D;
    public Part2Dialog p2D;

    private void Start()
    {
        p1D.gameObject.SetActive(true);
    }
    void Update()
    {
        if (p1D.CodeFinished)
        {
            p1D.gameObject.SetActive(false);

            p2D.gameObject.SetActive(true);

            // add a screen shake here
        }
        if (p2D.CodeFinished)
        {
            p2D.gameObject.SetActive(false);
        }
    }
}
