using UnityEngine;
using System.Collections;


public class GameMaster : MonoBehaviour
{
    CarSpawner cs;
    DogController dc;

    public float p1waitTime = 5f;

    float nextTime = 0f;
    
    public bool _p1 = false;

    private void Start()
    {
        dc = FindObjectOfType<DogController>();
        cs = FindObjectOfType<CarSpawner>();

        cs.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(nextTime > 0  && Time.time >= nextTime)
        {
            Debug.Log("Running Script");
            cs.gameObject.SetActive(false);
            _p1 = true;
            nextTime = 0f;
        }   
    }
    public IEnumerator p1()
    {
        dc.controlsOn = true;
        cs.gameObject.SetActive(true);
        //play animations
        nextTime = Time.time + p1waitTime;
        yield return null;
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
}
