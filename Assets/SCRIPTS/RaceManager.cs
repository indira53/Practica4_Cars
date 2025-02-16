using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceManager : MonoBehaviour
{
    public GameObject cochePrefabLila;

    public GameObject cochePrefabRojo;
    private GameObject cocheInGame;

    public Transform spawn;
    
    public List<CheckpointBehaviour> checkpoints = new List<CheckpointBehaviour>();
    public TextMeshProUGUI lapNumber;
    public TextMeshProUGUI lapTime;
    
    private int lap;
    public int maxLaps;
    private Stopwatch stopwatch = new Stopwatch();
    private List<TimeSpan> lapTimes = new List<TimeSpan>();
    public TextMeshProUGUI speedtext;
    
    public bool allCheckpointsReached
    {
        get 
        {
            foreach (var checkpoint in checkpoints)
            {
                if (checkpoint.reached == false)
                {
                    return false;
                }
            } 
            return true;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        GameManager.instance.raceManager = this;

        int cocheGuardado = GameManager.instance.cocheSeleccionado;

        if (cocheGuardado == 0)
        {
            cocheInGame = Instantiate(cochePrefabLila, spawn.position, spawn.rotation);
        }
        else if (cocheGuardado == 1)
        {
            cocheInGame = Instantiate(cochePrefabRojo, spawn.position, spawn.rotation);
        }
        cocheInGame.GetComponent<CarController>().carSpeedText = speedtext;
        foreach (var checkpoint in checkpoints)
        {
            checkpoint.raceManager = this;
        }
        lap = 0;
        stopwatch = new Stopwatch();
        

    }
    public void GoalPassed()
    {
        if (lap == 0 || allCheckpointsReached)
        {
            
            // empieza una nueva vuelta
            foreach (var checkpoint in checkpoints)
            {
                checkpoint.reached = false;
            }
            if ( lap != 0) lapTimes.Add(stopwatch.Elapsed);

            lap += 1;
            stopwatch.Restart();

            if (lap == 4)
            {
                GameManager.instance.lapTimes = lapTimes;
                SceneManager.LoadScene("FinishScene");
            }

        }
        else
        {
            // se ha saltado algun checkpoint
        }
    }

    // Update is called once per frame
    void Update()
    {
        lapNumber.text = $"Vuelta: {lap}";
        lapTime.text = $"Tiempo: {stopwatch.Elapsed.ToString("m\\:ss\\.fff")} s";
    }
}