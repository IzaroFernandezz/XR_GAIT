using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionMenu : MonoBehaviour
{
    [Header("PANEL INICIAL")]
    public GameObject panelInicial;

    [Header("GRANJA")]
    public GameObject panelGranjaPrincipal;
    public GameObject panelGranjaTarea1;
    public GameObject panelGranjaTarea2;
    public GameObject panelGranjaTarea3;
    public GameObject panelGranjaTarea4;

    [Header("PARQUE")]
    public GameObject panelParquePrincipal;
    public GameObject panelParqueTarea1;
    public GameObject panelParqueTarea2;
    public GameObject panelParqueTarea3;

    void Start()
    {
        IrInicio();
    }

    void OcultarTodo()
    {
        panelInicial.SetActive(false);

        panelGranjaPrincipal.SetActive(false);
        panelGranjaTarea1.SetActive(false);
        panelGranjaTarea2.SetActive(false);
        panelGranjaTarea3.SetActive(false);
        panelGranjaTarea4.SetActive(false);

        panelParquePrincipal.SetActive(false);
        panelParqueTarea1.SetActive(false);
        panelParqueTarea2.SetActive(false);
        panelParqueTarea3.SetActive(false);
    }

    public void IrInicio()
    {
        OcultarTodo();
        panelInicial.SetActive(true);
    }

    public void IrGranjaPrincipal()
    {
        OcultarTodo();
        panelGranjaPrincipal.SetActive(true);
    }

    public void IrParquePrincipal()
    {
        OcultarTodo();
        panelParquePrincipal.SetActive(true);
    }

    public void IrGranjaTarea1()
    {
        OcultarTodo();
        panelGranjaTarea1.SetActive(true);
    }

    public void IrGranjaTarea2()
    {
        OcultarTodo();
        panelGranjaTarea2.SetActive(true);
    }

    public void IrGranjaTarea3()
    {
        OcultarTodo();
        panelGranjaTarea3.SetActive(true);
    }

    public void IrGranjaTarea4()
    {
        OcultarTodo();
        panelGranjaTarea4.SetActive(true);
    }

    public void IrParqueTarea1()
    {
        OcultarTodo();
        panelParqueTarea1.SetActive(true);
    }

    public void IrParqueTarea2()
    {
        OcultarTodo();
        panelParqueTarea2.SetActive(true);
    }

    public void IrParqueTarea3()
    {
        OcultarTodo();
        panelParqueTarea3.SetActive(true);
    }

    public void CargarGranjaTarea1()
    {
        SceneManager.LoadScene("SCENARIO1_TAREA1");
    }

    public void CargarGranjaTarea2()
    {
        SceneManager.LoadScene("SCENARIO1_TAREA2");
    }

    public void CargarGranjaTarea3()
    {
        SceneManager.LoadScene("SCENARIO1_TAREA3");
    }

    public void CargarGranjaTarea4()
    {
        SceneManager.LoadScene("SCENARIO1_TAREA4");
    }

    public void CargarParqueTarea1()
    {
        SceneManager.LoadScene("SCENARIO2_TAREA1");
    }

    public void CargarParqueTarea2()
    {
        SceneManager.LoadScene("SCENARIO2_TAREA2");
    }

    public void CargarParqueTarea3()
    {
        SceneManager.LoadScene("SCENARIO2_TAREA3");
    }

    public void CargarEscenario(string escenario)
    {
        SceneManager.LoadScene(escenario);
    }
}
