using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    private bool road1Btn, road2Btn, car1Btn, car2Btn = false;
    public Button road1Bttn, road2Bttn, car1Bttn, car2Bttn;
    public Button startRaceBttn; // Este botón solo existe en la selección de coche

    void Start()
    {
        // Verifica si el botón de iniciar carrera está asignado
        if (startRaceBttn != null)
        {
            startRaceBttn.interactable = false; // Desactivar botón al inicio
        }
    }

    private void ButtonSelected(Button on, Button off)
    {
        on.GetComponent<Outline>().enabled = true;
        off.GetComponent<Outline>().enabled = false;
    }

    public void Car1OnClick()
    {
        car1Btn = true;
        car2Btn = false;
        ButtonSelected(car1Bttn, car2Bttn);
        GameManager.instance.SeleccionarCoche(0);
        CheckStartRaceButton();
    }

    public void Car2OnClick()
    {
        car2Btn = true;
        car1Btn = false;
        ButtonSelected(car2Bttn, car1Bttn);
        GameManager.instance.SeleccionarCoche(1);
        CheckStartRaceButton();
    }

    public void Road1OnClick()
    {
        road1Btn = true;
        road2Btn = false;
        ButtonSelected(road1Bttn, road2Bttn);
        GameManager.instance.SeleccionarEscenario(0);
        CheckStartRaceButton();
    }

    public void Road2OnClick()
    {
        road2Btn = true;
        road1Btn = false;
        ButtonSelected(road2Bttn, road1Bttn);
        GameManager.instance.SeleccionarEscenario(1);
        CheckStartRaceButton();
    }

    private void CheckStartRaceButton()
    {
        if (startRaceBttn != null && (road1Btn || road2Btn) && (car1Btn || car2Btn))
        {
            startRaceBttn.interactable = true;
        }
    }

    public void StartRace()
    {
        GameManager.instance.CargarCarrera();
    }

    public void Listo()
    {
        SceneManager.LoadScene("MenuCoche");
    }
}
