using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
    [NonSerialized] public RaceManager raceManager;
    [NonSerialized] public bool reached;
    public bool meta;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("cilideando");
        if (collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("Con el coche");
            reached = true;
            if (meta)
            {
                raceManager.GoalPassed();
            }
        }
    }
}
