using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishScene : MonoBehaviour
{
    public TextMeshProUGUI bestLapText;
    // Start is called before the first frame update
    void Start()
    {
        bestLapText.text = $"Mejor vuelta: {GameManager.instance.bestTimeLap.ToString("m\\:ss\\.fff")} s"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
