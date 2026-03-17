using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionMenu : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject panelInstrucciones1;
    public GameObject panelInstrucciones2;
    public GameObject panelInstrucciones3;

    // BOTONES DEL MENU (Para abrir los paneles)
    public void IrInstrucciones1()
    {
        panelMenu.SetActive(false);
        panelInstrucciones1.SetActive(true);
    }

    public void IrInstrucciones2()
    {
        panelMenu.SetActive(false);
        panelInstrucciones2.SetActive(true);
    }

    public void IrInstrucciones3()
    {
        panelMenu.SetActive(false);
        panelInstrucciones3.SetActive(true);
    }

    // BOTONES DE INSTRUCCIONES (Para cargar las escenas)
    public void CargarTarea1()
    {
        SceneManager.LoadScene("SCENARIO1_TAREA1");
    }

    public void CargarTarea2()
    {
        SceneManager.LoadScene("SCENARIO1_TAREA2");
    }

    public void CargarTarea3()
    {
        SceneManager.LoadScene("SCENARIO1_TAREA3");
    }
}
