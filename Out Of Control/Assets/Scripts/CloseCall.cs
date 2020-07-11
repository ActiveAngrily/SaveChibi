using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCall : MonoBehaviour
{
    GameMaster gm;
    
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Car")
        {
            gm.CloseCall();
        }
    }
}
