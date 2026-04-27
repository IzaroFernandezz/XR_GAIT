using UnityEngine;
using UnityEngine.UI;


public class BotonesParque : MonoBehaviour
{
    [Header("Materiales")]
    public Material materialRojo;
    public Material materialVerde;

    private Image miRenderer;
    private bool estado = false; // false = rojo, true = verde

    void Start()
    {
        miRenderer = GetComponent<Image>();
        ActualizarColor();
    }

    public void AlPulsar()
    {
        estado = !estado;
        ActualizarColor();
    }

    void ActualizarColor()
    {
        if (miRenderer != null)
        {
            miRenderer.color = estado ? materialVerde.color : materialRojo.color;
        }
    }
}