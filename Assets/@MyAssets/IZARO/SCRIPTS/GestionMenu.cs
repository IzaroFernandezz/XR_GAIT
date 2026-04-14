using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionMenu : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject panelInstrucciones1;
    public GameObject panelInstrucciones2;
    public GameObject panelInstrucciones3a;
    public GameObject panelInstrucciones3b;

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

    public void IrInstrucciones3a()
    {
        panelMenu.SetActive(false);
        panelInstrucciones3a.SetActive(true);
    }

    public void IrInstrucciones3b()
    {
        panelMenu.SetActive(false);
        panelInstrucciones3b.SetActive(true);
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

    public void CargarTarea3a()
    {
        SceneManager.LoadScene("SCENARIO1_TAREA3a");
    }

    public void CargarTarea3b()
    {
        SceneManager.LoadScene("SCENARIO1_TAREA3b");
    }

    public void CargarEscenario(string escenario)
    {
        SceneManager.LoadScene(escenario);
    }

    public void CargarSCENARIO2()
    {
        SceneManager.LoadScene("SCENARIO2");
    }


}
