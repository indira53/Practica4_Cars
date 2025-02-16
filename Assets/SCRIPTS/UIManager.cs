using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tiempoText;

    private CarController coche;
    // Start is called before the first frame update
    public void SetCar(GameObject cocheInstanciado)
    {
        coche = cocheInstanciado.GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        //tiempoText.text = "Tiempo: " + Mathf.Floor(Time.time) + "s";

    }

}