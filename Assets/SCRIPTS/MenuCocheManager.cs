using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCocheManager : MonoBehaviour
{
    public Button car1Bttn, car2Bttn, startRaceBttn;
    private bool car1Selected, car2Selected;

    void Start()
    {
        // Desactivar Outline al inicio
        if (car1Bttn != null) car1Bttn.GetComponent<Outline>().enabled = false;
        if (car2Bttn != null) car2Bttn.GetComponent<Outline>().enabled = false;

        // Desactivar botón de inicio de carrera al inicio
        if (startRaceBttn != null) startRaceBttn.interactable = false;
    }

    private void ButtonSelected(Button on, Button off)
    {
        if (on == null || off == null) return;

        on.GetComponent<Outline>().enabled = true;
        off.GetComponent<Outline>().enabled = false;
    }

    public void Car1OnClick()
    {
        car1Selected = true;
        car2Selected = false;
        ButtonSelected(car1Bttn, car2Bttn);
        GameManager.instance.SeleccionarCoche(0);
        CheckStartRaceButton();
    }

    public void Car2OnClick()
    {
        car2Selected = true;
        car1Selected = false;
        ButtonSelected(car2Bttn, car1Bttn);
        GameManager.instance.SeleccionarCoche(1);
        CheckStartRaceButton();
    }

    private void CheckStartRaceButton()
    {
        if (startRaceBttn != null && (car1Selected || car2Selected))
        {
            startRaceBttn.interactable = true;
        }
    }

    public void StartRace()
    {
        GameManager.instance.CargarCarrera(); // Carga la carrera con los datos seleccionados
    }

    public void Atras()
    {
        SceneManager.LoadScene("MenuEscenario");
    }
}
