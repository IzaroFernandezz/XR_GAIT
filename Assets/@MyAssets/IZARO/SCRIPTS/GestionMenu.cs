using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionMenu : MonoBehaviour
{
    // PANEL INICIAL
    public GameObject panelInicial;

    // GRANJA
    public GameObject panelGranjaPrincipal;
    public GameObject panelGranjaTarea1;
    public GameObject panelGranjaTarea2;
    public GameObject panelGranjaTarea3a;
    public GameObject panelGranjaTarea3b;

    // PARQUE
    public GameObject panelParquePrincipal;
    public GameObject panelParqueTarea1;
    public GameObject panelParqueTarea2;
    public GameObject panelParqueTarea3;

    // =========================
    // BOTONES PANEL INICIAL
    // =========================

    public void IrGranjaPrincipal()
    {
        panelInicial.SetActive(false);
        panelGranjaPrincipal.SetActive(true);
    }

    public void IrParquePrincipal()
    {
        panelInicial.SetActive(false);
        panelParquePrincipal.SetActive(true);
    }

    // =========================
    // BOTONES GRANJA PRINCIPAL
    // =========================

    public void IrGranjaTarea1()
    {
        panelGranjaPrincipal.SetActive(false);
        panelGranjaTarea1.SetActive(true);
    }

    public void IrGranjaTarea2()
    {
        panelGranjaPrincipal.SetActive(false);
        panelGranjaTarea2.SetActive(true);
    }

    public void IrGranjaTarea3a()
    {
        panelGranjaPrincipal.SetActive(false);
        panelGranjaTarea3a.SetActive(true);
    }

    public void IrGranjaTarea3b()
    {
        panelGranjaPrincipal.SetActive(false);
        panelGranjaTarea3b.SetActive(true);
    }

    // =========================
    // BOTONES PARQUE PRINCIPAL
    // =========================

    public void IrParqueTarea1()
    {
        panelParquePrincipal.SetActive(false);
        panelParqueTarea1.SetActive(true);
    }

    public void IrParqueTarea2()
    {
        panelParquePrincipal.SetActive(false);
        panelParqueTarea2.SetActive(true);
    }

    public void IrParqueTarea3()
    {
        panelParquePrincipal.SetActive(false);
        panelParqueTarea3.SetActive(true);
    }

    // =========================
    // BOTONES VOLVER
    // =========================

    public void VolverAlInicioDesdeGranja()
    {
        panelGranjaPrincipal.SetActive(false);
        panelInicial.SetActive(true);
    }

    public void VolverAlInicioDesdeParque()
    {
        panelParquePrincipal.SetActive(false);
        panelInicial.SetActive(true);
    }

    public void VolverAGranjaPrincipalDesdeTarea1()
    {
        panelGranjaTarea1.SetActive(false);
        panelGranjaPrincipal.SetActive(true);
    }

    public void VolverAGranjaPrincipalDesdeTarea2()
    {
        panelGranjaTarea2.SetActive(false);
        panelGranjaPrincipal.SetActive(true);
    }

    public void VolverAGranjaPrincipalDesdeTarea3a()
    {
        panelGranjaTarea3a.SetActive(false);
        panelGranjaPrincipal.SetActive(true);
    }

    public void VolverAGranjaPrincipalDesdeTarea3b()
    {
        panelGranjaTarea3b.SetActive(false);
        panelGranjaPrincipal.SetActive(true);
    }

    public void VolverAParquePrincipalDesdeTarea1()
    {
        panelParqueTarea1.SetActive(false);
        panelParquePrincipal.SetActive(true);
    }

    public void VolverAParquePrincipalDesdeTarea2()
    {
        panelParqueTarea2.SetActive(false);
        panelParquePrincipal.SetActive(true);
    }

    public void VolverAParquePrincipalDesdeTarea3()
    {
        panelParqueTarea3.SetActive(false);
        panelParquePrincipal.SetActive(true);
    }

    // =========================
    // BOTONES EMPEZAR GRANJA
    // =========================

    public void CargarGranjaTarea1()
    {
        SceneManager.LoadScene("SCENARIO1_TAREA1");
    }

    public void CargarGranjaTarea2()
    {
        SceneManager.LoadScene("SCENARIO1_TAREA2");
    }

    public void CargarGranjaTarea3a()
    {
        SceneManager.LoadScene("SCENARIO1_TAREA3a");
    }

    public void CargarGranjaTarea3b()
    {
        SceneManager.LoadScene("SCENARIO1_TAREA3b");
    }

    // =========================
    // BOTONES EMPEZAR PARQUE
    // =========================

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

    // =========================
    // GENERICO
    // =========================

    public void CargarEscenario(string escenario)
    {
        SceneManager.LoadScene(escenario);
    }
}