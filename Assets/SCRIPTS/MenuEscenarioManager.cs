using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuEscenarioManager : MonoBehaviour
{
    public Button road1Bttn, road2Bttn;
    private bool road1Selected, road2Selected;

    void Start()
    {
        // Desactivar Outline al inicio
        if (road1Bttn != null) road1Bttn.GetComponent<Outline>().enabled = false;
        if (road2Bttn != null) road2Bttn.GetComponent<Outline>().enabled = false;
    }

    private void ButtonSelected(Button on, Button off)
    {
        if (on == null || off == null) return;

        on.GetComponent<Outline>().enabled = true;
        off.GetComponent<Outline>().enabled = false;
    }

    public void Road1OnClick()
    {
        road1Selected = true;
        road2Selected = false;
        ButtonSelected(road1Bttn, road2Bttn);
        GameManager.instance.SeleccionarEscenario(0); // Guardar la selección
    }

    public void Road2OnClick()
    {
        road2Selected = true;
        road1Selected = false;
        ButtonSelected(road2Bttn, road1Bttn);
        GameManager.instance.SeleccionarEscenario(1); // Guardar la selección
    }

    public void Siguiente()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuCoche"); // Cambia a la escena de selección de coche
    }

    
}
