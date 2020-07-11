using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public int score = 0;
    public int closeCallMultiplier = 1;

    float nextTime = 0f;
    float multiplierCancelTime = 5f;
    
    public Text scoreUI;

    private void Start()
    {
    }

    private void Update()
    {
        if(Time.time > nextTime)
        {
            closeCallMultiplier = 1;
        }
        scoreUI.text =  score.ToString();
    }

    public void CloseCall()
    {
        //if the dog almost dodges the car, it will give extra points
        score += 100 * closeCallMultiplier;
        nextTime = Time.time + multiplierCancelTime;
    }
}
