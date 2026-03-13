//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class GestionMenu : MonoBehaviour
//{
//    public GameObject Panel_Inicio;
//    public GameObject Panel_Instrucciones;

//    void Start()
//    {
//        // Aseguramos el estado inicial al arrancar
//        Panel_Inicio.SetActive(true);
//        Panel_Instrucciones.SetActive(false);
//    }

//    public void MostrarInstrucciones()
//    {
//        Panel_Inicio.SetActive(false);
//        Panel_Instrucciones.SetActive(true);
//    }

//    public void CargarPatio()
//    {
//        SceneManager.LoadScene("SCENARIO1_YARD_PRUEBAS");
//    }
//}



using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionMenu : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject panelInstrucciones1;
    public GameObject panelInstrucciones2;

    // BOTONES DEL MENU
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

    // BOTONES DE INSTRUCCIONES
    public void CargarPasillo()
    {
        SceneManager.LoadScene("SCENARIO1_PASILLO");
    }

    public void CargarYardPruebas()
    {
        SceneManager.LoadScene("SCENARIO1_YARD_PRUEBAS");
    }
}


