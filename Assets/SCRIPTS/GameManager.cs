using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public RaceManager raceManager;

    public int escenarioSeleccionado = -1; // -1 indica que no se ha seleccionado
    public int cocheSeleccionado = -1; // -1 indica que no se ha seleccionado
    public List<TimeSpan> lapTimes;
    public TimeSpan bestTimeLap => lapTimes.Min();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // No destruir al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // Evita duplicados
        }
    }

    public void SeleccionarEscenario(int index)
    {
        escenarioSeleccionado = index;
    }

    public void SeleccionarCoche(int index)
    {
        cocheSeleccionado = index;
    }

    public void CargarCarrera()
    {
        if (escenarioSeleccionado != -1 && cocheSeleccionado != -1) // Verifica que ambos hayan sido seleccionados
        {
            if (escenarioSeleccionado == 0)
            {
                SceneManager.LoadScene("Escenario1");
            }
            else if (escenarioSeleccionado == 1)
            {
                SceneManager.LoadScene("Escenario2");
            }
        }
        else
        {
            Debug.LogError("¡Falta seleccionar escenario o coche!");
        }
    }
}
